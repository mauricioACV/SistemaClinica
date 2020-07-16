using SistemaWebClinica.Entidades;
using SistemaWebClinica.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Negocio
{
    public class HorarioAtencionLN
    {
        #region "Patron Singleton"
        private static HorarioAtencionLN _horarioAtencion = null;
        private HorarioAtencionLN() { }
        public static HorarioAtencionLN GetInstance()
        {
            if (_horarioAtencion == null)
            {
                _horarioAtencion = new HorarioAtencionLN();
            }
            return _horarioAtencion;
        }
        #endregion

        public HorarioAtencion AgregarHorario(HorarioAtencion objHorarioAtencion)
        {
            try
            {
                return HorarioAtencionDAO.GetInstance().AgregarHorario(objHorarioAtencion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
