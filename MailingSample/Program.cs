using Rabbit.Communication.Mailing;
using Rabbit.Communication.MsgTransformers;

namespace MailingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = CreateMailService();
            //mailService.Send("huanhvtest@gmail.com", "abc123@gmail.com", "Test Subject", "Test Body");

            var msgTransformer = new TextFileMailMessageTransformer("../../Templates/xPhoto - Your new site created - @Model.SiteSubDomain.txt");
            var model = new
            {
                SiteSubDomain = "test.devcovery.com",
                YourName = "Huan",
                SiteId = "test",
                SiteName = "Testing Site",
            };
            mailService.Send("huanhvtest@gmail.com", "abc123@gmail.com", msgTransformer, model);
        }

        static IEmailSenderService CreateMailService()
        {
            //return new SmtpEmailService();

            //return new SmtpEmailService(new NetworkCredential("huanhvtest@gmail.com", "hbgfuuswchzxeiyn"), SmtpServerParams.Gmail);

            //return new SmtpEmailSenderService(new Dictionary<string, string>()
            //    {
            //        {Constants.MailHostArgument,"smtp.gmail.com"},
            //        {Constants.MailPortArgument,"587"},
            //        {Constants.MailSslArgument,"true"},
            //        {Constants.MailFromArgument,"huanhvtest@gmail.com"},
            //        {Constants.MailPasswordArgument,"hbgfuuswchzxeiyn"},
            //    });

            return new SmtpEmailSenderService();
        }
    }
}
