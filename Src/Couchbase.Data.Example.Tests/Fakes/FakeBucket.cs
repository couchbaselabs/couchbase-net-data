using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.Core;

namespace Couchbase.Data.Example.Tests.Fakes
{
    public class FakeBucket : IBucket
    {
        public IOperationResult<byte[]> Append(string key, byte[] value)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<string> Append(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Core.Buckets.BucketTypeEnum BucketType
        {
            get { throw new NotImplementedException(); }
        }

        public Management.IBucketManager CreateManager(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Views.IViewQuery CreateQuery(string designdoc, string view, bool development)
        {
            throw new NotImplementedException();
        }

        public Views.IViewQuery CreateQuery(string designDoc, string view)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Decrement(string key, ulong delta, ulong initial, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Decrement(string key, ulong delta, ulong initial, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Decrement(string key, ulong delta, ulong initial)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Decrement(string key, ulong delta)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Decrement(string key)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Get<T>(IList<string> keys, ParallelOptions options, int rangeSize)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Get<T>(IList<string> keys, ParallelOptions options)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Get<T>(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IOperationResult<T>> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> GetDocument<T>(string id)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> GetFromReplica<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> GetWithLock<T>(string key, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> GetWithLock<T>(string key, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Increment(string key, ulong delta, ulong initial, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Increment(string key, ulong delta, ulong initial, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Increment(string key, ulong delta, ulong initial)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Increment(string key, ulong delta)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<ulong> Increment(string key)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, TimeSpan expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, uint expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Insert<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Insert<T>(IDocument<T> document, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Insert<T>(IDocument<T> document, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Insert<T>(IDocument<T> document)
        {
            throw new NotImplementedException();
        }

        public Task<IOperationResult<T>> InsertAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool IsSecure
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public IO.Operations.ObserveResponse Observe(string key, ulong cas, bool deletion, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<byte[]> Prepend(string key, byte[] value)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<string> Prepend(string key, string value)
        {
            throw new NotImplementedException();
        }

        public N1QL.IQueryResult<T> Query<T>(N1QL.IQueryRequest queryRequest)
        {
            throw new NotImplementedException();
        }

        public N1QL.IQueryResult<T> Query<T>(string query)
        {
            throw new NotImplementedException();
        }

        public Views.IViewResult<T> Query<T>(Views.IViewQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<N1QL.IQueryResult<T>> QueryAsync<T>(N1QL.IQueryRequest queryRequest)
        {
            throw new NotImplementedException();
        }

        public Task<N1QL.IQueryResult<T>> QueryAsync<T>(string query)
        {
            throw new NotImplementedException();
        }

        public Task<Views.IViewResult<T>> QueryAsync<T>(Views.IViewQuery query)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult> Remove(IList<string> keys, ParallelOptions options, int rangeSize)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult> Remove(IList<string> keys, ParallelOptions options)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult> Remove(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key, ulong cas, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key, ulong cas, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key, ulong cas)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove(string key)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove<T>(IDocument<T> document, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove<T>(IDocument<T> document, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Remove<T>(IDocument<T> document)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, TimeSpan expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, uint expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, ulong cas)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Replace<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Replace<T>(IDocument<T> document, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Replace<T>(IDocument<T> document, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Replace<T>(IDocument<T> document)
        {
            throw new NotImplementedException();
        }

        public IOperationResult Unlock(string key, ulong cas)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Upsert<T>(IDictionary<string, T> items, ParallelOptions options, int rangeSize)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Upsert<T>(IDictionary<string, T> items, ParallelOptions options)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IOperationResult<T>> Upsert<T>(IDictionary<string, T> items)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ulong cas, TimeSpan expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, TimeSpan expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ulong cas, uint expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, uint expiration, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ulong cas, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ulong cas, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, ulong cas)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, TimeSpan expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value, uint expiration)
        {
            throw new NotImplementedException();
        }

        public IOperationResult<T> Upsert<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Upsert<T>(IDocument<T> document, ReplicateTo replicateTo, PersistTo persistTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Upsert<T>(IDocument<T> document, ReplicateTo replicateTo)
        {
            throw new NotImplementedException();
        }

        public IDocumentResult<T> Upsert<T>(IDocument<T> document)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public N1QL.IQueryRequest CreateQueryRequest(string statement)
        {
            throw new NotImplementedException();
        }


        public Task<IOperationResult<object>> RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
