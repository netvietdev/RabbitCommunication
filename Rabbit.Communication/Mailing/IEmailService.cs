using System.Collections.Generic;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public interface IEmailService
    {
        /// <summary>
        /// Send an email to a recipient
        /// </summary>
        void Send(string from, string to, string subject, string body);

        /// <summary>
        /// Send an email to a recipient with friendly name of the sender / receiver
        /// </summary>
        /// <param name="from">Key is address, Value is friendly name</param>
        /// <param name="to">Key is address, Value is friendly name</param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        void Send(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body);

        /// <summary>
        /// Send an email message
        /// </summary>
        void Send(MailMessage message);
    }
}
