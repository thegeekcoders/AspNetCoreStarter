using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreStarter
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}