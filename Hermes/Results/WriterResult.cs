using Hermes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hermes.Core.Results
{
    public class WriterResult : IMessageWriterResult
    {
        public string MessageIdentifier { get; set; }
        public bool MessageSent { get; set; }
        public Exception ReasonFailed { get; set; }

        public WriterResult()
        {

        }
    }
}
