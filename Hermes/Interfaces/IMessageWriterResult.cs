using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Interfaces
{
    public interface IMessageWriterResult
    {
        string MessageIdentifier { get; set; }
        bool MessageSent { get; set; }
        Exception ReasonFailed { get; set; }
    }
}
