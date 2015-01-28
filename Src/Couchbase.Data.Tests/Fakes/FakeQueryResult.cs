using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.N1QL;
using Newtonsoft.Json;

namespace Couchbase.Data.Tests.Fakes
{
    public class FakeQueryResult<T> : IQueryResult<T>
    {
        public FakeQueryResult()
        {
           Rows = new List<T>();
           Errors = new List<Error>();
            Warnings = new List<Warning>();
        }

        /// <summary>
        /// True if query was successful.
        /// </summary>
        public bool Success { get; internal set; }

        /// <summary>
        /// Optional message returned by query engine or client
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        /// If Success is false and an exception has been caught internally, this field will contain the exception.
        /// </summary>
        public Exception Exception { get; set; }

        [JsonProperty("request_id")]
        public Guid RequestId { get; internal set; }

        [JsonProperty("client_context_id")]
        public string ClientContextId { get; internal set; }

        [JsonProperty("signature")]
        public dynamic Signature { get; internal set; }

        [JsonProperty("results")]
        public List<T> Rows { get; internal set; }

        [JsonProperty("status")]
        public QueryStatus Status { get; internal set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; internal set; }

        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; internal set; }

        [JsonProperty("metrics")]
        public Metrics Metrics { get; internal set; }
    }
}
