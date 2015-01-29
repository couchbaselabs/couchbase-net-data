using System;
using Couchbase.IO;

namespace Couchbase.Data.Example.Tests.Fakes
{
    public class FakeDocumentResult<T> : IDocumentResult<T>
    {
        public T Value { get; internal set; }

        public T Content { get; internal set; }

        public Document<T> Document { get; internal set; }

        public ResponseStatus Status { get; internal set; }

        public Exception Exception { get; internal set; }

        public string Message { get; internal set; }

        public bool Success { get; internal set; }
    }
}
