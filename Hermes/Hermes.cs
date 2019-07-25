using Hermes.Core.Enums;
using Hermes.Core.Interfaces;
using Hermes.Core.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Hermes
{
    public class Hermes
    {
        /// <summary>
        /// 
        /// </summary>
        private static DefaultContractResolver _defaultContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                OverrideSpecifiedNames = false
            }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool SendMessage(MessageSystemType messageType, string options)
        {
            IMessageWriterOptions castOptions = _messageSystemTypeToWriterOptionsType(messageType, options);
            return SendMessage(messageType, castOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public bool SendMessage(MessageSystemType messageType, IMessageWriterOptions options)
        {
            IMessageWriter messageWriter = _messageSystemTypeToWriterType(messageType);

            return false;
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
                    return null;
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
                        ContractResolver = _defaultContractResolver
                    });
                default:
                    throw new NotImplementedException("The message type provided does not exist or has not yet been implemented.");
            }
        }
    }
}
