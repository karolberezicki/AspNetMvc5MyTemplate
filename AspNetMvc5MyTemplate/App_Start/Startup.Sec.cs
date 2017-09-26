using System.Configuration;
using AspNetMvc5MyTemplate.Common;
using Owin;
using NWebsec.Owin;

namespace AspNetMvc5MyTemplate
{
    public partial class Startup
    {
        public void ConfigureSec(IAppBuilder app)
        {
            app.UseCsp(options => options
                .DefaultSources(s => s.Self())
                .ScriptSources(s => s.Self())
                .StyleSources(s => s.Self())
                .ImageSources(s => s.Self())
                .FontSources(s => s.Self()));

            app.UseHsts(options => options
                .MaxAge(seconds: 10886400)
                .IncludeSubdomains()
                .Preload());

            app.UseXfo(options => options
                .Deny());

            string[] allowedRedirectDestinations =
                ConfigurationManager.AppSettings[Consts.WebConfigKey.AllowedRedirectDestinations].Split('|');

            app.UseRedirectValidation(options => options
                .AllowedDestinations(allowedRedirectDestinations)
                .AllowSameHostRedirectsToHttps());

            app.UseXXssProtection(options => options
                .EnabledWithBlockMode());

            app.UseXContentTypeOptions();

            app.UseXDownloadOptions();

            app.UseXRobotsTag(options => options
                .NoIndex()
                .NoFollow());
        }
    }
}