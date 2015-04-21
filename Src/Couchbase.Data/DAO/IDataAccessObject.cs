using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Couchbase.Core;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Data.DAO
{
    public interface IDataAccessObject<T> where T : IDataTransferObject
    {
        IEnumerable<T> Select(IViewQuery request);

        IEnumerable<T> Select(IQueryRequest request);

        IEnumerable<T> Select(IList<string> keys);

        IEnumerable<T> Select(IList<string> keys, out ConcurrentBag<Exception> exceptions);

        T Select(string key);

        void Insert(T document);

        void Update(T document);

        void Upsert(T document);

        void Remove(T document);

        void Remove(IList<string> keys);

        void Remove(IList<string> keys, out ConcurrentBag<Exception> exceptions);

        IBucket Bucket { get; }
    }
}
