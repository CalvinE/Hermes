using NUnit.Framework;
using Hermes.Core.Options;
using System;
using Hermes.Core.Writers;
using System.Threading.Tasks;

namespace Tests
{
    public class Hermes_Test
    {
        private EmailWriterOptions emailWriterOptions { get; set; }

        [SetUp]
        public void Setup()
        {
            emailWriterOptions = new EmailWriterOptions()
            {
                Body = "This is a test email",
                FromAddress = "devomnitrackapp@gmail.com",
                IsHTML = false,
                MessageIdentifier = Guid.Empty.ToString(),
                SMTPHost = "smtp.gmail.com",
                SMTPPassword = "UfgdvF42T3SL7BI1sbZ3",
                SMTPPort = 587,
                SMTPUserName = "devomnitrackapp@gmail.com",
                Subject = "This is a test email",
                ToAddress = "calvin.echols@gmail.com",
                UseSSL = true
            };
        }

        [Test]
        public async Task Test1()
        {
            Hermes .Hermes hermes = new Hermes.Hermes();
            var result = await hermes.SendMessage(Hermes.Core.Enums.MessageSystemType.Email, emailWriterOptions);
            Assert.True(result.MessageSent);
        }
    }
}