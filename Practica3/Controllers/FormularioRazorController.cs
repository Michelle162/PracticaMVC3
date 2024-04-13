using Microsoft.AspNetCore.Mvc;

namespace Practica3.Controllers
{
    public class FormularioRazorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
