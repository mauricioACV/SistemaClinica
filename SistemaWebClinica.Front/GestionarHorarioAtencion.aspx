<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarHorarioAtencion.aspx.cs" Inherits="SistemaWebClinica.Front.GestionarHorarioAtencion" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">Gestión Horarios de Médicos</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-4">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Datos del Médico</h3>
                    </div>
                    <div class="box-body">
                        <label>Rut Médico</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnBuscar" CssClass="btn btn-info btn-flat" runat="server" Text="Buscar" />
                            </span>
                        </div>
                    </div>
                    <div class="box-footer">
                        <strong>Nombre: </strong>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br /><br />
                        <strong>Apellido: </strong>
                        <asp:Label ID="lblApellidos" runat="server" Text=""></asp:Label><br /><br />
                        <strong>Especialidad: </strong>
                        <asp:Label ID="lblEspecialidad" runat="server" Text=""></asp:Label><br /><br />
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Horario de Atención</h3>
                    </div>
                    <div class="box-body table-responsive"">
                        <table id="tbl_pacientes" class="table table-bordered table-hover text-center">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th></th>
                                    <th>Fecha de Atención</th>
                                    <th>Hora de Atención</th>
                                    <th style="display:none">Estado</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                                <tr>
                                    <td>boton-editar</td>
                                    <td>boton-eliminar</td>
                                    <td>campo-fecha</td>
                                    <td>campo-hora</td>
                                    <td style="display:none">estado</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="box-footer" style="text-align: center">
                        <asp:Button ID="btnAgregarHorario" runat="server" CssClass="btn btn-primary" Text="Agregar Horario" />
                        <asp:Button ID="btnGuardarHorario" runat="server" CssClass="btn btn-success" Text="Guardar Horario" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/GestionarHorarioAtencion.js" type="text/javascript"></script>
</asp:Content>
