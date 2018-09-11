using Rabbit.Communication.Mailing;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;

namespace Rabbit.Communication.MsgTransformers
{
    public class TextFileMailMessageTransformer : IMailMessageTransformer
    {
        private readonly string _txtFile;

        /// <summary>
        /// File name is subject and its content will be the body
        /// </summary>
        public TextFileMailMessageTransformer(string txtFile)
        {
            _txtFile = txtFile;
        }

        public string GetSubject()
        {
            return Path.GetFileNameWithoutExtension(_txtFile);
        }

        public string GetSubject(dynamic model)
        {
            var subject = GetSubject();
            return Engine.Razor.RunCompile(subject, Guid.NewGuid().ToString(), null, (object)model);
        }

        public string GetHtmlBody()
        {
            return File.ReadAllText(_txtFile);
        }

        public string GetHtmlBody(dynamic model)
        {
            var body = GetHtmlBody();
            return Engine.Razor.RunCompile(body, Guid.NewGuid().ToString(), null, (object)model);
        }
    }
}