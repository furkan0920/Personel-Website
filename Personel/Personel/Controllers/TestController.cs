using Microsoft.AspNetCore.Mvc;

namespace Personel.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
