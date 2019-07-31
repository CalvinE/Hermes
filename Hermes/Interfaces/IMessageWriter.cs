using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Core.Interfaces
{
    public interface IMessageWriter
    {
        Task<IMessageWriterResult> SendMessage(string optionsJson, ILogger logger);
    }
}
