using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace PickupGames
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("roybrown77@gmail.com", "Admin");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailAccount"], ConfigurationManager.AppSettings["mailPassword"]);

            // Create a Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.            
            try
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Failed to create Web transport.");
                //await Task.FromResult(0);
            }                       
        }
    }    
}
