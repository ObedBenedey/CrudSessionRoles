using Microsoft.AspNetCore.Mvc;
using PAPELERIANGELESC.Service;
using PAPELERIANGELESC.Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Linq;

namespace PAPELERIANGELESC.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        static string cadena = "Data Source=(local);Initial Catalog=DBPAPELERIA;Integrated Security=true";
        private UsuarioService usuarioService;
        public AccountController(UsuarioService _usuarioService)
        {
            usuarioService = _usuarioService;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(Usuario oUsuario)
        {
    
            oUsuario.Clave = ConvertirSha256(oUsuario.Clave);

            using (SqlConnection cn = new SqlConnection(cadena))
            {

                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("NumeroEmpleado", oUsuario.NumeroEmpleado);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
  
            if (oUsuario.IdUsuario != 0)
            {
                HttpContext.Session.SetString("NumeroEmpleado", oUsuario.NumeroEmpleado);
                return RedirectToAction("listarSol", "MantenedorSol");
            }
            else
            {
                ViewBag.msg = "Invalid";
                return View("Index");
            }
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            return View("Welcome");
        }



        [Route("logout")]
        public IActionResult Logout()
        {
          HttpContext.Session.Remove("NumeroEmpleado");
            return RedirectToAction("Index");
        }

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}
