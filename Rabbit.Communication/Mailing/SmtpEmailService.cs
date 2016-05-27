using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class SmtpEmailService : IEmailService
    {
        private readonly NetworkCredential _credential;
        private readonly SmtpServerParams _parameters;

        public SmtpEmailService(NetworkCredential credential, SmtpServerParams parameters)
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
            var client = new SmtpClient
            {
                UseDefaultCredentials = false,
                Host = _parameters.Host,
                Port = _parameters.Port,
                EnableSsl = _parameters.EnableSsl,
                Timeout = _parameters.Timeout,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = _credential,
            };

            client.Send(message);
        }
    }
}