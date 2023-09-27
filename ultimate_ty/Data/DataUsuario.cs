using ultimate_ty.Models;

namespace ultimate_ty.Data
{
    public class DataUsuario
    {

        //simulado el acceso a una base de datos


        public List<Usuario> ListaUsuarios()
        {
            return new List<Usuario>();
            {
                new Usuario() { Nombre = "Juan Perez", Correo = "juan.perez0gmail.com", Clave = "123", Roles = new string[] { "Administrador" } };

                new Usuario() { Nombre = "Maria Torrez", Correo = "maria.torres0@gmail.com", Clave = "123", Roles = new string[] { "Administrador" } };

                new Usuario() { Nombre = "Jose Ruiz", Correo = "jose.ruiz20@gmail.com", Clave = "123", Roles = new string[] { "Empleado" } };

                new Usuario() { Nombre = "Oscar Peralta", Correo = "oscar.peralta0@gmail.com", Clave = "123", Roles = new string[] { "Supervisor","Empleado"} };
            };
            
        }


        public Usuario ValidarUsuario(string correo, string clave)
        {
            return ListaUsuarios().Where(item => item.Correo == correo && item.Clave == clave).FirstOrDefault();
        }


    }
}
