using Microsoft.AspNetCore.Mvc;
using PAPELERIANGELESC.Datos;
using PAPELERIANGELESC.Models;
using System.Net.Mail;
using PAPELERIANGELESC.Permisos;
using Microsoft.AspNetCore.Authorization;

namespace PAPELERIANGELESC.Controllers
{

    public class MantenedorSolController : Controller
    {
        ReqDatos _ReqDatos = new ReqDatos();
        SolDatos _SolDatos = new SolDatos();
        public IActionResult listarSol()
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var empleado = ViewBag.NumeroEmpleado;
                var ocontacto = _SolDatos.Obtnrole(empleado);
                ViewBag.role = ocontacto.IdRoleRel;
                if (ocontacto.IdRoleRel == 2)
                {
                    var SolLista = _SolDatos.ListarSolAdmin(empleado);
                    return View(SolLista);
                }
                else if (ocontacto.IdRoleRel == 4)
                {
                    var SolLista = _SolDatos.ListarSolCompras();
                    return View(SolLista);
                }
                else
                {
                    var SolLista = _SolDatos.ListarSol(empleado);
                    return View(SolLista);
                }
            }
        }
        public IActionResult listarSolAdmin()
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            var empleado = ViewBag.NumeroEmpleado;
            var SolLista = _SolDatos.ListarSolAdmin(empleado);
            return View(SolLista);
        }

        public IActionResult GuardarSol()
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");

            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult GuardarSol(SolicitudModel oContacto)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var respuesta = _SolDatos.GuardarSol(oContacto);
                var resp = _SolDatos.IdSolGet();
                if (respuesta)
                    return RedirectToAction("Guardar", resp);
                return View();
            }
        }
        public IActionResult EliminarSol([FromBody] int path)
        {
            var IdSolicitud = path;
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            var respuesta = _SolDatos.EliminarSol(IdSolicitud);
            if (respuesta)
                return Json(new { success = false, responseText = "The attached file is not supported." });
            else
                return Json(new { success = true, responseText = "The attached file is not supported." });
        }
        public IActionResult Guardar(int IdSolicitudF)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarEstatus(int IdSolicitud)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var ocontacto = _SolDatos.ObtenerSol(IdSolicitud);
                return View(ocontacto);
            }
        }
        [HttpPost]
        public IActionResult EditarEstatus(SolicitudModel oContacto)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var respuesta = _SolDatos.EditarEstatus(oContacto);

                if (respuesta)
                    return RedirectToAction("ListarSol");
                else
                    return View();
            }
        }
        public IActionResult EditarEstatusAjax([FromBody] string path)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                char delimitador = ',';
                string[] valores = path.Split(delimitador);
                var IdSolicitud = valores[0];
                var Status = valores[1];
                var respuesta = _SolDatos.EditarEstatusAjax(IdSolicitud, Status);
                if (respuesta)
                    return Json(new {success = false, responseText = "The attached file is not supported."});
                else
                    return Json(new {success = false, responseText = "The attached file is not supported."});
            }
        }
        [HttpPost]
        public IActionResult GuardarMotivo(SolicitudModel oContacto)
        {
            ViewBag.NumeroEmpleado = HttpContext.Session.GetString("NumeroEmpleado");
            if (ViewBag.NumeroEmpleado == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var respuesta = _SolDatos.GuardarMotivo(oContacto);
                var SolLista = _SolDatos.ListarSolAdmin(ViewBag.NumeroEmpleado);
                if (respuesta)
                {
                    return RedirectToAction("ListarSol");
                }
                return RedirectToAction("ListarSol");
            }
        }
    }
}
