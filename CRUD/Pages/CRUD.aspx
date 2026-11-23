<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.Pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Mantenimiento de Usuario
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto text-center" style="width: 350px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <br />
    <form runat="server" class="mx-auto" style="max-width: 500px;">
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Edad</label>
            <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" ID="txtEdad"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Correo</label>
            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="txtCorreo"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Fecha de Nacimiento</label>
            <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtFechaNacimiento"></asp:TextBox>
        </div>

        <div class="d-flex gap-2">
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCreate" Text="Crear" Visible="false" OnClick="btnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-warning" ID="btnUpdate" Text="Modificar" Visible="false" OnClick="btnUpdate_Click" />
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnVolver" Text="Volver" Visible="true" OnClick="btnVolver_Click" />
        </div>
    </form>
</asp:Content>
