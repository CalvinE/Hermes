using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Hermes.Core.Enums;
using Hermes.Core.Interfaces;
using Hermes.Core.Options;
using Hermes.Core.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hermes.Core.Writers
{
    public class EmailWriter : MessageWriter
    {
        public override MessageSystemType MessageType => MessageSystemType.Email;

        private EmailWriterOptions castOptions { get; set; }

        protected override IMessageWriterOptions performOptionsCast(string optionsJson, ILogger logger)
        {
            return JsonConvert.DeserializeObject<EmailWriterOptions>(optionsJson);
        }

        protected override async Task<IMessageWriterResult> PerformSend(IMessageWriterOptions options, ILogger logger)
        {
            EmailWriterOptions castOptions = (EmailWriterOptions)options;

            using (var smtpClient = new SmtpClient(castOptions.SMTPHost, castOptions.SMTPPort))
            {
                MailMessage message = new MailMessage(castOptions.FromAddress, castOptions.ToAddress, castOptions.Subject, castOptions.Body);
                message.IsBodyHtml = castOptions.IsHTML;
                message.Headers.Add("messageidentifier", castOptions.MessageIdentifier);
                smtpClient.EnableSsl = castOptions.UseSSL;
                smtpClient.Credentials = new System.Net.NetworkCredential(castOptions.SMTPUserName, castOptions.SMTPPassword);
                await smtpClient.SendMailAsync(message);
            }

            return new WriterResult();
        }
    }
}
