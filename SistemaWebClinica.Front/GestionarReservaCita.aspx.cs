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
                grdHorariosAtencion.DataSource = null;
                grdHorariosAtencion.DataBind();
                LlenarComboEspecialidades();
                LlenarGridViewHorarioAtencion();
            }
        }

        private void LlenarGridViewHorarioAtencion()
        {
            DateTime fechaBusqueda = Convert.ToDateTime("24-07-2020");
            List<HorarioAtencion> ListaGridView = HorarioAtencionLN.GetInstance().ListarHorarioPorFechaEspecialidad(1, fechaBusqueda);
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

        [WebMethod]
        public static Paciente BuscarPacientePorDni(string dni)
        {
            return PacienteLN.GetInstance().BuscarPacientePorDni(dni);
        }
    }
}