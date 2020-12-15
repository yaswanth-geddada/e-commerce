using System;
using System.Net;
using System.Net.Mail;

namespace ECommerce_Application
{
  class EmailAlert
  {

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("no.reply.leavemanager251@gmail.com", "LMSMLP251"),
            UseDefaultCredentials = false,
            EnableSsl = true,
        };

        public void SendEmail(string To, string Subject, string Body)
        {
            
            smtpClient.Send("no.reply.leavemanager251@gmail.com", To, Subject, Body);
    
        }

  }

}