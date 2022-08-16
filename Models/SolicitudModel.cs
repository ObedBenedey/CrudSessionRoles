using System.ComponentModel.DataAnnotations;
namespace PAPELERIANGELESC.Models
{
    public class SolicitudModel
    {
        public int IdSolicitud { get; set; }
        public int IdRelReq { get; set; }
        public int EstatuSol { get; set; }
        public int IdRelSolDepartamento { get; set; }
        public String NombreE { get; set; }
        public String Comment { get; set; }
  
    }

}
