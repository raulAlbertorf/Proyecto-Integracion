using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Proyecto_Integracion.WebApp.Utils
{
    public class Email
    {
        public static void SendEmail(string Subject, string To, string Message)
        {
            using (MailMessage mm = new MailMessage())
            {
                mm.From = new MailAddress("noreplyreportit@gmail.com");
                mm.Subject = Subject;
                mm.Body = Message;
                mm.IsBodyHtml = true;
                mm.To.Add(new MailAddress(To));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                var credential = new NetworkCredential { UserName = "noreplyreportit@gmail.com", Password = "ReportIt-2017" };
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}