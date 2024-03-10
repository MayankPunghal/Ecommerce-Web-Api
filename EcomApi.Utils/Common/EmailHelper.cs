using System.Net.Mail;

namespace EcomApi.Utils.Common
{
    public class EmailHelper
    {
        public static void SendMail(string subject = "", string body = "", string to = null, string cc = null, string bcc = null, string attachment = null, string emailFrom = null)
        {
            using var message = new MailMessage { From = new MailAddress(AppSettings.Settings.MailSettings.Smtp.From) };
            if (!string.IsNullOrWhiteSpace(to)) { var toArr = to.Split(new char[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct(StringComparer.CurrentCultureIgnoreCase); message.To.Add(string.Join(",", toArr)); }
            if (!string.IsNullOrWhiteSpace(cc)) { var ccArr = cc.Split(new char[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct(StringComparer.CurrentCultureIgnoreCase); message.CC.Add(string.Join(",", ccArr)); }
            if (!string.IsNullOrWhiteSpace(bcc)) { var bccArr = bcc.Split(new char[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct(StringComparer.CurrentCultureIgnoreCase); message.Bcc.Add(string.Join(",", bccArr)); }

            message.Body = body;
            message.Subject = subject;
            message.IsBodyHtml = true;
            if (!string.IsNullOrEmpty(attachment)) { message.Attachments.Add(new Attachment(attachment)); }
            if (!string.IsNullOrEmpty(emailFrom)) { message.From = new MailAddress(emailFrom); }

            using var smtpClient = new SmtpClient
            {
                UseDefaultCredentials = AppSettings.Settings.MailSettings.Smtp.Network.DefaultCredentials,//SmtpSection.Network.DefaultCredentials,
                EnableSsl = AppSettings.Settings.MailSettings.Smtp.Network.EnableSsl,
                Host = AppSettings.Settings.MailSettings.Smtp.Network.Host,
                Port = AppSettings.Settings.MailSettings.Smtp.Network.Port,
                //DeliveryMethod = App.Settings.MailSettings.Smtp.DeliveryMethod,
                Credentials = new System.Net.NetworkCredential(AppSettings.Settings.MailSettings.Smtp.Network.UserName, AppSettings.Settings.MailSettings.Smtp.Network.Password/*, App.Settings.MailSettings.Smtp.Network.ClientDomain*/),
                Timeout = 300000 //5 Minutes (5*60*1000)

            };
            Log.Info($"SENDING MAIL TO:[{to}], CC:[{cc}], BCC:[{bcc}] with Subject:[{subject}]");
            smtpClient.Send(message);
        }
    }
}
