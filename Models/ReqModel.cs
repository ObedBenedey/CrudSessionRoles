using System.ComponentModel.DataAnnotations;
namespace PAPELERIANGELESC.Models
{
    public class ReqModel
    {
        public int IdReq { get; set; }
        [Required]
        public int IdSolicitante { get; set; }
        [Required]
        public int EKGRP { get; set; }
        [Required]
        public int Idepartamento { get; set; }
        [Required]
        public string BSART { get; set; }
        [Required]
        public string TXZ01 { get; set; }
        [Required]
        public string KNTTP { get; set; }
        [Required]
        public string Idmaterial { get; set; }
        [Required]
        public int MENGE { get; set; }
        [Required]
        public string MEINS_01 { get; set; }
        [Required]
        public string EEIND { get; set; }
        [Required]
        public string BADAT { get; set; }
        [Required]
        public string FRGDT { get; set; }
        [Required]
        public string LPEIN { get; set; }
        [Required]
        public string WAERS { get; set; }
        [Required]
        public int WERKS_01 { get; set; }
        [Required]
        public int Estatus { get; set; }
        [Required]
        public int SAKTO { get; set; }
        [Required]
        public int KOSTL { get; set; }
        [Required]
        public float PREIS { get; set; }
        [Required]
        public int Idproveedor { get; set; }
        [Required]
        public int IdSolicitudF { get; set; }
        [Required]
        public int PEINH { get; set; }
        [Required]
        public int BNFPO { get; set; }
        public int CHEK { get; set; }

        public string Destinatario { get; set; }


    }
}
