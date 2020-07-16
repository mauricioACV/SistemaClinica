using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using System;
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

            return HorarioAtencionLN.GetInstance().AgregarHorario(objHorarioAtencion);
        }
    }
}