using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Datos
{
    public class PacienteDAO
    {
        #region "Patron Singleton"
        private static PacienteDAO _pacienteDAO = null;
        private PacienteDAO() { }
        public static PacienteDAO GetInstance()
        {
            if (_pacienteDAO == null)
            {
                _pacienteDAO = new PacienteDAO();
            }
            return _pacienteDAO;
        }
        #endregion

        public List<Paciente> ListarPacientes()
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Paciente> lista = new List<Paciente>();

            try
            {
                var query = @"SELECT p.idPaciente,p.nombres,p.apPaterno,p.apMaterno,p.edad,p.sexo,p.nroDocumento,p.direccion, p.telefono,p.estado
                               FROM Paciente p WHERE p.estado=1";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();
                

                while (dr.Read())
                {
                    Paciente objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString()),
                        Nombres = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Edad = Convert.ToInt32(dr["edad"].ToString()),
                        Sexo = Convert.ToChar(dr["sexo"].ToString()),
                        NroDocumento = dr["nroDocumento"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Estado = true
                    };

                    lista.Add(objPaciente);
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
            return lista;
        }

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                var query = @"INSERT INTO Paciente 
                        (nombres, apPaterno, apMaterno, edad, sexo, nroDocumento, direccion, telefono, estado)
                        VALUES 
                        ('" + objPaciente.Nombres + "','" + objPaciente.ApPaterno + "','" + objPaciente.ApMaterno + "'," +
                        "'" + objPaciente.Edad + "','" + objPaciente.Sexo + "','" + objPaciente.NroDocumento + "'," +
                        "'" + objPaciente.Direccion + "','" + objPaciente.Telefono + "','" + objPaciente.Estado + "')";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }

        public bool EliminarPaciente(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                var query = @"DELETE from Paciente WHERE idPaciente='" + id + "' ";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return response;
        }

        public bool ActualizarPaciente(Paciente objPaciente)
        {
            bool response = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                var query = @"UPDATE Paciente SET direccion='" + objPaciente.Direccion + "' WHERE idPaciente='" + objPaciente.IdPaciente + "'";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }

        public Paciente BuscarPacientePorDni(string dni)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Paciente objPaciente = null;

            try
            {
                var query = @"SELECT p.idPaciente,p.nombres,p.apPaterno,p.apMaterno,p.edad,p.sexo,p.nroDocumento,p.direccion, p.telefono,p.estado
                               FROM Paciente p WHERE p.nroDocumento = '" + dni + "' ";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                        Nombres = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Edad = Convert.ToInt32(dr["edad"].ToString()),
                        Sexo = Convert.ToChar(dr["sexo"].ToString())
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

            return objPaciente;
        }

        public Paciente BuscarPacientePorId(int idPaciente)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Paciente objPaciente = null;

            try
            {
                var query = @"SELECT p.idPaciente,p.nombres,p.apPaterno,p.apMaterno,p.edad,p.sexo,p.nroDocumento,p.direccion, p.telefono,p.estado
                               FROM Paciente p WHERE p.idPaciente = '" + idPaciente + "' ";

                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand(query, conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                        Nombres = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Edad = Convert.ToInt32(dr["edad"].ToString()),
                        Sexo = Convert.ToChar(dr["sexo"].ToString())
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

            return objPaciente;
        }

    }
}
