using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.IO;
using Couchbase.N1QL;
using Couchbase.Views;
using Newtonsoft.Json;

namespace Couchbase.Data.DAO
{
    public class DataAccessObject<T> : IDataAccessObject<T> where T : IDataTransferObject
    {
        public DataAccessObject(IBucket bucket)
        {
            Bucket = bucket;
        }

        public IBucket Bucket { get; private set; }

        public IEnumerable<T> Select(IList<string> keys)
        {
            var exceptions = new ConcurrentBag<Exception>();
            var results = Bucket.Get<T>(keys);
            Parallel.ForEach(results, (resultPair) =>
            {
                var result = resultPair.Value;
                if (!result.Success)
                {
                    switch (result.Status)
                    {
                        case ResponseStatus.Success:
                            break;
                        case ResponseStatus.KeyNotFound:
                            exceptions.Add(new DocumentNotFoundException(result, resultPair.Key));
                            break;
                        case ResponseStatus.AuthenticationError:
                            exceptions.Add(new CouchbaseAuthenticationException(result));
                            break;
                        case ResponseStatus.VBucketBelongsToAnotherServer:
                        case ResponseStatus.OutOfMemory:
                        case ResponseStatus.InternalError:
                        case ResponseStatus.Busy:
                        case ResponseStatus.TemporaryFailure:
                             exceptions.Add(new CouchbaseServerException(result, resultPair.Key));
                            break;
                        case ResponseStatus.ClientFailure:
                        case ResponseStatus.OperationTimeout:
                            exceptions.Add(new CouchbaseClientException(result, resultPair.Key));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            });
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
            return results.Values.Select(x=>x.Value);
        }

        public T Select(string key)
        {
            var result = Bucket.GetDocument<T>(key);
            if (!result.Success)
            {
                switch (result.Status)
                {
                    case ResponseStatus.KeyNotFound:
                        throw new DocumentNotFoundException(result, key);
                    case ResponseStatus.AuthenticationError:
                        throw new CouchbaseAuthenticationException(result);
                    case ResponseStatus.VBucketBelongsToAnotherServer:
                    case ResponseStatus.OutOfMemory:
                    case ResponseStatus.InternalError:
                    case ResponseStatus.Busy:
                    case ResponseStatus.TemporaryFailure:
                        throw new CouchbaseServerException(result, key);
                    case ResponseStatus.ClientFailure:
                    case ResponseStatus.OperationTimeout:
                        throw new CouchbaseClientException(result, key);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            SetId(result.Content, result.Document);
            return result.Content;
        }

        public void Insert(T obj)
        {
            if (string.IsNullOrEmpty(obj.Id))
            {
                throw new ArgumentException("Id must be a valid string.");
            }
            var result = Bucket.Insert(new Document<T>
            {
                Content = obj,
                Id = obj.Id
            });
            if (!result.Success)
            {
                switch (result.Status)
                {
                    case ResponseStatus.KeyExists:
                        throw new DocumentExistsException(result, obj.Id);
                    case ResponseStatus.AuthenticationError:
                        throw new CouchbaseAuthenticationException(result);
                    case ResponseStatus.ItemNotStored:
                    case ResponseStatus.VBucketBelongsToAnotherServer:
                    case ResponseStatus.OutOfMemory:
                    case ResponseStatus.InternalError:
                    case ResponseStatus.Busy:
                    case ResponseStatus.TemporaryFailure:
                        throw new CouchbaseServerException(result, obj.Id);
                    case ResponseStatus.ValueTooLarge:
                        throw new CouchbaseDataException(result);
                    case ResponseStatus.ClientFailure:
                    case ResponseStatus.OperationTimeout:
                        throw new CouchbaseClientException(result, obj.Id);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Update(T obj)
        {
            if (string.IsNullOrEmpty(obj.Id))
            {
                throw new ArgumentException("Id must be a valid string.");
            }
            var result = Bucket.Replace(new Document<T>
            {
                Content = obj,
                Cas = obj.Cas,
                Id = obj.Id
            });
            if (!result.Success)
            {
                switch (result.Status)
                {
                    case ResponseStatus.KeyNotFound:
                        throw new DocumentNotFoundException(result, obj.Id);
                    case ResponseStatus.AuthenticationError:
                        throw new CouchbaseAuthenticationException(result);
                    case ResponseStatus.ItemNotStored:
                    case ResponseStatus.VBucketBelongsToAnotherServer:
                    case ResponseStatus.OutOfMemory:
                    case ResponseStatus.InternalError:
                    case ResponseStatus.Busy:
                    case ResponseStatus.TemporaryFailure:
                        throw new CouchbaseServerException(result, obj.Id);
                    case ResponseStatus.ValueTooLarge:
                        throw new CouchbaseDataException(result, obj.Id);
                    case ResponseStatus.ClientFailure:
                    case ResponseStatus.OperationTimeout:
                        throw new CouchbaseClientException(result, obj.Id);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Upsert(T obj)
        {
            if (string.IsNullOrEmpty(obj.Id))
            {
                throw new ArgumentException("Id must be a valid string.");
            }
            var result = Bucket.Upsert(new Document<T>
            {
                Content = obj,
                Cas = obj.Cas,
                Id = obj.Id
            });
            if (!result.Success)
            {
                switch (result.Status)
                {
                    case ResponseStatus.AuthenticationError:
                        throw new CouchbaseAuthenticationException(result);
                    case ResponseStatus.ItemNotStored:
                    case ResponseStatus.VBucketBelongsToAnotherServer:
                    case ResponseStatus.OutOfMemory:
                    case ResponseStatus.InternalError:
                    case ResponseStatus.Busy:
                    case ResponseStatus.TemporaryFailure:
                        throw new CouchbaseServerException(result, obj.Id);
                    case ResponseStatus.ValueTooLarge:
                        throw new CouchbaseDataException(result, obj.Id);
                    case ResponseStatus.ClientFailure:
                    case ResponseStatus.OperationTimeout:
                        throw new CouchbaseClientException(result, obj.Id);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Remove(T obj)
        {
            if (string.IsNullOrEmpty(obj.Id))
            {
                throw new ArgumentException("Id must be a valid string.");
            }
            var result = Bucket.Remove(new Document<T>
            {
                Content = obj,
                Cas = obj.Cas
            });
            if (!result.Success)
            {
                switch (result.Status)
                {
                    case ResponseStatus.KeyNotFound:
                        throw new DocumentNotFoundException(result, obj.Id);
                    case ResponseStatus.AuthenticationError:
                        throw new CouchbaseAuthenticationException(result);
                    case ResponseStatus.ItemNotStored:
                    case ResponseStatus.VBucketBelongsToAnotherServer:
                    case ResponseStatus.OutOfMemory:
                    case ResponseStatus.InternalError:
                    case ResponseStatus.Busy:
                    case ResponseStatus.TemporaryFailure:
                        throw new CouchbaseServerException(result, obj.Id);
                    case ResponseStatus.ValueTooLarge:
                        throw new CouchbaseDataException(result, obj.Id);
                    case ResponseStatus.ClientFailure:
                    case ResponseStatus.OperationTimeout:
                        throw new CouchbaseClientException(result, obj.Id);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Remove(IList<string> keys)
        {
            var exceptions = new ConcurrentBag<Exception>();
            var results = Bucket.Remove(keys);
            Parallel.ForEach(results, (resultPair) =>
            {
                var result = resultPair.Value;
                if (!result.Success)
                {
                    switch (result.Status)
                    {
                        case ResponseStatus.KeyNotFound:
                            exceptions.Add(new DocumentNotFoundException(result, resultPair.Key));
                            break;
                        case ResponseStatus.AuthenticationError:
                            exceptions.Add(new CouchbaseAuthenticationException(result));
                            break;
                        case ResponseStatus.ItemNotStored:
                        case ResponseStatus.VBucketBelongsToAnotherServer:
                        case ResponseStatus.OutOfMemory:
                        case ResponseStatus.InternalError:
                        case ResponseStatus.Busy:
                        case ResponseStatus.TemporaryFailure:
                            exceptions.Add(new CouchbaseServerException(resultPair.Key));
                            break;
                        case ResponseStatus.ValueTooLarge:
                            exceptions.Add(new CouchbaseDataException(resultPair.Key));
                            break;
                        case ResponseStatus.ClientFailure:
                        case ResponseStatus.OperationTimeout:
                            exceptions.Add(new CouchbaseClientException(resultPair.Key));
                            break;
                        default:
                            exceptions.Add(new ArgumentOutOfRangeException());
                            break;
                    }
                }
            });
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Remove(IList<string> keys, out ConcurrentBag<Exception> exceptions)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Select(IList<string> keys, out ConcurrentBag<Exception> exceptions)
        {
            exceptions = new ConcurrentBag<Exception>();
            var bag = exceptions;

            var results = Bucket.Get<T>(keys);
            Parallel.ForEach(results, (resultPair) =>
            {
                var result = resultPair.Value;
                if (!result.Success)
                {
                    switch (result.Status)
                    {
                        case ResponseStatus.Success:
                            break;
                        case ResponseStatus.KeyNotFound:
                            bag.Add(new DocumentNotFoundException(result, resultPair.Key));
                            break;
                        case ResponseStatus.AuthenticationError:
                            bag.Add(new CouchbaseAuthenticationException(result));
                            break;
                        case ResponseStatus.VBucketBelongsToAnotherServer:
                        case ResponseStatus.OutOfMemory:
                        case ResponseStatus.InternalError:
                        case ResponseStatus.Busy:
                        case ResponseStatus.TemporaryFailure:
                            bag.Add(new CouchbaseServerException(result, resultPair.Key));
                            break;
                        case ResponseStatus.ClientFailure:
                        case ResponseStatus.OperationTimeout:
                            bag.Add(new CouchbaseClientException(result, resultPair.Key));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            });
            return results.Values.Select(x => x.Value);
        }

        public IEnumerable<T> Select(IQueryRequest request)
        {
            var results = Bucket.Query<T>(request);
            if (!results.Success)
            {
                var message = JsonConvert.SerializeObject(results.Errors);
                throw new QueryRequestException(message, results.Status);
            }
            return results.Rows;
        }

        public IEnumerable<T> Select(IViewQuery request)
        {
            var results = Bucket.Query<T>(request);
            if (!results.Success)
            {
                var message = results.Error;
                throw new ViewRequestException(message, results.StatusCode);
            }
            return results.Values;
        }

        void SetId(IDataTransferObject obj, IDocument<T> document)
        {
            obj.Id = document.Id;
        }
    }
}
