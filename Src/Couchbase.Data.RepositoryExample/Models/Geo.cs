using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Data.DAL;
using Newtonsoft.Json;

namespace Couchbase.Data.RepositoryExample.Models
{
    public class Geo : Document<Geo>
    {
        public string Accuracy { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }
    }
}