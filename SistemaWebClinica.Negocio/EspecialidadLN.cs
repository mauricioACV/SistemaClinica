using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaWebClinica.Negocio
{
    public class EspecialidadLN
    {

        #region "Patron Singleton"
        private static EspecialidadLN _especialidadLN = null;
        private EspecialidadLN() { }
        public static EspecialidadLN GetInstance()
        {
            if (_especialidadLN == null)
            {
                _especialidadLN = new EspecialidadLN();
            }
            return _especialidadLN;
        }
        #endregion

        public List<Especialidad> ListarEspecialidad()
        {
            try
            {
                return EspecialidadDAO.GetInstance().ListarEspecialidad();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
