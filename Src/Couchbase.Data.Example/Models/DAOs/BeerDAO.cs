using System.Collections.Generic;
using System.Linq;
using Couchbase.Core;
using Couchbase.Data.DAO;
using Couchbase.Data.Example.Models.DTOs;
using Couchbase.N1QL;

namespace Couchbase.Data.Example.Models.DAOs
{
    public class BeerDao : DataAccessObject<Beer>
    {
        public BeerDao(IBucket bucket)
            : base(bucket)
        {
        }

        public IEnumerable<Beer> GetAllBeers(int limit, int offset)
        {
            var queryRequest = new QueryRequest()
                 .Statement(Queries.GetAllBeersLimitOffset)
                 .AddPositionalParameter(limit)
                 .AddPositionalParameter(offset);

            return Select(queryRequest).ToList();
        }
    }
}