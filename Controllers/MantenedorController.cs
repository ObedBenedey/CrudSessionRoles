using Microsoft.AspNetCore.Mvc;
using PAPELERIANGELESC.Datos;
using PAPELERIANGELESC.Models;
using System.Net.Mail;

namespace PAPELERIANGELESC.Controllers
{
    public class MantenedorController : Controller
    {
        ReqDatos _ReqDatos = new ReqDatos();
        SolDatos _SolDatos = new SolDatos();
        public IActionResult Listar(int IdSolicitudF)
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
 
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            var empleado = ViewBag.NumeroEmpleado;
            var ocontacto = _SolDatos.Obtnrole(empleado);
            ViewBag.role = ocontacto.IdRoleRel;
            var oLista = _ReqDatos.Listar(IdSolicitudF);

            return View(oLista);
        }
        public IActionResult ListarAdmin()
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _ReqDatos.ListarAdmin();

            return View(oLista);
        }

        public IActionResult Guardar(int IdSolicitudF)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");

            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ReqModel oContacto)
        {
          
            //METODO RECI1BE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid) { 
                ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            return View();
            }

            var respuesta = _ReqDatos.Guardar(oContacto);


            if (respuesta)
                return RedirectToAction("Listar", new { IdSolicitudF = oContacto.IdSolicitudF });
            else
                ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            return View();
        }

        public IActionResult Editar(int IdReq)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var ocontacto = _ReqDatos.Obtener(IdReq);
                return View(ocontacto);
            }
        }
  
        [HttpPost]
        public IActionResult Editar(ReqModel oContacto)
        {

            var respuesta = _ReqDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar", new { IdSolicitudF = oContacto.IdSolicitudF });
            else
                return View();
        }

        public IActionResult Eliminar(int IdReq)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var ocontacto = _ReqDatos.Obtener(IdReq);
                return View(ocontacto);
            }
        }

        [HttpPost]
        public IActionResult Eliminar(ReqModel oContacto)
        {

            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var respuesta = _ReqDatos.Eliminar(oContacto.IdReq);


                if (respuesta)
                    return RedirectToAction("Listar", new { IdSolicitudF = oContacto.IdSolicitudF });
                else
                    return View();
            }
        }
        public IActionResult EmailProv(ReqModel oContacto)
        {
            var ocontacto = _ReqDatos.Obtener(oContacto.IdReq)
            string EmailOrigen = "obed.rdgz14@gmail.com";
            string EmailDestino = oContacto.Destinatario;
            string Contraseña = "imfutwyppbqrnphj";
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Hospital Angeles", "<img  src='https://angeleschihuahua.com/wp-content/uploads/2020/09/logo-angeles-1024x673.png' height='55' width='90' alt='Responsive image'>" + "<h2>Buen Dia, aprovecho para mandarle requerimientos de " + ocontacto.Idmaterial + " para cotización.</h2>" + "<br/>" + "<h2>" + ocontacto.TXZ01 + "</h2>" + "<br/>" + "<h2> De antemano muchas gracias, quedo pendiente de respuesta.</h2>");
            oMailMessage.IsBodyHtml = true;
            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Host = "smtp.gmail.com";
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();

            return RedirectToAction("Listar", new { IdSolicitudF = ocontacto.IdSolicitudF, EmailView = 1 });
        }
        public IActionResult ChangeCheck([FromBody] int path)
        {
            var IdReq = path;
            var ocontacto = _ReqDatos.Chenge(IdReq );
            if (ocontacto is null)
            {
                return NotFound();
            }
            return Ok("success");
        }

    }
}
