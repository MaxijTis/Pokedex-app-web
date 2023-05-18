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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil)) 
                        {
                            user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                            user.ImagenPerfil = user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                            imgNuevoPerfil.ImageUrl = "~/images/" + user.ImagenPerfil;
                        }
                        //user.ImagenPerfil = user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        public void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(!Page.IsValid)
                { return; }

            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];

                //Escribir imagen si se cargo algo
                    if (txtImagen.PostedFile.FileName != "") 
                { 
                    string ruta = Server.MapPath("./images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }
                else 
                {
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg"; ;
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                
                //Guardar datos de Perfil
                negocio.actualizar(user);
                

                //user.Email = txtEmail.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                //Leer img
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                user.ImagenPerfil = user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/images/" + user.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}