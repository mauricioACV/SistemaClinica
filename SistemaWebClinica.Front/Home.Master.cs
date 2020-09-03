using SistemaWebClinica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaWebClinica.Front
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["UserSessionObjeto"] != null)
                {
                    Empleado objEmpleado = (Empleado)Session["UserSessionObjeto"];
                    txtUser.Text = objEmpleado.Nombre + " " + objEmpleado.ApPaterno;
                }
            }
        }
    }
}