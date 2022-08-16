using Microsoft.AspNetCore.Mvc;
using PAPELERIANGELESC.Models;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

namespace PAPELERIANGELESC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string CadenaSQL;

        public HomeController(IConfiguration config)
        {
            CadenaSQL = config.GetConnectionString("CadenaSQL"); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Exportar_Excel(int IdSolicitud)
        {
            DataTable tabla_cliente = new DataTable();

            //=========== PRIMERO - OBTENER EL DATA ADAPTER ===========
            using (var conexion = new SqlConnection(CadenaSQL))
            {
                conexion.Open();
                using (var adapter = new SqlDataAdapter())
                {

                    adapter.SelectCommand = new SqlCommand("sp_reporte_REQ", conexion);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@IdSolicitud", IdSolicitud);
                    adapter.Fill(tabla_cliente);
                }
            }
            using (var libro = new XLWorkbook())
            {
                tabla_cliente.TableName = "Posiciones";
                var hoja = libro.Worksheets.Add(tabla_cliente);
                hoja.ColumnsUsed().AdjustToContents();
                using (var memoria = new MemoryStream())
                {
                    libro.SaveAs(memoria);
                    var nombreExcel = string.Concat("Reporte ", DateTime.Now.ToString(), ".xlsx");
                    return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
                }

            }
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
        public ActionResult CerrarSesion()
        {
           // Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }

    }
}