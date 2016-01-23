using System.Collections.Generic;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class MailMessageBuilder
    {
        public MailMessage BuildMailMessage(string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string body)
        {
            var msg = new MailMessage
            {
                From = new MailAddress(from)
            };
            msg.ReplyToList.Add(from);

            foreach (var address in to)
            {
                msg.To.Add(new MailAddress(address));
            }

            foreach (var address in cc)
            {
                msg.CC.Add(new MailAddress(address));
            }

            foreach (var address in bcc)
            {
                msg.Bcc.Add(address);
            }

            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            return msg;
        }

        public MailMessage BuildMailMessage(KeyValuePair<string, string> from, IEnumerable<KeyValuePair<string, string>> to, IEnumerable<KeyValuePair<string, string>> cc, IEnumerable<KeyValuePair<string, string>> bcc, string subject, string body)
        {
            var msg = new MailMessage
            {
                From = new MailAddress(from.Key, from.Value)
            };
            msg.ReplyToList.Add(new MailAddress(from.Key, from.Value));

            foreach (var address in to)
            {
                msg.To.Add(new MailAddress(address.Key, address.Value));
            }

            foreach (var address in cc)
            {
                msg.CC.Add(new MailAddress(address.Key, address.Value));
            }

            foreach (var address in bcc)
            {
                msg.Bcc.Add(new MailAddress(address.Key, address.Value));
            }

            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            return msg;
        }
    }
}