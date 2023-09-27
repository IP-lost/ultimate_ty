using Microsoft.AspNetCore.Mvc;
using ultimate_ty.Data;
using ultimate_ty.Models;

namespace ultimate_ty.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //notacion para recibir datos de un post!@#$%^&&&&&&&&&&
        [HttpPost]

        public IActionResult Index(Usuario usuario)
        {
            //Variable para acceder a los metodos de Data
            DataUsuario datausuario =   new DataUsuario();

            var usuario1 = datausuario.ValidarUsuario(usuario.Correo, usuario.Clave);
            if (usuario1 == null)
            {
                //redirecciona a la vista index del controlador home 
                return RedirectToAction("Index","Home");
            }    
            else
            {
                //se maniene en la misma pagina
                return View();
            }    
        }
    }
}
