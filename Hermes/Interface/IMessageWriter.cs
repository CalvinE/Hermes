using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Interface
{
    public interface IMessageWriter
    {
        bool SendMessage(IMessageWriterOptions options);
    }
}
