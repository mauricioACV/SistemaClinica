using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;

namespace SistemaWebClinica.Negocio
{
    public class DiagnosticoLN
    {
        #region "Patron Singleton"
        private static DiagnosticoLN _diagnosticoLN = null;
        private DiagnosticoLN() { }
        public static DiagnosticoLN GetInstance()
        {
            if (_diagnosticoLN == null)
            {
                _diagnosticoLN = new DiagnosticoLN();
            }
            return _diagnosticoLN;
        }
        #endregion

        public bool RegistrarDiagnosticoPaciente(Diagnostico objDiagnostico)
        {
            try
            {
                return DiagnosticoDAO.GetInstance().RegistrarDiagnosticoPaciente(objDiagnostico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
