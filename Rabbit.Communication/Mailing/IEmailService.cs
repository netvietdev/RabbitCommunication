using System.Collections.Generic;

namespace Rabbit.Communication.Mailing
{
    public interface IEmailService
    {
        bool Send(string from, string to, string subject, string body);

        bool Send(string from, IEnumerable<string> to, IEnumerable<string> cc, string subject, string body);
    }
}
