<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PokedexwebFinal.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Validacion {
            color: red;
            font-size: 12px;
        }
    </style>
    <script>

            function validar() {

                //capturar el control. 
                const txtApellido = document.getElementById("txtApellido");
                const txtNombre = document.getElementById("txtNombre");
                if (txtApellido.value == "") {
                    txtApellido.classList.add("is-invalid");
                    txtApellido.classList.remove("is-valid");
                    return false;
                }
                else if (txtNombre.value == "") {
                    txtNombre.classList.add("is-invalid");
                    txtNombre.classList.remove("is-valid");
                    return false;
                }
                txtApellido.classList.remove("is-invalid");
                txtApellido.classList.add("is-valid");
                txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");
                return true;
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txtEmail" TextMode="Email" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                <%-- <asp:RequiredFieldValidator ErrorMessage="Debes cargar un nombre" CssClass="Validacion" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtApellido" />
                <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Solo numeros" ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server" />--%>
                <%--<asp:RangeValidator ErrorMessage="Fuera de Rango..." ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="20" runat="server" /> --%>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://d500.epimg.net/cincodias/imagenes/2016/07/04/lifestyle/1467646262_522853_1467646344_noticia_normal.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
