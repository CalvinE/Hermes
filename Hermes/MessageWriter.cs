using Hermes.Core.Enums;
using Hermes.Core.Interfaces;
using Hermes.Core.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Core
{
    public abstract class MessageWriter : IMessageWriter
    {
        public abstract MessageSystemType MessageType { get; }

        public async Task<IMessageWriterResult> SendMessage(string optionsJson, ILogger logger)
        {
            logger.LogTrace("Starting SendMessage");
            IMessageWriterOptions options = null;
            IMessageWriterResult Result = null;
            try
            {
                options = performOptionsCast(optionsJson, logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to cast message options json into an object!");
                Result = new WriterResult()
                {
                    MessageIdentifier = null,
                    MessageSent = false,
                    ReasonFailed = ex
                };
            }
            if (options != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(options.MessageIdentifier))
                    {
                        var messageIdentifier = Guid.NewGuid().ToString();
                        logger.LogDebug($"The options object was missing a message identifier... Using generated identifier: {messageIdentifier}");
                        options.MessageIdentifier = messageIdentifier;
                    }

                    if (!options.IsValid())
                    {
                        throw new ArgumentException("Ohe value is not valid", "options");
                    }
                    logger.LogDebug($"About to attempt sending a message. type = {options.MessageType} : id = {options.MessageIdentifier}");
                    Result = await PerformSend(options, logger);
                    logger.LogDebug($"Finished sending, success = {Result.MessageSent}");
                    Result = new WriterResult()
                    {
                        MessageIdentifier = options.MessageIdentifier,
                        MessageSent = true,
                        ReasonFailed = null
                    };
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "SendMessage threw an error!");
                    Result = new WriterResult()
                    {
                        MessageIdentifier = options.MessageIdentifier,
                        MessageSent = false,
                        ReasonFailed = ex
                    };
                }
            }
            logger.LogTrace("Ending SendMessage");
            return Result;
        }

        protected abstract Task<IMessageWriterResult> PerformSend(IMessageWriterOptions options, ILogger logger);
        
        protected abstract IMessageWriterOptions performOptionsCast(string options, ILogger logger);
    }
}
