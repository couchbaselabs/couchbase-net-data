using System;
using System.Net;
using System.Runtime.Serialization;

namespace Couchbase.Data
{
    public class ViewRequestException : Exception
    {
        public ViewRequestException()
        {
        }

        public ViewRequestException(string message)
            : base(message)
        {
        }

        public ViewRequestException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }


        public ViewRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ViewRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
