using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Negocio
{
    public class PacienteLN
    {
        #region "Patron Singleton"
        private static PacienteLN _pacienteLN = null;
        private PacienteLN() { }
        public static PacienteLN GetInstance()
        {
            if (_pacienteLN == null)
            {
                _pacienteLN = new PacienteLN();
            }
            return _pacienteLN;
        }
        #endregion

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            try
            {
                return PacienteDAO.GetInstance().RegistrarPaciente(objPaciente); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Paciente> ListarPacientes()
        {
            try
            {
                return PacienteDAO.GetInstance().ListarPacientes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ActualizarPaciente(Paciente objPaciente)
        {
            try
            {
                var operacionActualiza = PacienteDAO.GetInstance().ActualizarPaciente(objPaciente);
                return operacionActualiza;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
