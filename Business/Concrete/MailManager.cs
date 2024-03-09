using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        public void SendWelcomeMail(string recipientEmail)
        {
            var senderEmail = "meetingcase39@gmail.com";
            var senderName = "Batuhan";
            var password = "Meeting#case39_";
            var password2 = "uaua bnbe qfeg fjcs";

            var fromAddress = new MailAddress(senderEmail, senderName);
            var toAddress = new MailAddress(recipientEmail, recipientEmail);
            string subject = $"Welcome! {recipientEmail}";
            string body = "Welcome Brotherrr!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password2)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }
    }
}
