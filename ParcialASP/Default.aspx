<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Segundo examen pacial en ASP.NET</h1>
        <p class="lead">Recreación del segundo parcial del curso bajo la plataforma de ASP.NET</p>
        <p class="lead">Departamento:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p class="lead">Medición:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p class="lead">Registrados previamente</p>
        <p class="lead">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </p>
        <p class="lead">Promedio de lluvias:
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p class="lead">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Actualizar" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Añadir" />
        </p>
    </div>
</asp:Content>
