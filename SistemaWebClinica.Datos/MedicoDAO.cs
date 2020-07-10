using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Datos
{
    public class MedicoDAO
    {
        #region "Patron Singleton"
        private static MedicoDAO _medicoDAO = null;
        private MedicoDAO() { }
        public static MedicoDAO GetInstance()
        {
            if (_medicoDAO == null)
            {
                _medicoDAO = new MedicoDAO();
            }
            return _medicoDAO;
        }
        #endregion

        public Medico BuscarMedico(string rut)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Medico objMedico = null;
            SqlDataReader dr = null;

            try
            {
                var query = @"SELECT m.idMedico, e.idEmpleado, e.nombres, e.apPaterno, e.apMaterno, es.idEspecialidad, es.descripcion, m.estado AS estadoMedico 
                                FROM Medico m 
                                INNER JOIN Empleado e ON (m.idEmpleado = e.idEmpleado) 
                                INNER JOIN Especialidad es ON (m.idEspecialidad=es.idEspecialidad)
                                WHERE m.estado = 1 AND e.nroDocumento = '" + rut + "' ";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objMedico = new Medico()
                    {
                        IdMedico = Convert.ToInt32(dr["idMedico"].ToString()),
                        Id = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Especialidad = new Especialidad()
                        {
                            IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString()),
                            Descripcion = dr["descripcion"].ToString()
                        },
                        Estado = Convert.ToBoolean(dr["estadoMedico"].ToString())
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

            return objMedico;
        }

    }
}
