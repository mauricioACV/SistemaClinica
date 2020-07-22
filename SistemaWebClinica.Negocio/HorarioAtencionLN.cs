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

        public List<HorarioAtencion> ListarHorarioMedico(int id)
        {
            try
            {
                var ListadoHorarios = HorarioAtencionDAO.GetInstance().ListarHorarioMedico(id);
                return ListadoHorarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public HorarioAtencion AgregarHorario(HorarioAtencion objHorarioAtencion)
        {
            try
            {
                var HorarioAgregado = HorarioAtencionDAO.GetInstance().AgregarHorario(objHorarioAtencion);
                return HorarioAgregado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        

        public bool EliminarHorarioAtencion(int id)
        {
            try
            {
                var respuesta = HorarioAtencionDAO.GetInstance().EliminarHorarioAtencion(id);
                return respuesta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ActualizarHorarioAtencion(HorarioAtencion objHorarioAtencion)
        {
            try
            {
                var respuesta = HorarioAtencionDAO.GetInstance().ActualizarHorarioMedico(objHorarioAtencion);
                return respuesta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
