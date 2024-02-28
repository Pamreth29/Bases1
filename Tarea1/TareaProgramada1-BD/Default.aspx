<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TareaProgramada1_BD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <asp:GridView ID="gvdEmpleados" runat="server" AutoGenerateColumns="true">
        </asp:GridView>

    </div>
    

</asp:Content>