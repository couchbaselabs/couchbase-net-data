using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Couchbase.IO;

namespace Couchbase.Data
{
    public class CouchbaseDataException : Exception
    {
        public CouchbaseDataException()
        {
        }

        public CouchbaseDataException(IOperationResult result)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
        }

        public CouchbaseDataException(IDocumentResult result)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
        }

        public CouchbaseDataException(IOperationResult result, string key)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
            Key = key;
        }

        public CouchbaseDataException(IDocumentResult result, string key)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
            Key = key;
        }

        public CouchbaseDataException(string message)
            : base(message)
        {
        }

        public CouchbaseDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ResponseStatus Status { get; set; }

        public string Key { get; set; }
    }
}
