using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService() 
        { 
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo) 
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@pokedexweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>te Reporte de materias a las que se ha inscripto</h1><br>Hola este es el reporte de materias en las que tas has inscripto</br>";
            email.Body = cuerpo;
        }

        public void EnviarEmail() 
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
