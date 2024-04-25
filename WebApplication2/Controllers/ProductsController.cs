using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Intro()
        {
            return View();
        }
    }
}
