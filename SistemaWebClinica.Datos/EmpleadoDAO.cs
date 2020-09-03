using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Datos
{
    public class EmpleadoDAO
    {
        #region "Patron Singleton"
        private static EmpleadoDAO _empleadoDAO = null;
        private EmpleadoDAO() { }
        public static EmpleadoDAO GetInstance()
        {
            if (_empleadoDAO == null)
            {
                _empleadoDAO = new EmpleadoDAO();
            }
            return _empleadoDAO;
        }

        #endregion

        public Empleado AccesoSistema(string user, string password)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand("spAccesoSistema", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", password);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objEmpleado = new Empleado
                    {
                        Id = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Usuario = dr["usuario"].ToString(),
                        Clave = dr["clave"].ToString(),
                        Nombre = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objEmpleado;
        }
    }
}
