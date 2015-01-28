using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.IO;
using Couchbase.IO.Operations;

namespace Couchbase.Data.Tests.Fakes
{
    public class FakeOperationResult<T> : IOperationResult<T>
    {
        public T Value { get; internal set; }

        public ulong Cas { get; internal set; }

        public Durability Durability { get; set; }

        public ResponseStatus Status { get; internal set; }

        public Exception Exception { get; internal set; }

        public string Message { get; internal set; }

        public bool Success { get; internal set; }
    }
}
