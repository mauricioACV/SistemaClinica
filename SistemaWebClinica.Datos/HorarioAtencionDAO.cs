using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Datos
{
    public class HorarioAtencionDAO
    {
        #region "Patron Singleton"
        private static HorarioAtencionDAO _horarioAtencion = null;
        private HorarioAtencionDAO() { }
        public static HorarioAtencionDAO GetInstance()
        {
            if (_horarioAtencion == null)
            {
                _horarioAtencion = new HorarioAtencionDAO();
            }
            return _horarioAtencion;
        }
        #endregion

        public List<HorarioAtencion> ListarHorarioPorFechaEspecialidad(int idEspecialidad, DateTime fecha)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<HorarioAtencion> listaHorariosPorFechaEspecialidad = null;

            try
            {
                var query = @"SELECT HA.idHorarioAtencion, HA.fecha, M.idMedico, E.nombres, H.idHora, H.hora
                            FROM HorarioAtencion HA
                            INNER JOIN Medico M ON (HA.idMedico = M.idMedico)
                            INNER JOIN Empleado E ON (M.idEmpleado = E.idEmpleado)
                            INNER JOIN Hora H ON (HA.idHoraInicio = H.idHora)
                            WHERE FORMAT (HA.fecha, 'dd-MM-yyyy 0:00:00') = '" + fecha + "' AND M.idEspecialidad = '" + idEspecialidad + "'";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();
                listaHorariosPorFechaEspecialidad = new List<HorarioAtencion>();

                while (dr.Read())
                {
                    HorarioAtencion objHorarios = new HorarioAtencion
                    {
                        IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Medico = new Medico()
                        {
                            IdMedico = Convert.ToInt32(dr["idMedico"].ToString()),
                            Nombre = dr["nombres"].ToString()
                        },
                        Hora = new Hora()
                        {
                            IdHora = Convert.ToInt32(dr["idHora"].ToString()),
                            HoraAtencion = dr["hora"].ToString()
                        }
                    };

                    listaHorariosPorFechaEspecialidad.Add(objHorarios);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaHorariosPorFechaEspecialidad;
        }

        public List<HorarioAtencion> ListarHorarioMedico(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<HorarioAtencion> listaHorarios = new List<HorarioAtencion>();

            try
            {
                var query = @"SELECT M.idMedico, HA.idHorarioAtencion, HA.fecha, H.Hora
                              FROM Medico M 
                              INNER JOIN HorarioAtencion HA ON (M.idMedico = HA.idMedico)
                              INNER JOIN Hora H ON (HA.idHoraInicio = H.idHora)
                              WHERE M.idMedico = '" + id + "' AND CONVERT(VARCHAR(10), HA.fecha, 103) >= CONVERT(VARCHAR(10), GETDATE(), 103) AND HA.estado=1";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    HorarioAtencion objHorarioAtencion = new HorarioAtencion
                    {
                        IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Hora = new Hora()
                        {
                            HoraAtencion = dr["hora"].ToString()
                        }
                    };

                    listaHorarios.Add(objHorarioAtencion);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaHorarios;
        }

        public HorarioAtencion AgregarHorario(HorarioAtencion objHorarioAtencion)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            HorarioAtencion objHorario = null;

            try
            {
                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand("spRegistrarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", objHorarioAtencion.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@prmHora", objHorarioAtencion.Hora.HoraAtencion);
                cmd.Parameters.AddWithValue("@prmFecha", objHorarioAtencion.Fecha);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objHorario = new HorarioAtencion()
                    {
                        IdHorarioAtencion = Convert.ToInt32(dr["idHorarioAtencion"].ToString()),
                        Fecha = Convert.ToDateTime(dr["fecha"].ToString()),
                        Hora = new Hora()
                        {
                            IdHora = Convert.ToInt32(dr["idHora"].ToString()),
                            HoraAtencion = dr["hora"].ToString()
                        },

                        Estado = Convert.ToBoolean(dr["estado"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objHorario;
        }

        public bool EliminarHorarioAtencion(int idHorarioAtencion)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool respuesta = false;

            try
            {
                var query = @"UPDATE HorarioAtencion
                              SET Estado = 0
                              WHERE idHorarioAtencion = '" + idHorarioAtencion + "' ";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);                
                conexion.Open();
                cmd.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public bool ActualizarHorarioMedico(HorarioAtencion objHorarioAtencion)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool respuesta = false;

            try
            {
                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand("spActualizarHorarioAtencion", conexion);
                cmd.Parameters.AddWithValue("@prmIdMedico", objHorarioAtencion.Medico.IdMedico);
                cmd.Parameters.AddWithValue("@prmIdHorario", objHorarioAtencion.IdHorarioAtencion);
                cmd.Parameters.AddWithValue("@prmFecha", objHorarioAtencion.Fecha);
                cmd.Parameters.AddWithValue("@prmHora", objHorarioAtencion.Hora.HoraAtencion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                cmd.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
    }
}
