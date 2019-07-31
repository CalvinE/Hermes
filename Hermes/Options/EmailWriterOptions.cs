using Hermes.Core.Enums;
using Hermes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailWriterOptions : IOptions, IMessageWriterOptions
    {
        public string SMTPHost { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public int SMTPPort { get; set; }
        public bool UseSSL { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public bool IsHTML { get; set; }
        public Dictionary<string, string> Placeholders { get; set; }
        public MessageSystemType MessageType { get => MessageSystemType.Email; }
        public string Body { get; set; }
        public string MessageIdentifier { get; set; }

        public EmailWriterOptions()
        {
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
            else if (string.IsNullOrEmpty(ToAddress))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(FromAddress))
            {
                return false;
            }

            return true;
        }
    }
}
