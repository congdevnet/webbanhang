using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Service
{
    public class EmailService : IEmailService
    {
        public bool Send(string toEmail, string subject, string body)
        {
            try
            {
                string smtpUserName = ConfigurationManager.AppSettings["smtpUserName"];
                string smtpPassword = ConfigurationManager.AppSettings["smtpPassword"];
                string smtpHost = ConfigurationManager.AppSettings["smtpHost"];
                int smtpPort =int.Parse(ConfigurationManager.AppSettings["smtpPort"]);

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = smtpPort;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };
                    msg.To.Add(toEmail);
                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch(Exception ex)
            {

                return false;
            }
        }
    }
}