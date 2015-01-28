using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Data
{
    public class DocumentNotFoundException : CouchbaseDataException
    {
        public DocumentNotFoundException()
        {
        }

        public DocumentNotFoundException(string message)
            : base(message)
        {
        }

        public DocumentNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DocumentNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DocumentNotFoundException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public DocumentNotFoundException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}
