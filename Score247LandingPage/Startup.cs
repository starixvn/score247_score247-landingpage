using System;
using System.Globalization;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Robotify.AspNetCore;
using Score247LandingPage.LocalizationResources;
using WebEssentials.AspNetCore.Pwa;

namespace Score247LandingPage
{
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
            var cultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("vi")
            };

            //services.AddRobotify(c => c
            //    .AddDisallowAllRobotGroupProvider()
            //    .AddRobotGroupsFromAppSettings()
            //);

            services.AddMvc()
                .AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(
                    ops =>
                    {
                        ops.ResourcesPath = "LocalizationResources";
                        ops.RequestLocalizationOptions = o =>
                        {
                            o.SupportedCultures = cultures;
                            o.SupportedUICultures = cultures;
                            o.DefaultRequestCulture = new RequestCulture("en");
                        };
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

            app.UseRequestLocalization();
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

            app.UseMvc();
        }
    }
}