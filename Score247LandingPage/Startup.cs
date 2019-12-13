namespace Score247LandingPage
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration.Binder;
    using Score247LandingPage.LocalizationRouting;
    using WebEssentials.AspNetCore.Pwa;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var cultures = Configuration.GetSection("SupportCultures").Get<string[]>()
                .Select(x => new CultureInfo(x)).ToList();

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                opts.DefaultRequestCulture = new RequestCulture("en");
                opts.SupportedCultures = cultures;
                opts.SupportedUICultures = cultures;
                opts.RequestCultureProviders.Insert(0, new RouteSegmentCultureProvider(cultures));
            });

            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "LocalizationResources";
            });

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, opts => opts.ResourcesPath = "LocalizationResources")
                .AddRazorPagesOptions(x =>
                {
                    x.Conventions.Add(new RouteTemplateModelConvention());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddProgressiveWebApp(new PwaOptions { AllowHttp = true });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRobotsTxt(builder =>
                builder
                    .AddSection(section =>
                        section
                            .AddComment("Allow Googlebot")
                            .AddUserAgent("Googlebot")
                            .Allow("/")
                        )
                    .AddSection(section =>
                        section
                            .AddComment("Disallow the rest")
                            .AddUserAgent("*")
                            .AddCrawlDelay(TimeSpan.FromSeconds(10))
                            .Disallow("/")
                        )
                    .AddSitemap("https://example.com/sitemap.xml")
            );
            //app.UseRobotify(c => c
            //    .Enabled(true)
            //    //.WithSitemap(new Uri("https://www.example.com/sitemap.xml"))
            //    //.DisableFileHeaderComments()
            //    //.WithCrawlDelay(delayInSeconds: 10)
            //);
            app.UseRequestLocalization();

            app.UseMvc();
        }
    }
}