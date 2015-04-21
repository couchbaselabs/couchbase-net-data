using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Data.DAL;
using Newtonsoft.Json;

namespace Couchbase.Data.RepositoryExample.Models
{
    public class Beer : Document<Beer>
    {
        public string Name { get; set; }

        public int Abv { get; set; }

        public int Ibu { get; set; }

        public int Srm { get; set; }

        public int Upc { get; set; }

        public string Type { get; set; }

        [JsonProperty("brewery_id")]
        public string BreweryId { get; set; }

        public string Description { get; set; }

        public string Style { get; set; }

        public string Category { get; set; }
    }
}