using PAPELERIANGELESC.Models;
using System.Data.SqlClient;
using System.Data;

namespace PAPELERIANGELESC.Datos
{
    public class SolDatos
    {
        public List<SolicitudModel> ListarSol(string empleado)
        {

            var oLista = new List<SolicitudModel>();

            var cnn = new ConexionSol();

            using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
            {
                ConexionSol.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSol", ConexionSol);
                cmd.Parameters.AddWithValue("IdRelReq", empleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new SolicitudModel()
                        {
                            IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]),
                            IdRelReq = Convert.ToInt32(dr["IdRelReq"]),
                            EstatuSol = Convert.ToInt32(dr["EstatuSol"]),
                             NombreE = dr["NombreE"].ToString(),
                             Comment = dr["Comment"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }
        public List<SolicitudModel> ListarSolAdmin(string empleado)
        {

            var oLista = new List<SolicitudModel>();

            var cnn = new ConexionSol();

            using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
            {
                ConexionSol.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSolAdmin", ConexionSol); 
                cmd.Parameters.AddWithValue("IdUsRel", empleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SolicitudModel()
                        {
                            IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]),
                            IdRelReq = Convert.ToInt32(dr["IdRelReq"]),
                            EstatuSol = Convert.ToInt32(dr["EstatuSol"]),
                             NombreE = dr["NombreE"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }
        public List<SolicitudModel> ListarSolCompras()
        {
            var oLista = new List<SolicitudModel>();
            var cnn = new ConexionSol();
            using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
            {
                ConexionSol.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSolCompras", ConexionSol);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SolicitudModel()
                        {
                            IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]),
                            IdRelReq = Convert.ToInt32(dr["IdRelReq"]),
                            EstatuSol = Convert.ToInt32(dr["EstatuSol"]),
                            NombreE = dr["NombreE"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }

        public SolicitudModel ObtenerSol(int Idsolicitud)
        {

            var oContactoO = new SolicitudModel();

            var cnn = new ConexionSol();

            using (var conexion = new SqlConnection(cnn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSol", conexion);
                cmd.Parameters.AddWithValue("Idsolicitud", Idsolicitud);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContactoO.IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]);
                        oContactoO.IdRelReq = Convert.ToInt32(dr["IdRelReq"]);
                        oContactoO.EstatuSol = Convert.ToInt32(dr["EstatuSol"]);
     
                    }
                }
            }

            return oContactoO;
        }
        public Usuario Obtnrole(string NumeroEmpleado)
        {
            
            var oContactoO = new Usuario();

            var cnn = new ConexionSol();

            using (var conexion = new SqlConnection(cnn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtnrole", conexion);
                cmd.Parameters.AddWithValue("NumeroEmpleado", NumeroEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContactoO.IdRoleRel = Convert.ToInt32(dr["IdRoleRel"]);
                        

                    }
                }
            }

            return oContactoO;
        }

        internal object EditarEstatus(ReqModel oContacto)
        {
            throw new NotImplementedException();
        }

        public bool EditarEstatus(SolicitudModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarEstatus", conexion);
                    cmd.Parameters.AddWithValue("@Idsolicitud", ocontacto.IdSolicitud);
                    cmd.Parameters.AddWithValue("@EstatuSol", ocontacto.EstatuSol);
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

        public bool GuardarSol(SolicitudModel ocontacto)
        {
            bool rpta;
            var oLista = new List<SolicitudModel>();
            try
            {
                var cnn = new ConexionSol();

                using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
                {
                    ConexionSol.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarSol", ConexionSol);
                    cmd.Parameters.AddWithValue("IdRelReq", ocontacto.IdRelReq);
                    cmd.Parameters.AddWithValue("EstatuSol", ocontacto.EstatuSol);
                    cmd.Parameters.AddWithValue("IdRelSolDepartamento", ocontacto.IdRelSolDepartamento);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                rpta = true;
            }
                }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool GuardarMotivo(SolicitudModel ocontacto)
        {
            bool rpta;
            var oLista = new List<SolicitudModel>();
            try
            {
                var cnn = new ConexionSol();

                using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
                {
                    ConexionSol.Open();
                    SqlCommand cmd = new SqlCommand("sp_Motivo", ConexionSol);
                    cmd.Parameters.AddWithValue("Idsolicitud", ocontacto.IdSolicitud);
                    cmd.Parameters.AddWithValue("Comment", ocontacto.Comment);
           
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool EliminarSol(int IdSolicitud)
        {
            bool rpta;

            try
            {
                var cnn = new ConexionSol();

                using (var ConexionSol = new SqlConnection(cnn.getCadenaSQL()))
                {
                    ConexionSol.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarSol", ConexionSol);
                    cmd.Parameters.AddWithValue("IdSolicitud", IdSolicitud);
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
        public SolicitudModel IdSolGet()
        {
            var oContacto = new SolicitudModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_IdSol", conexion);
                
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]);

                    }
                }
            }

            return oContacto;
        }
        public bool EditarEstatusAjax(string IdSolicitud,string EstatuSol)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarEstatus", conexion);
                    cmd.Parameters.AddWithValue("@Idsolicitud", IdSolicitud);
                    cmd.Parameters.AddWithValue("@EstatuSol", EstatuSol);
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
        public SolicitudModel ObtenerSoli()
        {

            var oContactoO = new SolicitudModel();

            var cnn = new ConexionSol();

            using (var conexion = new SqlConnection(cnn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSoli", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContactoO.IdSolicitud = Convert.ToInt32(dr["IdSolicitud"]);
                    }
                }
            }

            return oContactoO;
        }

    }
}
