
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace MVCIdentity
{
    public class Notification
    {

        public async Task SendEmailAsync(string email, string subject,string message)
        {

            var client = new SendGridClient(ConfigurationManager.AppSettings["SG.Key"]);

            // Send a Single Email using the Mail Helper with convenience methods and initialized SendGridMessage object
            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@qcservicesgh.com", "QCServices Client"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = $"<strong>{message}</strong>"
            };
            var emailAdd = new MailAddress(email);
            msg.AddTo(emailAdd.Address);

           // Response response = await client.;
            //Console.WriteLine(msg.Serialize());
            //Debugger.Log(0, "Sendgrid", response.StatusCode.ToString());
            //Console.WriteLine(response.Headers);

        }

        
        public async Task SendSmsAsync(string number, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                int requiredPhoneLength = number.Length - 1;
                var local = "233" + number.Substring(1, requiredPhoneLength);
                var response = await client.GetAsync($"https://api.hubtel.com/v1/messages/send?From=QcServices&To=+{local}&Content={message}&ClientId=gyoirrki&ClientSecret=scrnocdj&RegisteredDelivery=true");
            }
        }

    }



}