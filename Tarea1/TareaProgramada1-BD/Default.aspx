<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TareaProgramada1_BD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Panel runat="server" ID="pnlDatoEmpleado">
            <asp:GridView ID="gvdEmpleados" runat="server" AutoGenerateColumns="true">
        
            </asp:GridView>
            <asp:button ID ="btnNuevo" Text ="Insertar" runat ="server"  OnClick ="btnNuevo_Click" />
        </asp:Panel>

        <asp:Panel ID="pnlAltaEmpleado" runat="server" Visible="false">
           
            <div>
                <asp:Label ID="IblNombre" Text="Nombre" runat="server"></asp:Label>
                 <asp:TextBox ID="txtNombre" runat="server" />
            </div>

            <div>
                <asp:Label ID="lbSalario" Text="Salario" runat="server"></asp:Label>
                <asp:TextBox ID="txtSalario" runat="server" />
            </div>
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnGuardar_Click" />

        </asp:Panel> 



    </div>
    

</asp:Content>