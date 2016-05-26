using Rabbit.Communication.Mailing;
using System.Collections.Generic;
using System.Net;

namespace MailingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = new SmtpEmailService(new NetworkCredential("huanhvtest@gmail.com", "hbgfuuswchzxeiyn"), SmtpServerParams.Gmail);
            //var mailService = new SmtpEmailService(new NetworkCredential("***@gmail.com", "***"), SmtpClientParams.Gmail);

            mailService.Send("hhoangvan@pentalog.fr", "huanhvhd@gmail.com", "Test", "Test Body");

            mailService.Send(new KeyValuePair<string, string>("hhoangvan@pentalog.fr", "Huan HOANG"),
                new KeyValuePair<string, string>("huanhvhd@gmail.com", "Mr Huan"), "Test 2", "Test Body 2");

            //mailService.Send(new KeyValuePair<string, string>("huanhvhd@gmail.com", "Huan HOANG"),
            //    new KeyValuePair<string, string>("nguyenduonghanu@gmail.com", "Nguyen Duong"),
            //    "Test 2", "Test Body 2");
        }
    }
}
