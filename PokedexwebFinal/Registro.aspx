<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PokedexwebFinal.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-4">
            <h2>Creá tu Perfil Trainee</h2>
            <div class="mb-3">
                <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Label ID="Pass" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnRegistrarse" Text="Registrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" runat="server" />
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
