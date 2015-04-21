using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Core;
using Couchbase.Data.DAL;
using Couchbase.N1QL;

namespace Couchbase.Data.RepositoryExample.Models.Repositories
{
    public class BreweryRepository : Repository<Brewery>
    {
        public BreweryRepository(IBucket bucket)
            : base(bucket)
        {
        }

        public IEnumerable<Brewery> SelectAllBreweries(int index, int limit)
        {
            const string statement = "SELECT * FROM `beer-sample` " +
                                     "LIMIT $1 " +
                                     "OFFSET $2;";

            return Select(new QueryRequest(statement)
                .AddPositionalParameter(index)
                .AddPositionalParameter(limit));
        }
    }
}