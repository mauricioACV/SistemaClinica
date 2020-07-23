using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SistemaWebClinica.Datos
{
    public class EspecialidadDAO
    {

        #region "Patron Singleton"
        private static EspecialidadDAO _especialidadDAO = null;
        private EspecialidadDAO() { }
        public static EspecialidadDAO GetInstance()
        {
            if (_especialidadDAO == null)
            {
                _especialidadDAO = new EspecialidadDAO();
            }
            return _especialidadDAO;
        }
        #endregion

        public List<Especialidad> ListarEspecialidad()
        { 

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Especialidad> listaEspecialidad = null;

            try
            {
                var query = @"SELECT E.idEspecialidad, E.descripcion
                              FROM Especialidad E
                              WHERE E.estado = 1";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();
                listaEspecialidad = new List<Especialidad>();

                while (dr.Read())
                {
                    Especialidad objEspecialidad = new Especialidad()
                    {
                        IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString()),
                        Descripcion = dr["descripcion"].ToString()
                    };
                    listaEspecialidad.Add(objEspecialidad);
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

            return listaEspecialidad;
        }
    }
}
