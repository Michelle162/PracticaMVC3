using Microsoft.AspNetCore.Mvc;

namespace Practica3.Controllers
{
    public class vistaRazorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult bloqueMultiple()
        {
            return View();
        }

        public IActionResult Condiciones() 
        {
            return View();
        }

        public IActionResult Bucle() 
        {
            return View();
        }

    }
}
