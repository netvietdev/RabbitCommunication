using MsgReader.Outlook;
using Rabbit.Communication.Mailing;
using RazorEngine;
using RazorEngine.Templating;
using System;

namespace Rabbit.Communication.MsgTransformers
{
    public class OutlookMailMessageTransformer : IMailMessageTransformer
    {
        private readonly Storage.Message _msg;

        public OutlookMailMessageTransformer(string templateFile)
        {
            _msg = new Storage.Message(templateFile);
        }

        public string GetSubject()
        {
            return _msg.Subject;
        }

        public string GetHtmlBody()
        {
            return _msg.BodyHtml;
        }

        public string GetSubject(dynamic model)
        {
            var subject = GetSubject();
            return Engine.Razor.RunCompile(subject, Guid.NewGuid().ToString(), null, (object)model);
        }

        public string GetHtmlBody(dynamic model)
        {
            var body = GetHtmlBody();
            return Engine.Razor.RunCompile(body, Guid.NewGuid().ToString(), null, (object)model);
        }
    }
}
