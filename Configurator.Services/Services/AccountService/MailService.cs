using Configurator.DataLayer;
using Configurator.Services.IServices.IAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.Services.AccountService
{
    public class MailService : IMailService
    {
     

        public void SendPassword(User user)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("huishi0709@gmail.com");
                    message.To.Add(user.LoginEmail);
                    message.Body = "Your password is " + user.Password;
                    message.Subject = "Password";
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("huishi0709@gmail.com", "593010sh");
                    client.Send(message);
                    message = null;

                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                // TODO: Handle exception
                // When email could not be delivered to all receipients.
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                // TODO: Handle exception
                // When SMTP Client cannot complete Send operation.
                throw sEx;
            }
        }
    }
}
