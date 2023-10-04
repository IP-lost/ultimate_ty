using Microsoft.AspNetCore.Mvc;
using ultimate_ty.Data;
using ultimate_ty.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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

        //sobreescritura de metodo index que recibe datos del tipo usuario
        //se modifica el metodo a asocrono y se le añade a la lista de Task


        public async Task<IActionResult> Index(Usuario usuario)
        {
            //Variable para acceder a los metodos de Data
            DataUsuario datausuario = new DataUsuario();

            var usuario1 = datausuario.ValidarUsuario(usuario.Correo, usuario.Clave);
            if (usuario1 == null)
            {
                //redirecciona a la vista index del controlador home 
                //return RedirectToAction("Index","Home");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,usuario1.Nombre),
                    new Claim("Correo",usuario1.Correo)
                };


               //Implementacion de los trigers en este momento estan por cargar y estaran en tema de debate los grupos estaran en el caso de 
               //la base de datos estan en los demas campos de los controladores y estaremos completando en el tiempo restante
                foreach (string rol in usuario1.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));



                return RedirectToAction("Index", "Home");
            }


            else
            {
                //se maniene en la misma pagina
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return View();
            }
        }


        public IActionResult Salir()
        {
            //redirecciona a la vista index del controlador

            return RedirectToAction("Index", "Acceso");
        }

    }
}
