using System.Collections.Generic;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class MailMessageBuilder
    {
        public MailMessage BuildMailMessage(string from, string to, string subject, string body)
        {
            var msg = new MailMessage
            {
                From = new MailAddress(from)
            };
            msg.ReplyToList.Add(from);

            msg.To.Add(new MailAddress(to));

            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            return msg;
        }

        public MailMessage BuildMailMessage(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body)
        {
            var msg = new MailMessage
            {
                From = new MailAddress(from.Key, from.Value)
            };
            msg.ReplyToList.Add(new MailAddress(from.Key, from.Value));

            msg.To.Add(new MailAddress(to.Key, to.Value));

            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;

            return msg;
        }
    }
}