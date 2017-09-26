using System.Web.Mvc;

namespace AspNetMvc5MyTemplate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}