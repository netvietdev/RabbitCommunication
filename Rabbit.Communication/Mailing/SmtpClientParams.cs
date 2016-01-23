﻿namespace Rabbit.Communication.Mailing
{
    public class SmtpClientParams
    {
        private readonly string _host;
        private readonly int _port;

        public SmtpClientParams(string host, int port)
        {
            _host = host;
            _port = port;
            Timeout = 20000;
        }

        public static SmtpClientParams Gmail
        {
            get
            {
                return new SmtpClientParams("smtp.gmail.com", 587)
                {
                    EnableSsl = true
                };
            }
        }

        public string Host
        {
            get { return _host; }
        }

        public int Port
        {
            get { return _port; }
        }

        public bool EnableSsl
        {
            get;
            set;
        }

        public int Timeout
        {
            get;
            set;
        }
    }
}