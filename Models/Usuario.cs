using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PAPELERIANGELESC.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }
        public int IdRoleRel { get; set; }
        public int IdUsRel { get; set; }
        public string NumeroEmpleado { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }

    }
}