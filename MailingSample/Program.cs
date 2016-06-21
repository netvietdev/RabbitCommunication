using System.Collections.Generic;
using System.Net;
using Rabbit.Communication.Mailing;

namespace MailingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = CreateMailService();
            mailService.Send("huanhvtest@gmail.com", "abc123@gmail.com", "Test Subject", "Test Body");
        }

        static IEmailService CreateMailService()
        {
            //return new SmtpEmailService();

            //return new SmtpEmailService(new NetworkCredential("huanhvtest@gmail.com", "hbgfuuswchzxeiyn"), SmtpServerParams.Gmail);

            return new SmtpEmailService(new Dictionary<string, string>()
                {
                    {Constants.MailHostArgument,"smtp.gmail.com"},
                    {Constants.MailPortArgument,"587"},
                    {Constants.MailSslArgument,"true"},
                    {Constants.MailFromArgument,"huanhvtest@gmail.com"},
                    {Constants.MailPasswordArgument,"hbgfuuswchzxeiyn"},
                });
        }
    }
}
