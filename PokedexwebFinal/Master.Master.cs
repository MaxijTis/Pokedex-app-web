using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;

namespace PokedexwebFinal
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.sesionActiva(Session["trainee"]))
            {
                imgAvatar.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
                if (!(Page is Login || Page is Registro || Page is Default || Page is error))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            else
            {
                Trainee user = (Trainee)Session["trainee"];
                lblUser.Text = user.Email;
                //if (!string.IsNullOrEmpty(user.ImagenPerfil))
                //{
                //    imgAvatar.ImageUrl = "~/images/" + user.ImagenPerfil;
                //    imgAvatar.ImageUrl = imgAvatar.ImageUrl + "?v=" + DateTime.Now.Ticks.ToString();
                //    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                //    user.ImagenPerfil = user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                //}
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    string imageUrl = $"~/images/{user.ImagenPerfil}?v={DateTime.Now.Ticks}";
                    imgAvatar.ImageUrl = imageUrl;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}