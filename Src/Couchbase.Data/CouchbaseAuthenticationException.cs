using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Data
{
    public class CouchbaseAuthenticationException : CouchbaseDataException
    {
        public CouchbaseAuthenticationException()
        {
        }

        public CouchbaseAuthenticationException (string message)
            : base(message)
        {
        }

        public CouchbaseAuthenticationException (string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseAuthenticationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CouchbaseAuthenticationException(IOperationResult result)
            : base(result)
        {
        }

        public CouchbaseAuthenticationException(IDocumentResult result)
            : base(result)
        {
        }
    }
}
