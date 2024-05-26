using Microsoft.AspNetCore.Mvc;

namespace ECMS.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
