using PAPELERIANGELESC.Models;

namespace PAPELERIANGELESC.Service
{
    public class UsuarioServiceImpl : UsuarioService
    {
        private List<Usuario> usuario; 
        public UsuarioServiceImpl()
        {
            usuario = new List<Usuario>
            {
                new Usuario
                {
                    NumeroEmpleado = "acc1",
                    Clave = "1231",
                },
                new Usuario
                {
                    NumeroEmpleado = "acc2",
                    Clave = "1232",
                },
                new Usuario
                {
                    NumeroEmpleado = "acc3",
                    Clave = "1233",
                }
            };
        }
        public Usuario Login(string NumeroEmpleado, string Clave)
        {
               return usuario.SingleOrDefault(a => a.NumeroEmpleado == NumeroEmpleado && a.Clave == Clave);
        }
    }
}
