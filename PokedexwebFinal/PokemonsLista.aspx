<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonsLista.aspx.cs" Inherits="PokedexwebFinal.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1>Lista de Pokemons</h1>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end; align-items:flex-end">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                        <asp:Button Text="Limpiar Filtro" ID="btnReset" CssClass="btn btn-outline-secondary" runat="server" OnClick="btnReset_Click"  />
                    </div>
                </div>
            </div>
            <%if (chkAvanzado.Checked)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server"  />
                        <asp:DropDownList runat="server" AutoPostBack="true" id="ddlCamp" CssClass="form-control" OnSelectedIndexChanged="ddlCamp_SelectedIndexChanged">
                            <asp:ListItem Text="Seleccione un campo"/>
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

            <% } %>
            <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id"
                AutoGenerateColumns="false" CssClass="table"
                OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
                OnPageIndexChanging="dgvPokemons_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Numero" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✅" />
                </Columns>
            </asp:GridView>
        <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
