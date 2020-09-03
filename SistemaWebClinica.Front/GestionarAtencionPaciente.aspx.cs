using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaWebClinica.Front
{
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static string COMMAND_REGISTER = "Registrar";
        private static string COMMAND_CANCEL = "Cancelar";

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
            List<Cita> ListaCitas = CitaLN.GetInstance().LitarCitas();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }

        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string IdCita = (e.Item.FindControl("hdIdCita") as HiddenField).Value;
            string IdPaciente = (e.Item.FindControl("hdIdPaciente") as HiddenField).Value;

            if (e.CommandName == COMMAND_REGISTER)
            {
                bool respuesta = CitaLN.GetInstance().ActualizarCita(Convert.ToInt32(IdCita), "A");

                if (respuesta)
                {
                    string script = "alert.show('OK')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, true);
                    Response.Redirect("GestionarAtencionCita.aspx?idCita=" + IdCita + "&idPaciente=" + IdPaciente);
                }
                else
                {
                    Response.Write("<script>alert('Algo falló...')</script>");
                }
                
            }
            else if(e.CommandName == COMMAND_CANCEL)
            {
                bool respuesta = CitaLN.GetInstance().ActualizarCita(Convert.ToInt32(IdCita), "E");

                if (respuesta)
                {
                    LlenaCitas();
                }
                else
                {
                    //algo falló
                }
            }
        }
    }
}