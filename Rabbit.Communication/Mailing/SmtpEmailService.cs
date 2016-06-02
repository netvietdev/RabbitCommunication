using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class SmtpEmailService : IEmailService
    {
        private readonly ICredentialsByHost _credential;
        private readonly SmtpServerParams _parameters;

        public SmtpEmailService(ICredentialsByHost credential, SmtpServerParams parameters)
        {
            _credential = credential;
            _parameters = parameters;
        }

        public void Send(string from, string to, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(from, to, subject, body);
            Send(msg);
        }

        public void Send(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(from, to, subject, body);
            Send(msg);
        }

        public void Send(MailMessage message)
        {
            var client = new SmtpClient(_parameters.Host, _parameters.Port)
            {
                EnableSsl = _parameters.EnableSsl,
                Timeout = _parameters.Timeout,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            if (_credential != null)
            {
                client.UseDefaultCredentials = false;
                client.Credentials = _credential;
            }

            client.Send(message);
        }
    }
}