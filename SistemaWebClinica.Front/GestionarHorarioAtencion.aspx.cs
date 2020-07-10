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
    }
}