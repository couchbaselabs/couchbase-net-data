using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase;
using Couchbase.Core;
using Couchbase.Data.DAL;
using Couchbase.N1QL;
using Couchbase.Views;

namespace Couchbase.Data.RepositoryExample.Models.Repositories
{
    public class BeerRepository : Repository<Beer>
    {
        public BeerRepository(IBucket bucket)
            : base(bucket)
        {
        }

        public IEnumerable<Beer> SelectBeers(int index, int limit)
        {
            var query = Bucket.CreateQuery("beer", "brewery_beers")
                .Skip(index)
                .Limit(limit);

            return Select(query);
        }

        public IEnumerable<Beer> SelectBeerByBrewery(string brewery, int index, int limit)
        {
            const string statement = "SELECT * FROM `beer-sample`"
                                     + " WHERE type = 'beer'"
                                     + " AND brewery_id = $brewery_id"
                                     + " LIMIT $limit"
                                     + " OFFSET $offset";


            return Select(new QueryRequest(statement)
                .AddNamedParameter("$brewery_id", brewery)
                .AddNamedParameter("$offset", index)
                .AddNamedParameter("$limit", limit));
        }
    }
}