using System.Net;
using System.Web.Mvc;

namespace AspNetMvc5MyTemplate.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult ServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public ActionResult NotFound()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View();
        }
    }
}