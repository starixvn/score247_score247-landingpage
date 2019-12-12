namespace Score247LandingPage.LocalizationRouting
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;

    public class RouteSegmentCultureProvider : IRequestCultureProvider
    {
        private readonly string defaultCulture;

        private readonly IList<CultureInfo> SupportedCultures;

        public RouteSegmentCultureProvider(IList<CultureInfo> supportedCultures, string defaultCulture)
        {
            this.defaultCulture = defaultCulture;
            SupportedCultures = supportedCultures;
        }

        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var routeValues = httpContext.Request.Path.Value.Split('/');
            if (routeValues.Count() <= 1)
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }

            if (!SupportedCultures.Any(x =>
                 x.TwoLetterISOLanguageName.ToLower() == routeValues[1].ToLower() ||
                 x.Name.ToLower() == routeValues[1].ToLower()))
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }

            return Task.FromResult(new ProviderCultureResult(routeValues[1]));
        }
    }
}