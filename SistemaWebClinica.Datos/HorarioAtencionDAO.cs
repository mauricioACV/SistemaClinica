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
    }
}
