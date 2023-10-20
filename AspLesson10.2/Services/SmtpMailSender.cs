using AspLesson10._2.Models;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;

namespace AspLesson10._2.Services
{
    public class SmtpMailSender
    {
        private readonly ILogger<SmtpMailSender> _logger;
        private SmtpSetting Settings { get; }
        public SmtpMailSender(IOptions<SmtpSetting> settings, ILogger<SmtpMailSender> logger)
        {
            Settings = settings.Value;
            _logger = logger;
        }

        public void SendEmail(Email emailInfo)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(Settings.SmtpServer, Settings.SmtpPort, false);
                    client.Authenticate(Settings.Username, Settings.Password);

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(Settings.Username, Settings.Username));
                    message.To.Add(new MailboxAddress(emailInfo.Receiver, emailInfo.Receiver));
                    message.Subject = emailInfo.Subject;

                    var body = new TextPart("plain")
                    {
                        Text = emailInfo.Body
                    };
                    message.Body = body;

                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
            }

        }
    }
}
