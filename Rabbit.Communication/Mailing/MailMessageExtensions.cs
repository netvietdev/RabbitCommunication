using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public static class MailMessageExtensions
    {
        public static MailMessage AddAttachment(this MailMessage msg, params string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                msg.Attachments.Add(new Attachment(fileName));
            }

            return msg;
        }

        public static MailMessage AddAddressesOnTo(this MailMessage msg, params string[] addresses)
        {
            foreach (var address in addresses)
            {
                msg.To.Add(address);
            }

            return msg;
        }

        public static MailMessage AddAddressesOnCc(this MailMessage msg, params string[] addresses)
        {
            foreach (var address in addresses)
            {
                msg.CC.Add(address);
            }

            return msg;
        }

        public static MailMessage AddAddressesOnBcc(this MailMessage msg, params string[] addresses)
        {
            foreach (var address in addresses)
            {
                msg.Bcc.Add(address);
            }

            return msg;
        }
    }
}