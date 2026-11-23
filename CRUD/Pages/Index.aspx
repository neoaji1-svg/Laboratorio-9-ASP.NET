<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio - Listado de Usuarios
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto text-center" style="width: 300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-center">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control" Text="Crear Registro" OnClick="BtnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table-responsive">
                <asp:GridView ID="gvusuarios" runat="server" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del Administrador">
                            <ItemTemplate>
                                <div class="d-flex gap-1">
                                    <asp:Button runat="server" Text="Read" CssClass="btn btn-sm btn-info" ID="btnRead" OnClick="BtnRead_Click"
                                        CommandName="Leer" CommandArgument='<%# Eval("idUsuario") %>' />
                                    <asp:Button runat="server" Text="Update" CssClass="btn btn-sm btn-warning" ID="btnUpdate" OnClick="BtnUpdate_Click"
                                        CommandName="Actualizar" CommandArgument='<%# Eval("idUsuario") %>' />
                                    <asp:Button runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" ID="btnDelete" OnClick="BtnDelete_Click"
                                        CommandName="Eliminar" CommandArgument='<%# Eval("idUsuario") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
