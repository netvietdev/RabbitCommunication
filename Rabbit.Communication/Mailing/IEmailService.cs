using System.Collections.Generic;

namespace Rabbit.Communication.Mailing
{
    public interface IEmailService
    {
        /// <summary>
        /// Send an email to a recipient
        /// </summary>
        bool Send(string from, string to, string subject, string body);

        /// <summary>
        /// Send an email to a recipient with friendly name of the sender / receiver
        /// </summary>
        /// <param name="from">Key is address, Value is friendly name</param>
        /// <param name="to">Key is address, Value is friendly name</param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        bool Send(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body);

        /// <summary>
        /// Send an email to a list of recipients
        /// </summary>
        bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body);

        /// <summary>
        /// Send an email to a list of recipients with friendly name of the sender / receiver
        /// </summary>
        /// <param name="from">Key is address, Value is friendly name</param>
        /// <param name="to">Key is address, Value is friendly name</param>
        /// <param name="cc">Key is address, Value is friendly name</param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        bool Send(KeyValuePair<string, string> from, IDictionary<string, string> to, IDictionary<string, string> cc, string subject, string body);

        /// <summary>
        /// Send an email to a list of recipients
        /// </summary>
        bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string subject, string body);

        /// <summary>
        /// Send an email to a list of recipients with friendly name of the sender / receiver
        /// </summary>
        /// <param name="from">Key is address, Value is friendly name</param>
        /// <param name="to">Key is address, Value is friendly name</param>
        /// <param name="cc">Key is address, Value is friendly name</param>
        /// <param name="bcc">Key is address, Value is friendly name</param>
        bool Send(KeyValuePair<string, string> from, IDictionary<string, string> to, IDictionary<string, string> cc, IDictionary<string, string> bcc, string subject, string body);
    }
}
