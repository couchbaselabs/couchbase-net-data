using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Data
{
    public class DocumentExistsException : CouchbaseDataException
    {
        public DocumentExistsException()
        {
        }

        public DocumentExistsException(string message)
            : base(message)
        {
        }

        public DocumentExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DocumentExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DocumentExistsException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public DocumentExistsException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}
