using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Couchbase.IO;

namespace Couchbase.Data.Extensions
{
    public static class DocumentResultExtensions
    {
        public static void ThrowIfNotSuccess<T>(this IDocumentResult<T> result)
        {
            if (result.Success) return;
            switch (result.Status)
            {
                case ResponseStatus.KeyNotFound:
                    throw new DocumentNotFoundException(result, result.Document.Id);
                case ResponseStatus.AuthenticationError:
                    throw new CouchbaseAuthenticationException(result);
                case ResponseStatus.ItemNotStored:
                case ResponseStatus.VBucketBelongsToAnotherServer:
                case ResponseStatus.OutOfMemory:
                case ResponseStatus.InternalError:
                case ResponseStatus.Busy:
                case ResponseStatus.TemporaryFailure:
                    throw new CouchbaseServerException(result, result.Document.Id);
                case ResponseStatus.ValueTooLarge:
                    throw new CouchbaseDataException(result);
                case ResponseStatus.ClientFailure:
                case ResponseStatus.OperationTimeout:
                    throw new CouchbaseClientException(result, result.Document.Id);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ThrowIfNotSuccess(this IOperationResult result, string key)
        {
            if (result.Success) return;
            switch (result.Status)
            {
                case ResponseStatus.KeyNotFound:
                    throw new DocumentNotFoundException(result, key);
                case ResponseStatus.AuthenticationError:
                    throw new CouchbaseAuthenticationException(result);
                case ResponseStatus.ItemNotStored:
                case ResponseStatus.VBucketBelongsToAnotherServer:
                case ResponseStatus.OutOfMemory:
                case ResponseStatus.InternalError:
                case ResponseStatus.Busy:
                case ResponseStatus.TemporaryFailure:
                    throw new CouchbaseServerException(result, key);
                case ResponseStatus.ValueTooLarge:
                    throw new CouchbaseDataException(result);
                case ResponseStatus.ClientFailure:
                case ResponseStatus.OperationTimeout:
                    throw new CouchbaseClientException(result, key);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
