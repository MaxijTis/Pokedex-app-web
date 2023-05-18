using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PokedexwebFinal
{
    public partial class Lista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["trainee"])) 
            {
                Session.Add("error", "Se requiere permisos de Admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx", false);
            }



            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listaPokemons", negocio.listarconSP());
                dgvPokemons.DataSource = Session["listaPokemons"];
                dgvPokemons.DataBind();
            }
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.filtrar(ddlCamp.SelectedItem.ToString(), 
                ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text, 
                ddlEstado.SelectedItem.ToString());

                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCamp.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a ");
                ddlCriterio.Items.Add("Mayor a ");
                ddlCriterio.Items.Add("Menor a ");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con ");
                ddlCriterio.Items.Add("Termina con ");
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("PokemonsLista.aspx");
            //dgvPokemons.PageIndex = 0;
            //dgvPokemons.DataSource = Session["listaPokemons"];
            //dgvPokemons.DataBind();
        }
    }
}