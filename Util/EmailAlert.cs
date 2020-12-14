using System;

namespace ECommerce_Application
{
  class EmailAlert
  {


    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
    {
      Port = 587,
      Credentials = new NetworkCredential("no.reply.leavemanager251@gmail.com", "LMSMLP251"),
      EnableSsl = true,
    };


    public static void SendEmail(string To, string Subject, string Body)
    {
      smtpClient.Send("no.reply.leavemanager251@gmail.com", To, Subject, Body);
    }

  }

}