using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Data.Persistence
{
    public interface IRepository<T> where T : IDomainObject
    {
        IEnumerable<T> FindAll();

        IEnumerable<T> Find(IQueryRequest viewQuery);

        IEnumerable<T> Find(IViewQuery viewQuery);

        IEnumerable<T> Get(IList<string> keys, out ConcurrentBag<Exception> exceptions);

        IEnumerable<T> Get(IList<string> keys);

        T Get(string key);

        void Delete(T entity);

        void Save(T entity);
    }
}
