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
    public partial class GestionarAtencionCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdCita = Convert.ToInt32(Request.QueryString["idCita"]);
                int IdPaciente = Convert.ToInt32(Request.QueryString["idPaciente"]); 
                LlenarDatosPaciente(IdPaciente);
            }
        }

        private void LlenarDatosPaciente(int idPaciente)
        {
            Paciente objPaciente = PacienteLN.GetInstance().BuscarPacientePorId(idPaciente);
            lblNombres.Text = objPaciente.Nombres;
            lblApellidos.Text = objPaciente.ApPaterno + "" + objPaciente.ApMaterno;
            lblEdad.Text = objPaciente.Edad.ToString();
            lblSexo.Text = (objPaciente.Sexo == 'F') ? "Femenino" : "Masculino";
            hfIdPaciente.Value = objPaciente.IdPaciente.ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Diagnostico objDiagnostico = new Diagnostico();
            objDiagnostico.HistoriaClinica.Paciente.IdPaciente = Convert.ToInt32(hfIdPaciente.Value);
            objDiagnostico.Observacion = txtObservaciones.Text;
            objDiagnostico.DiagnosticoText = txtDiagnostico.Text;

            bool respuesta = DiagnosticoLN.GetInstance().RegistrarDiagnosticoPaciente(objDiagnostico);

            if (respuesta)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('OK..');", true);
                btnRegistrar.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error..');", true);
            }
        }
    }
}