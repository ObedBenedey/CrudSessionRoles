using PAPELERIANGELESC.Models;
using System.Data.SqlClient;
using System.Data;
namespace PAPELERIANGELESC.Datos
{
    public class ReqDatos
    {
        public List<ReqModel> Listar(int IdSolicitudF)
        {
            var oLista = new List<ReqModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.Parameters.AddWithValue("IdSolicitudF", IdSolicitudF);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ReqModel()
                        {
                            IdReq = Convert.ToInt32(dr["IdReq"]),
                            IdSolicitante = Convert.ToInt32(dr["IdSolicitante"]),
                            EKGRP = Convert.ToInt32(dr["EKGRP"]),
                            Idepartamento = Convert.ToInt32(dr["Idepartamento"]),
                            BSART = dr["BSART"].ToString(),
                            TXZ01 = dr["TXZ01"].ToString(),
                            WAERS = dr["WAERS"].ToString(),
                            KNTTP = dr["KNTTP"].ToString(),
                            Idmaterial = dr["MATKL"].ToString(),
                            MENGE = Convert.ToInt32(dr["MENGE"]),
                            MEINS_01 = dr["MEINS_01"].ToString(),
                            EEIND = dr["EEIND"].ToString(),
                            BADAT = dr["BADAT"].ToString(),
                            FRGDT = dr["FRGDT"].ToString(),
                            LPEIN = dr["LPEIN"].ToString(),
                            WERKS_01 = Convert.ToInt32(dr["WERKS_01"]),
                            Estatus = Convert.ToInt32(dr["Estatus"]),
                            SAKTO = Convert.ToInt32(dr["SAKTO"]),
                            KOSTL = Convert.ToInt32(dr["KOSTL"]),
                            PREIS = Convert.ToInt32(dr["PREIS"]),
                            Idproveedor = Convert.ToInt32(dr["Idproveedor"]),
                            IdSolicitudF = Convert.ToInt32(dr["IdSolicitudF"]),
                            PEINH = Convert.ToInt32(dr["PEINH"]),
                            BNFPO = Convert.ToInt32(dr["BNFPO"]),
                            CHEK = Convert.ToInt32(dr["CHEK"])
                        });

                    }
                }
            }

            return oLista;
        }
        public List<ReqModel> ListarAdmin()
        {

            var oLista = new List<ReqModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAdmin", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ReqModel()
                        {
                            IdReq = Convert.ToInt32(dr["IdReq"]),
                            IdSolicitante = Convert.ToInt32(dr["IdSolicitante"]),
                            EKGRP = Convert.ToInt32(dr["EKGRP"]),
                            Idepartamento = Convert.ToInt32(dr["Idepartamento"]),
                            BSART = dr["BSART"].ToString(),
                            TXZ01 = dr["TXZ01"].ToString(),
                            WAERS = dr["WAERS"].ToString(),
                            KNTTP = dr["KNTTP"].ToString(),
                            Idmaterial = dr["MATKL"].ToString(),
                            MENGE = Convert.ToInt32(dr["MENGE"]),
                            MEINS_01 = dr["MEINS_01"].ToString(),
                            BADAT = dr["BADAT"].ToString(),
                            EEIND = dr["EEIND"].ToString(),
                            FRGDT = dr["FRGDT"].ToString(),
                            LPEIN = dr["LPEIN"].ToString(),
                            WERKS_01 = Convert.ToInt32(dr["WERKS_01"]),
                            Estatus = Convert.ToInt32(dr["Estatus"]),
                            SAKTO = Convert.ToInt32(dr["SAKTO"]),
                            KOSTL = Convert.ToInt32(dr["KOSTL"]),
                            PREIS = Convert.ToInt32(dr["PREIS"]),
                            Idproveedor = Convert.ToInt32(dr["Idproveedor"]),
                            IdSolicitudF = Convert.ToInt32(dr["IdSolicitudF"]),
                            PEINH = Convert.ToInt32(dr["PEINH"]),
                            BNFPO = Convert.ToInt32(dr["BNFPO"]),
                            CHEK = Convert.ToInt32(dr["CHEK"])
                        });

                    }
                }
            }

            return oLista;
        }
        public ReqModel Obtener(int IdReq)
        {
            var oContacto = new ReqModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdReq", IdReq);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.IdReq = Convert.ToInt32(dr["IdReq"]);
                        oContacto.IdSolicitante = Convert.ToInt32(dr["IdSolicitante"]);
                        oContacto.EKGRP = Convert.ToInt32(dr["EKGRP"]);
                        oContacto.Idepartamento = Convert.ToInt32(dr["Idepartamento"]);
                        oContacto.BSART = dr["BSART"].ToString();
                        oContacto.TXZ01 = dr["TXZ01"].ToString();
                        oContacto.WAERS = dr["WAERS"].ToString();
                        oContacto.KNTTP = dr["KNTTP"].ToString();
                        oContacto.Idmaterial = dr["MATKL"].ToString();
                        oContacto.MENGE = Convert.ToInt32(dr["MENGE"]);
                        oContacto.MEINS_01 = dr["MEINS_01"].ToString();
                        oContacto.EEIND = dr["EEIND"].ToString();
                        oContacto.BADAT = dr["BADAT"].ToString();
                        oContacto.FRGDT = dr["FRGDT"].ToString();
                        oContacto.LPEIN = dr["LPEIN"].ToString();
                        oContacto.WERKS_01 = Convert.ToInt32(dr["WERKS_01"]);
                        oContacto.Estatus = Convert.ToInt32(dr["Estatus"]);
                        oContacto.SAKTO = Convert.ToInt32(dr["SAKTO"]);
                        oContacto.KOSTL = Convert.ToInt32(dr["KOSTL"]);
                        oContacto.PREIS = Convert.ToInt32(dr["PREIS"]);
                        oContacto.Idproveedor = Convert.ToInt32(dr["Idproveedor"]);
                        oContacto.IdSolicitudF = Convert.ToInt32(dr["IdSolicitudF"]);
                        oContacto.PEINH = Convert.ToInt32(dr["PEINH"]);
                        oContacto.BNFPO = Convert.ToInt32(dr["BNFPO"]);
                        oContacto.CHEK = Convert.ToInt32(dr["CHEK"]);
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ReqModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardare", conexion);
                    cmd.Parameters.AddWithValue("IdSolicitante", ocontacto.IdSolicitante);
                    cmd.Parameters.AddWithValue("EKGRP", ocontacto.EKGRP);
                    cmd.Parameters.AddWithValue("Idepartamento", ocontacto.Idepartamento);
                    cmd.Parameters.AddWithValue("BSART", ocontacto.BSART);
                    cmd.Parameters.AddWithValue("TXZ01", ocontacto.TXZ01);
                    cmd.Parameters.AddWithValue("WAERS", ocontacto.WAERS);
                    cmd.Parameters.AddWithValue("KNTTP", ocontacto.KNTTP);
                    cmd.Parameters.AddWithValue("Idmaterial", ocontacto.Idmaterial);
                    cmd.Parameters.AddWithValue("MENGE", ocontacto.MENGE);
                    cmd.Parameters.AddWithValue("MEINS_01", ocontacto.MEINS_01);
                    cmd.Parameters.AddWithValue("EEIND", ocontacto.EEIND);
                    cmd.Parameters.AddWithValue("BADAT", ocontacto.BADAT);
                    cmd.Parameters.AddWithValue("FRGDT", ocontacto.FRGDT);
                    cmd.Parameters.AddWithValue("LPEIN", ocontacto.LPEIN);
                    cmd.Parameters.AddWithValue("WERKS_01", ocontacto.WERKS_01);
                    cmd.Parameters.AddWithValue("Estatus", ocontacto.Estatus);
                    cmd.Parameters.AddWithValue("SAKTO", ocontacto.SAKTO);
                    cmd.Parameters.AddWithValue("KOSTL", ocontacto.KOSTL);
                    cmd.Parameters.AddWithValue("PREIS", ocontacto.PREIS);
                    cmd.Parameters.AddWithValue("Idproveedor", ocontacto.Idproveedor);
                    cmd.Parameters.AddWithValue("IdSolicitudF", ocontacto.IdSolicitudF);
                    cmd.Parameters.AddWithValue("PEINH", ocontacto.PEINH);
                    cmd.Parameters.AddWithValue("BNFPO", ocontacto.BNFPO);
                    cmd.Parameters.AddWithValue("CHEK", 1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(ReqModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdReq", ocontacto.IdReq);
                    cmd.Parameters.AddWithValue("IdSolicitante", ocontacto.IdSolicitante);
                    cmd.Parameters.AddWithValue("EKGRP", ocontacto.EKGRP);
                    cmd.Parameters.AddWithValue("Idepartamento", ocontacto.Idepartamento);
                    cmd.Parameters.AddWithValue("BSART", ocontacto.BSART);
                    cmd.Parameters.AddWithValue("TXZ01", ocontacto.TXZ01);
                    cmd.Parameters.AddWithValue("WAERS", ocontacto.WAERS);
                    cmd.Parameters.AddWithValue("KNTTP", ocontacto.KNTTP);
                    cmd.Parameters.AddWithValue("Idmaterial", ocontacto.Idmaterial);
                    cmd.Parameters.AddWithValue("MENGE", ocontacto.MENGE);
                    cmd.Parameters.AddWithValue("MEINS_01", ocontacto.MEINS_01);
                    cmd.Parameters.AddWithValue("EEIND", ocontacto.EEIND);
                    cmd.Parameters.AddWithValue("FRGDT", ocontacto.FRGDT);
                    cmd.Parameters.AddWithValue("BADAT", ocontacto.BADAT);
                    cmd.Parameters.AddWithValue("LPEIN", ocontacto.LPEIN);
                    cmd.Parameters.AddWithValue("WERKS_01", ocontacto.WERKS_01);
                    cmd.Parameters.AddWithValue("Estatus", ocontacto.Estatus);
                    cmd.Parameters.AddWithValue("SAKTO", ocontacto.SAKTO);
                    cmd.Parameters.AddWithValue("KOSTL", ocontacto.KOSTL);
                    cmd.Parameters.AddWithValue("PREIS", ocontacto.PREIS);
                    cmd.Parameters.AddWithValue("Idproveedor", ocontacto.Idproveedor);
                    cmd.Parameters.AddWithValue("IdSolicitudF", ocontacto.IdSolicitudF);
                    cmd.Parameters.AddWithValue("PEINH", ocontacto.PEINH);
                    cmd.Parameters.AddWithValue("BNFPO", ocontacto.BNFPO);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdReq)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdReq", IdReq);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public ReqModel Chenge(int IdReq)
        {
            var oContactoO = new ReqModel();
            var cnn = new ConexionSol();
            using (var conexion = new SqlConnection(cnn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Change", conexion);
                cmd.Parameters.AddWithValue("IdReq", IdReq);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContactoO.IdSolicitudF = Convert.ToInt32(dr["IdSolicitudF"]);
                    }
                }
            }
            return oContactoO;
        }
    }
}
