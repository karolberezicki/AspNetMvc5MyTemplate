using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace AspNetMvc5MyTemplate
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true;
        }

        private void Application_Error(object sender, EventArgs e)
        {
            Exception lastException = Server.GetLastError();
            if (lastException != null)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Fatal(lastException);
                logger.Info($"Unhandled exception: {lastException.Message}");
            }

            // Clear the error from the server to avoid infinite looping
            Server.ClearError();

            //Redirect Error page
            Response.Redirect("~/Error/ServerError");
        }
    }
}