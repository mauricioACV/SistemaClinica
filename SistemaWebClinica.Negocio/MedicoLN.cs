using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Negocio
{
    public class MedicoLN
    {
        #region "Patron Singleton"
        private static MedicoLN _medicoLN = null;
        private MedicoLN() { }
        public static MedicoLN GetInstance()
        {
            if (_medicoLN == null)
            {
                _medicoLN = new MedicoLN();
            }
            return _medicoLN;
        }
        #endregion

        public Medico BuscarMedico(string rut)
        {
            try
            {
                return MedicoDAO.GetInstance().BuscarMedico(rut);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
