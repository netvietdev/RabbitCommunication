﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Rabbit.Communication.Mailing
{
    public class SmtpEmailService : IEmailService
    {
        private readonly ICredentialsByHost _credential;
        private readonly SmtpServerParams _parameters;
        private readonly bool _useConfigurationSettings;

        public SmtpEmailService()
        {
            _useConfigurationSettings = true;
        }

        public SmtpEmailService(IDictionary<string, string> arguments)
            : this(BuildCredential(arguments), BuildParameters(arguments))
        {
        }

        public SmtpEmailService(ICredentialsByHost credential, SmtpServerParams parameters)
        {
            _credential = credential;
            _parameters = parameters;
        }

        private static ICredentialsByHost BuildCredential(IDictionary<string, string> arguments)
        {
            ICredentialsByHost credentials = null;

            var mailFrom = arguments[Constants.MailFromArgument];
            var password = arguments[Constants.MailPasswordArgument];

            if (!string.IsNullOrWhiteSpace(password))
            {
                credentials = new NetworkCredential(mailFrom, password);
            }

            return credentials;
        }

        private static SmtpServerParams BuildParameters(IDictionary<string, string> arguments)
        {
            var host = arguments[Constants.MailHostArgument];
            var port = Convert.ToInt32(arguments[Constants.MailPortArgument]);
            var serverParams = new SmtpServerParams(host, port);

            if (arguments.ContainsKey(Constants.MailSslArgument))
            {
                var ssl = arguments[Constants.MailSslArgument];
                if (!string.IsNullOrWhiteSpace(ssl))
                {
                    serverParams.EnableSsl = Convert.ToBoolean(ssl);
                }
            }

            return serverParams;
        }

        public void Send(string from, string to, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(from, to, subject, body);
            Send(msg);
        }

        public void Send(KeyValuePair<string, string> from, KeyValuePair<string, string> to, string subject, string body)
        {
            var msg = new MailMessageBuilder().BuildMailMessage(from, to, subject, body);
            Send(msg);
        }

        public void Send(MailMessage message)
        {
            using (var client = CreateSmtpClient())
            {
                client.Send(message);
            }
        }

        private SmtpClient CreateSmtpClient()
        {
            if (_useConfigurationSettings)
            {
                return new SmtpClient();
            }

            var client = new SmtpClient(_parameters.Host, _parameters.Port)
                {
                    EnableSsl = _parameters.EnableSsl,
                    Timeout = _parameters.Timeout,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                };

            if (_credential != null)
            {
                client.UseDefaultCredentials = false;
                client.Credentials = _credential;
            }

            return client;
        }
    }
}
