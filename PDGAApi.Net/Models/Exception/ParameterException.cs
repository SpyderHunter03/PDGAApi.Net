using System;
using System.Runtime.Serialization;

namespace PDGAApi.Net.Models.Exception
{
    [Serializable]
    public class ParameterException : ApplicationException
    {
        public ParameterException()
        {
        }

        public ParameterException(string message) : base(message)
        {
        }

        public ParameterException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
