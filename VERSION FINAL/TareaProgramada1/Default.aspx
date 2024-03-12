<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TareaProgramada1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!-- Panel para mostrar datos de empleados -->
        <asp:Panel runat="server" ID="pnlDatoEmpleado" CssClass="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Lista de Empleados</h3>
            </div>
            <div class="panel-body">
                <!-- GridView para mostrar la lista de empleados -->
                <asp:GridView ID="gvdEmpleados" runat="server" CssClass="table table-striped">
                </asp:GridView>
            </div>
            <div class="panel-footer">

                <!-- Botón para agregar un nuevo empleado -->
                <asp:Button ID="btnNuevo" Text="Insertar Nuevo Empleado" runat="server" OnClick="btnNuevo_Click" CssClass="btn btn-primary" />
            </div>
        </asp:Panel>

        <!-- Panel para agregar un nuevo empleado -->
        <asp:Panel ID="pnlAltaEmpleado" runat="server" Visible="false" CssClass="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Agregar Nuevo Empleado</h3>
            </div>
            <div class="panel-body">
                <!-- Campos para ingresar un nuevo empleado -->
                <div class="form-group">
                    <asp:Label ID="IblNombre" Text="Nombre:" runat="server" CssClass="control-label"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lbSalario" Text="Salario:" runat="server" CssClass="control-label"></asp:Label>
                    <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="panel-footer">
                <!-- Botón para insertar el nuevo empleado -->
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="btn btn-success" />

                <!-- Botón para regresar a la página principal -->
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn btn-default" />
            </div>
        </asp:Panel> 
    </div>
</asp:Content>
