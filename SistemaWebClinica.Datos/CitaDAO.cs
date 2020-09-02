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
    public class CitaDAO
    {
        #region "Patron Singleton"
        private static CitaDAO _citaDAO = null;
        private CitaDAO() { }
        public static CitaDAO GetInstance()
        {
            if (_citaDAO == null)
            {
                _citaDAO = new CitaDAO();
            }
            return _citaDAO;
        }
        #endregion

        public bool RegistrarCitaPaciente(Cita objCita)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool respuesta = false;
            DateTime date = objCita.FechaReserva;
            string dateFormatted = date.ToString("yyyy-MM-dd");

            try
            {
                var query = @"INSERT INTO Cita 
                        (idMedico, idPaciente, fechaReserva, hora, estado)
                        VALUES 
                        ('" + objCita.Medico.IdMedico + "','" + objCita.Paciente.IdPaciente + "','" + dateFormatted + "'," +
                        "'" + objCita.Hora + "', 'p')";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { respuesta = true; }
            }
            catch (Exception ex)
            {
                respuesta = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public List<Cita> ListarCitas()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Cita> ListaCitas = new List<Cita>();

            try
            {
                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand("spListarCitas", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cita cita = new Cita()
                    {
                        IdCita = Convert.ToInt32(dr["idCita"].ToString()),
                        FechaReserva = Convert.ToDateTime(dr["fechaReserva"].ToString()),
                        Hora = dr["hora"].ToString(),
                        Medico = new Medico()
                        {
                            IdMedico = Convert.ToInt32(dr["idCita"].ToString())
                        },
                        Paciente = new Paciente()
                        {
                            IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString()),
                            Nombres = dr["nombres"].ToString(),
                            ApPaterno = dr["apPaterno"].ToString(),
                            ApMaterno = dr["apMaterno"].ToString(),
                            Edad = Convert.ToInt32(dr["edad"].ToString()),
                            Sexo = Convert.ToChar(dr["sexo"].ToString()),
                            NroDocumento = dr["nroDocumento"].ToString(),
                            Direccion = dr["direccion"].ToString()
                        }
                    };

                    ListaCitas.Add(cita);
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
            return ListaCitas;
        }
    }
}
