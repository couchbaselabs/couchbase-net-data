using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Couchbase.Data.Example.Models
{
    public static class Queries
    {
        public static string GetAllBeersLimitOffset =
            "SELECT META(`beer-sample`).id, name, abv, ibu, srm, upc, type, brewery_id, updated, description, style, category " +
            "FROM `beer-sample` " +
            "ORDER BY name ASC " +
            "LIMIT $1 " +
            "OFFSET $2";

        /*
             * {
                  "name": "21A IPA",
                  "abv": 7.2,
                  "ibu": 0,
                  "srm": 0,
                  "upc": 0,
                  "type": "beer",
                  "brewery_id": "21st_amendment_brewery_cafe",
                  "updated": "2010-07-22 20:00:20",
                  "description": "Deep golden color. Citrus and piney hop aromas. Assertive malt backbone supporting the overwhelming bitterness. Dry hopped in the fermenter with four types of hops giving an explosive hop aroma. Many refer to this IPA as Nectar of the Gods. Judge for yourself. Now Available in Cans!",
                  "style": "American-Style India Pale Ale",
                  "category": "North American Ale"
                }
             */
    }
}