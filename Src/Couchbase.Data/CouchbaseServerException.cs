using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Data
{
   public class CouchbaseServerException : CouchbaseDataException
    {
        public CouchbaseServerException()
        {
        }

        public CouchbaseServerException(string message)
            : base(message)
        {
        }

        public CouchbaseServerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CouchbaseServerException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public CouchbaseServerException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}
