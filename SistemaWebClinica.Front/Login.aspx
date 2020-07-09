<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaWebClinica.Front.Login" %>

<!DOCTYPE html>

<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema CLínica</title>
    <link href="css/bootstrap-4.4.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/fontawesome.min.css" rel="stylesheet" />
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-black">
    <form id="form1" runat="server">
        <div class="form-box" id="login-box">
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
                <LayoutTemplate>
                    <div class="header">Login</div>
                    <div class="body bg-gray">
                        <div class="form-group">
                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Ingrese Usuario" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Ingrese Password" TextMode="Password" />
                        </div>
                    </div>
                    <div class="footer">
                        <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesión" CssClass="btn bg-olive btn-block"/>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </form>
    <script src="jquery/jquery-3.4.1.min.js"></script>
    <script src="css/bootstrap-4.4.1-dist/js/bootstrap.min.js" ></script>
</body>
</html>
