using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Interfaces
{
    interface IMessageReader<T>
    {
        IEnumerable<T> RetreiveMessages(IMessageReaderOptions options);
    }
}
