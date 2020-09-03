using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using SistemaWebClinica.Entidades;
using SistemaWebClinica.Negocio;
using SistemaWebClinica.Front.Custom;

namespace SistemaWebClinica.Front
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSessionId"] = null;
            }
        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);

            if (auth)
            {
                Empleado objEmpleado = EmpleadoLN.GetInstance().AccesoSistema(LoginUser.UserName, LoginUser.Password);

                if (objEmpleado != null)
                {
                    SessionManager = new SessionManager(Session);
                    SessionManager.UserSessionObjeto = objEmpleado;

                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                }
                else
                {
                    Response.Write("<script>alert('Usuario Incorrecto')</script>");
                }
            }
        }
    }
}