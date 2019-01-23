using Microsoft.AspNetCore.Mvc;

namespace BibliotekGruppProjekt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
