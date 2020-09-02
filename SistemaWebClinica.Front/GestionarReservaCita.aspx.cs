using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaWebClinica.Front
{
    public partial class GestionarReservaCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarComboEspecialidades();                
            }
        }

        [WebMethod]
        public static Paciente BuscarPacientePorDni(string dni)
        {
            return PacienteLN.GetInstance().BuscarPacientePorDni(dni);
        }

        private void LlenarGridViewHorarioAtencion()
        {
            if (txtFechaAtencion.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alerta", "<script>No ha ingresado fecha</script>", false);
                return;
            }

            string fechaFormulario = txtFechaAtencion.Text;
            DateTime fechaBusqueda = Convert.ToDateTime(fechaFormulario);

            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            List<HorarioAtencion> ListaGridView = HorarioAtencionLN.GetInstance().ListarHorarioPorFechaEspecialidad(idEspecialidad, fechaBusqueda);
            grdHorariosAtencion.DataSource = ListaGridView;
            grdHorariosAtencion.DataBind();
        }

        private void LlenarComboEspecialidades()
        {
            List<Especialidad> ListaEspecialidades = EspecialidadLN.GetInstance().ListarEspecialidad();
            ddlEspecialidad.DataSource = ListaEspecialidades;
            ddlEspecialidad.DataValueField = "IdEspecialidad";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
        }

        protected void btnBuscarHorario_Click(object sender, EventArgs e)
        {
            LlenarGridViewHorarioAtencion();
        }

        protected void btnReservarCita_Click(object sender, EventArgs e)
        {

            bool EstaSeleccionado = HorarioAtencionSeleccionado();
            var _idPaciente = idPaciente.Value;            

            if (!idPaciente.Value.Equals(string.Empty) && EstaSeleccionado)
            {
                Cita objCita = ObtenerCitaSeleccionada();
                bool respuesta = CitaLN.GetInstance().RegistrarCitaPaciente(objCita);

                if (respuesta)
                {
                    Response.Write("ok");
                }
                else
                {
                    Response.Write("Error");
                }
            }

        }

        private bool HorarioAtencionSeleccionado()
        {
            foreach(GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    return true;
                }                
            }
            return false;
        }

        private Cita ObtenerCitaSeleccionada()
        {
            Cita objCita = new Cita();

            foreach (GridViewRow row in grdHorariosAtencion.Rows)
            {
                CheckBox chkHorario = (row.FindControl("chkSeleccionar") as CheckBox);

                if (chkHorario.Checked)
                {
                    objCita.Hora = (row.FindControl("lblHora") as Label).Text;
                    objCita.FechaReserva = DateTime.Now;
                    objCita.Paciente.IdPaciente = Convert.ToInt32(idPaciente.Value);
                    objCita.Medico.IdMedico = Convert.ToInt32((row.FindControl("hfIdMedico") as HiddenField).Value);
                    break;
                }
            }
            return objCita;
        }
    }
}