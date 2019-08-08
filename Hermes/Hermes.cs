using Hermes.Core;
using Hermes.Core.Enums;
using Hermes.Core.Interfaces;
using Hermes.Core.Options;
using Hermes.Core.Writers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace Hermes
{
    public class Hermes
    {

        private ILogger _defaultLogger;

        public ILogger DefaultLogger
        {
            get
            {
                if (_defaultLogger == null)
                {
                    var defaultLoggerFactory =  new LoggerFactory(new[] {
                        new ConsoleLoggerProvider((category, level) => level == LogLevel.Information, true)
                    });
                    _defaultLogger = defaultLoggerFactory.CreateLogger("Hermes");
                }
                return _defaultLogger;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<IMessageWriterResult> SendMessage(MessageSystemType messageType, string options)
        {
            IMessageWriter messageWriter = _messageSystemTypeToWriterType(messageType);
            return await messageWriter.SendMessage(options, DefaultLogger);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<IMessageWriterResult> SendMessage(MessageSystemType messageType, IMessageWriterOptions options)
        {
            return await SendMessage(messageType, options.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private IMessageWriter _messageSystemTypeToWriterType(MessageSystemType type)
        {
            switch (type)
            {
                case MessageSystemType.Email:
                    return new EmailWriter();
                default:
                    throw new NotImplementedException("The message type provided does not exist or has not yet been implemented.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private IMessageWriterOptions _messageSystemTypeToWriterOptionsType(MessageSystemType type, string options)
        {
            switch (type)
            {
                case MessageSystemType.Email:
                    return JsonConvert.DeserializeObject<EmailWriterOptions>(options, new JsonSerializerSettings()
                    {
                        ContractResolver = DeserializationStrategy.DefaultContractResolver
                    });
                default:
                    throw new NotImplementedException("The message type provided does not exist or has not yet been implemented.");
            }
        }
    }
}
