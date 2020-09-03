using SistemaWebClinica.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaWebClinica.Datos
{
    public class DiagnosticoDAO
    {
        #region "Patron Singleton"
        private static DiagnosticoDAO _diagnosticoDAO = null;
        private DiagnosticoDAO() { }
        public static DiagnosticoDAO GetInstance()
        {
            if (_diagnosticoDAO == null)
            {
                _diagnosticoDAO = new DiagnosticoDAO();
            }
            return _diagnosticoDAO;
        }
        #endregion

        public bool RegistrarDiagnosticoPaciente(Diagnostico objDiagnostico)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool respuesta = false;

            try
            {
                conexion = Conexion.GetInstance().ConexionBd();
                cmd = new SqlCommand("spRegistrarDiagnostico", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmIdPaciente",objDiagnostico.HistoriaClinica.Paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@prmObservacion", objDiagnostico.Observacion);
                cmd.Parameters.AddWithValue("@prmDiagnostico", objDiagnostico.DiagnosticoText);

                conexion.Open();
                cmd.ExecuteNonQuery();
                respuesta = true;
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

    }
}
