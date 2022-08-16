using PAPELERIANGELESC.Models;

namespace PAPELERIANGELESC.Service
{
    public interface UsuarioService
    {
        public Usuario Login(string NumeroEmpleado, string Clave);
    }
}
