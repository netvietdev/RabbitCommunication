using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class SmtpEmailService : IEmailService
    {
        private readonly NetworkCredential _credential;
        private readonly SmtpClientParams _parameters;

        public SmtpEmailService(NetworkCredential credential, SmtpClientParams parameters)
        {
            _credential = credential;
            _parameters = parameters;
        }

        public bool Send(string from, string to, string subject, string body)
        {
            return Send(from, new[] { to }, Enumerable.Empty<string>(), subject, body);
        }

        public bool Send(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body)
        {
            return Send(from,
                new Dictionary<string, string> { { to.Key, to.Value } },
                new Dictionary<string, string>(),
                subject,
                body);
        }

        public bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body)
        {
            return Send(from, to, cc, Enumerable.Empty<string>(), subject, body);
        }

        public bool Send(KeyValuePair<string, string> from, IDictionary<string, string> to, IDictionary<string, string> cc, string subject, string body)
        {
            return Send(from, to, cc, new Dictionary<string, string>(), subject, body);
        }

        public bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(@from, to, cc, bcc, subject, body);

            SendMailMessage(msg);

            return true;
        }

        public bool Send(KeyValuePair<string, string> from, IDictionary<string, string> to, IDictionary<string, string> cc, IDictionary<string, string> bcc, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(@from, to, cc, bcc, subject, body);

            SendMailMessage(msg);

            return true;
        }

        private void SendMailMessage(MailMessage msg)
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

            client.Send(msg);
        }
    }
}