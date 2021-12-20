using PDGAApi.Net.Models.Base;
using System;
using System.Runtime.Serialization;

namespace PDGAApi.Net.Models.Exception
{
    [Serializable]
    public class APIException : ApplicationException
    {
        public APIException(BaseResponse response) : this($"{response.errtitle}: {response.errmsg}") { }

        public APIException(string message) : base(message) { }

        public APIException(string message, System.Exception innerException) : base(message, innerException) { }

        protected APIException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
