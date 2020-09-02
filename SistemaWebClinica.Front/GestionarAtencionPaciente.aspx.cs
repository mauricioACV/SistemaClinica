using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaWebClinica.Front
{
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static string COMMAND_REGISTER = "Registrar";
        private static string COMMAND_CANCELAR = "Cancelar";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenaCitas();
                lblFechaAtencion.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void LlenaCitas()
        {
            List<Cita> ListaCitas = CitaLN.GetInstance().LitasCitas();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }

        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == COMMAND_REGISTER)
            {

            }
            else if(e.CommandName == COMMAND_CANCELAR)
            {

            }
        }
    }
}