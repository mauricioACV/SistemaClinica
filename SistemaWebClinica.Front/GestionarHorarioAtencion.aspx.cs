using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace SistemaWebClinica.Front
{
    public partial class GestionarHorarioAtencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Medico BuscarMedico(string rut)
        {
            return MedicoLN.GetInstance().BuscarMedico(rut);
        }

        [WebMethod]
        public static HorarioAtencion AgregarHorario(string fecha, string hora, string idMedico)
        {
            HorarioAtencion objHorarioAtencion = new HorarioAtencion()
            {
                Fecha = Convert.ToDateTime(fecha),
                Hora = new Hora()
                {
                    HoraAtencion = hora
                },
                Medico = new Medico()
                {
                    IdMedico = Convert.ToInt32(idMedico)
                }
            };

            var operacionAgregar = HorarioAtencionLN.GetInstance().AgregarHorario(objHorarioAtencion);

            return operacionAgregar;
        }

        [WebMethod]
        public static List<HorarioAtencion> ListarHorarioMedico(string idMedico)
        {
            int id = Convert.ToInt32(idMedico);
            List<HorarioAtencion> ListaHorarios = null;

            try
            {
                
                ListaHorarios = HorarioAtencionLN.GetInstance().ListarHorarioMedico(id); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListaHorarios;
        }

        [WebMethod]
        public static bool EliminarHorarioAtencion(string id)
        {
            int idHorario = Convert.ToInt32(id);

            var respuesta = HorarioAtencionLN.GetInstance().EliminarHorarioAtencion(idHorario);

            return respuesta;
        }

        [WebMethod]
        public static bool ActualizarHorarioAtencion(string idMedico, string idHorario, string fecha, string hora)
        {
             int _idMedico = Convert.ToInt32(idMedico);
             int _idHorario = Convert.ToInt32(idHorario);

            HorarioAtencion objHorarioAtencion = new HorarioAtencion()
            {
                IdHorarioAtencion = _idHorario,
                Medico = new Medico()
                {
                    IdMedico = _idMedico
                },
                Fecha = Convert.ToDateTime(fecha),
                Hora = new Hora()
                {
                    HoraAtencion = hora
                }
            };


            var respuesta = HorarioAtencionLN.GetInstance().ActualizarHorarioAtencion(objHorarioAtencion);

            return respuesta;
        }
    }
}