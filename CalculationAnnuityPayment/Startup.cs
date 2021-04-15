using CalculationAnnuityPayment.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationAnnuityPayment
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(option => { option.ResourcesPath = "Resources"; });
              services.AddMvc(options =>
              {
                  var F = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                  var L = F.Create("ModelBindingMessages", "CalculationAnnuityPayment");
                  options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                      (x) => L["The value '{0}' is invalid.", x]);
                  options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
                      (x) => L["The field {0} must be a number.", x]);
                  options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
                      (x) => L["A value for the '{0}' property was not provided.", x]);
                  options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                      (x, y) => L["The value '{0}' is not valid for {1}.", x, y]);
                  options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
                      () => L["A value is required."]);
                  options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
                      (x) => L["The supplied value is invalid for {0}.", x]);
                  options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                      (x) => L["Null value is invalid.", x]);
              })
                .AddDataAnnotationsLocalization()
                   .AddViewLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("ru") };
                options.DefaultRequestCulture = new RequestCulture("ru", "ru");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            //services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureModelBindingLocalization>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo("ru")};
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("ru")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseExceptionHandler("/Home/Error");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "AnnuityPayment", action = "CreditData" });
            });
        }   }
}
