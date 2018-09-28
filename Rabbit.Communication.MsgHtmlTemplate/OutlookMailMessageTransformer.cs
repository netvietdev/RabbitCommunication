using MsgReader.Outlook;
using Rabbit.Communication.Mailing;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;

namespace Rabbit.Communication.MsgTransformers
{
    public class OutlookMailMessageTransformer : IMailMessageTransformer
    {
        private readonly Storage.Message _msg;

        /// <summary>
        /// Create new instance to process Outlook Msg file
        /// </summary>
        /// <param name="templateFile">
        /// The msg file with HTML format
        /// </param>
        public OutlookMailMessageTransformer(string templateFile)
        {
            _msg = new Storage.Message(templateFile);
        }

        public OutlookMailMessageTransformer(Stream fs)
        {
            _msg = new Storage.Message(fs);
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
            var safeBody1 = ReplaceSpecialCharacters(body);

            var transformedBody = Engine.Razor.RunCompile(safeBody1, Guid.NewGuid().ToString(), null, (object)model);
            return RevertSpecialCharacters(transformedBody);
        }

        // Because in HTML content, there are @ characters like @font-...
        private string ReplaceSpecialCharacters(string htmlBody)
        {
            return htmlBody.Replace("@Model.", "#Model.").Replace("@", "_#_#_#_#_#_").Replace("#Model.", "@Model.");
        }

        private string RevertSpecialCharacters(string htmlBody)
        {
            return htmlBody.Replace("_#_#_#_#_#_", "@");
        }
    }
}
