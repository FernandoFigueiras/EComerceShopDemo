using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;

namespace TimeZone.Resources
{
    public static class EmailService
    {
        public static bool SendRegisterEmail(string email, string registerNumber)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("sendermockdev@gmail.com");

            message.IsBodyHtml = true;



            message.Body =$"<h1>Confirmação de email</h1>" +
                      $"Obrigado por se inscrever na nossa loja, para completar o registo, " +
                      $"clique neste link:</br></br><a href = \"{"https://localhost:44357/RegisterConfirmation.aspx?email=" + email + "&id="+ registerNumber}\">Confirmar email</a>";


            try
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("sendermockdev@gmail.com", "1a@43!n4");

                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }


        public static bool SendRecoverPasswordEmail(string email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("sendermockdev@gmail.com");

            message.IsBodyHtml = true;



            message.Body = $"<h1>Alterar Password</h1>" +
                      $"" +
                      $"Para alterar a sua password clique neste link:</br></br><a href = \"{"https://localhost:44357/ConfirmRecoverPassword.aspx?email=" + email }\">Confirmar email</a>";


            try
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("sendermockdev@gmail.com", "1a@43!n4");

                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }


        }



        public static bool SendFinishSellEmail(string email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("sendermockdev@gmail.com");

            message.IsBodyHtml = true;



            message.Body = $"<h1>Confirmação de compra</h1>" +
                      $"Obrigado por comprar na nossa loja, recebera um email quando a encomenda estiver validada";


            try
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("sendermockdev@gmail.com", "1a@43!n4");

                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }



        public static bool SendConfirmationPackage(string email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.To.Add(new MailAddress(email));
            message.From = new MailAddress("sendermockdev@gmail.com");

            message.IsBodyHtml = true;



            message.Body = $"<h1>Confirmação de email</h1>" +
                      $"A sua encomenda esta a caminho, devera receber dentro de 3 dias uteis";


            try
            {
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("sendermockdev@gmail.com", "1a@43!n4");

                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }

        }

    }
}