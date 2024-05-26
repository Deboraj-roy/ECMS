using Microsoft.AspNetCore.Mvc;

namespace ECMS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
