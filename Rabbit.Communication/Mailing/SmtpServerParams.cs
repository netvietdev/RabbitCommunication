namespace Rabbit.Communication.Mailing
{
    public class SmtpServerParams
    {
        private readonly string _host;
        private readonly int _port;

        public SmtpServerParams(string host, int port)
        {
            _host = host;
            _port = port;
            Timeout = 20000;
        }

        #region Preconfigured servers

        public static SmtpServerParams Gmail
        {
            get
            {
                return new SmtpServerParams("smtp.gmail.com", 587)
                {
                    EnableSsl = true
                };
            }
        }
        
        #endregion

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