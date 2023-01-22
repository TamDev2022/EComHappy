using Contracts.ConfigurationOptions;
using Contracts.Contains;
using Contracts.Services;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mail
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<AppSettings> appSettings)
        {
            _mailSettings = appSettings.Value.MailSettings;
        }

        public async Task SendMailAsync(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.SmtpServer);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.SmtpServer));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<h3>Mã xác nhận của bạn: </h3>" + "<h2 style='color:red;'> {0}</h2>", mailContent.Content),
                
            };

            using var stmp = new SmtpClient();
            try
            {
                stmp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                stmp.Authenticate(_mailSettings.SmtpServer, _mailSettings.Password);
                await stmp.SendAsync(email);
                stmp.Disconnect(true);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);
            }

        }

        public async Task SendMailClickAsync(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.SmtpServer);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.SmtpServer));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;


            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\WelcomeTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[username]", mailContent.To).Replace("[emaiUserNamel]", mailContent.To);

            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();

            using var stmp = new SmtpClient();
            try
            {
                stmp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                stmp.Authenticate(_mailSettings.SmtpServer, _mailSettings.Password);
                await stmp.SendAsync(email);
                stmp.Disconnect(true);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);
            }

        }
    }
}
