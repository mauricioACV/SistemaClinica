using SistemaWebClinica.Datos;
using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Negocio
{
    public class EmpleadoLN
    {
        #region "Patron Singleton"
        private static EmpleadoLN _empleadoLN = null;
        private EmpleadoLN() { }
        public static EmpleadoLN GetInstance()
        {
            if (_empleadoLN == null)
            {
                _empleadoLN = new EmpleadoLN();
            }
            return _empleadoLN;
        }

        #endregion

        public Empleado AccesoSistema(string user, string password)
        {
            try
            {
                return EmpleadoDAO.GetInstance().AccesoSistema(user, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
