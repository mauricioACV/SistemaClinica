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
    public partial class frmGestionarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }

        }

        [WebMethod]
        public static List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = null;
            try
            {
                Lista = PacienteLN.GetInstance().ListarPacientes();
            }
            catch (Exception ex)
            {
                Lista = null;
                throw ex;
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosPaciente(string id, string direccion)
        {
            Paciente objPaciente = new Paciente()
            {
                IdPaciente = Convert.ToInt32(id),
                Direccion = direccion
            };

            bool response = PacienteLN.GetInstance().ActualizarPaciente(objPaciente);

            return response;
        }

        private Paciente GetEntityPaciente()
        {
            Paciente objPaciente = new Paciente
            {
                //IdPaciente = 0,
                Nombres = txtNombres.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                Sexo = Convert.ToChar(ddlSexo.SelectedValue),
                NroDocumento = txtNroDocumento.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Estado = true,
                Imagen = null
            };

            return objPaciente;
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //Registro del Paciente
            Paciente objPaciente = GetEntityPaciente();
            bool response = PacienteLN.GetInstance().RegistrarPaciente(objPaciente);
            if (response == true)
            {
                Response.Write("<script>alert('Registro Correcto')</script>");
            }
            else
            {
                Response.Write("<script>alert('Registro Incorrecto')</script>");
            }
        }
    }
}