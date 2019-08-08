using Hermes.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Interfaces
{
    public interface IMessageWriterOptions: IOptions
    {
        MessageSystemType MessageType { get; }
        string MessageIdentifier { get; set; }
        string ToString();
    }
}
