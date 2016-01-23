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

        public bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body)
        {
            var msg = BuildMailMessage(@from, to, cc, subject, body);

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

            return true;
        }

        private MailMessage BuildMailMessage(string @from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body)
        {
            var msg = new MailMessage
            {
                From = new MailAddress(@from)
            };

            foreach (var address in to)
            {
                msg.To.Add(new MailAddress(address));
            }

            foreach (var address in cc)
            {
                msg.CC.Add(new MailAddress(address));
            }

            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            return msg;
        }
    }
}