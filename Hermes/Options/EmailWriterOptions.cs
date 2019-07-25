using Hermes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailWriterOptions : IOptions
    {
        public string SMTPHost { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public int SMTPPort { get; set; }
        public bool UseSSL { get; set; }
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHTML { get; set; }
        public Dictionary<string, string> Placeholders;

        public EmailWriterOptions()
        {
            Recipients = new List<string>();
            Placeholders = new Dictionary<string, string>();
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(SMTPHost))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(SMTPUserName))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(SMTPPassword))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(Body))
            {
                return false;
            }
            else if (SMTPPort <= 0)
            {
                return false;
            }
            else if (Recipients.Count < 1)
            {
                return false;
            }

            return true;
        }
    }
}
