using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Interfaces
{
    public interface IMessageWriter
    {
        bool SendMessage(IMessageWriterOptions options);
    }
}
