using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NoobasStudio.Exceptions
{
    public class InvalidSubsException : Exception
    {
        public InvalidSubsException()
        {
        }

        public InvalidSubsException(string message) : base(message)
        {
        }

        public InvalidSubsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSubsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
