using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Negocio
{
    public class CitaLN
    {
        #region "Patron Singleton"
        private static CitaLN _citaLN = null;
        private CitaLN() { }
        public static CitaLN GetInstance()
        {
            if (_citaLN == null)
            {
                _citaLN = new CitaLN();
            }
            return _citaLN;
        }
        #endregion

        public bool RegistrarCitaPaciente(Cita objCita)
        {
            try
            {
                return CitaDAO.GetInstance().RegistrarCitaPaciente(objCita); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Cita> LitarCitas()
        {
            try
            {
                return CitaDAO.GetInstance().ListarCitas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarCita(int idCita, string estado)
        {
            try
            {
                return CitaDAO.GetInstance().ActualizarCita(idCita, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
