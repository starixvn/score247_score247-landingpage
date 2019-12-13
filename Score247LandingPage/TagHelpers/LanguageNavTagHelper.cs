namespace Score247LandingPage.TagHelpers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Options;

    [HtmlTargetElement("lang-nav")]
    public class LanguageNavTagHelper : TagHelper
    {
        public string CultureKeyName { get; set; } = "culture";

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        private readonly IOptions<RequestLocalizationOptions> options;

        private readonly LinkGenerator linkGenerator;

        public LanguageNavTagHelper(IOptions<RequestLocalizationOptions> options, LinkGenerator linkGenerator)
        {
            this.options = options;
            this.linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            InsertSupportedCultures(ref output);
        }

        private void InsertSupportedCultures(ref TagHelperOutput output)
        {
            var routeData = CreateRouteDataDictionary();
            var cultures = options.Value.SupportedCultures.OrderBy(x => x.EnglishName);

            var div = new TagBuilder("div");
            div.Attributes.Add("aria-labeledby", "dropdownMenuButton");
            div.AddCssClass("dropdown-menu");

            foreach (var cul in cultures)
            {
                routeData[CultureKeyName] = cul.Name;

                var a = new TagBuilder("a");
                a.AddCssClass($"dropdown-item {(cul.Name == CultureInfo.CurrentUICulture.Name ? "active" : string.Empty)}");
                a.Attributes.Add("href", linkGenerator.GetPathByRouteValues(httpContext: ViewContext.HttpContext, values: routeData, routeName: ""));

                var flag = new TagBuilder("span");
                flag.AddCssClass($"flag-{cul.Name}");
                a.InnerHtml.AppendHtml(flag);
                a.InnerHtml.Append(cul.NativeName);

                div.InnerHtml.AppendHtml(a);
            }

            output.TagName = "div";
            output.Attributes.Add("class", "dropdown language");

            var toggle = CreateToggle();
            output.Content.AppendHtml(toggle);

            output.Content.AppendHtml(div);
        }

        private Dictionary<string, object> CreateRouteDataDictionary()
        {
            var routeData = new Dictionary<string, object>();

            foreach (var r in ViewContext.RouteData.Values)
            {
                routeData.Add(r.Key, r.Value);
            }

            foreach (var r in ViewContext.HttpContext.Request.Query)
            {
                routeData.Add(r.Key, r.Value);
            }

            return routeData;
        }

        private TagBuilder CreateToggle()
        {
            var toggle = new TagBuilder("button");
            toggle.AddCssClass("btn dropdown-toggle");
            toggle.Attributes.Add("type", "button");
            toggle.Attributes.Add("aria-label", "Language");
            toggle.Attributes.Add("id", "dropdownMenuButton");
            toggle.Attributes.Add("data-toggle", "dropdown");
            toggle.Attributes.Add("aria-haspopup", "true");
            toggle.Attributes.Add("aria-expanded", "false");

            var flag = new TagBuilder("span");
            flag.AddCssClass($"flag-{CultureInfo.CurrentUICulture.Name}");

            var arrowIcon = new TagBuilder("span");
            arrowIcon.AddCssClass("icon-arrow-down");

            toggle.InnerHtml.AppendHtml(flag);
            toggle.InnerHtml.AppendHtml(arrowIcon);

            return toggle;
        }
    }
}