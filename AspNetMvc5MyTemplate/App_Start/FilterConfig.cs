using System.Web.Mvc;
using NWebsec.Mvc.HttpHeaders;

namespace AspNetMvc5MyTemplate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new SetNoCacheHttpHeadersAttribute());
        }
    }
}
