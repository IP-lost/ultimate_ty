using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ultimate_ty.Models;


using Microsoft.AspNetCore.Authorization;

namespace ultimate_ty.Controllers
{

    //Notacion para autorizar todas las vistas del controlador
   [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //Autorizacion por vistas

        [Authorize (Roles ="Administrador, Superivisor")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrador, Superivisor")]

        public IActionResult Clientes()
        {
            return View();
        }
        [Authorize(Roles = "Administrador, Superivisor")]

        public IActionResult Productos()
        {
            return View();
        }
        [Authorize(Roles = "Administrador, Superivisor, Empleado")]

        public IActionResult Ventas()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}