using Couchbase.Data.DAO;
using Newtonsoft.Json;

namespace Couchbase.Data.Tests.Documents
{
    /// <summary>
    ///     'Beer' POCO for testing
    /// </summary>
    public class Beer : DataTransferObjectBase
    {
        public string Name { get; set; }

        public decimal Abv { get; set; }

        public decimal Ibu { get; set; }

        public decimal Srm { get; set; }

        public int Upc { get; set; }

        [JsonProperty("brewery_id")]
        public string BreweryId { get; set; }

        public string Description { get; set; }

        public string Style { get; set; }

        public string Category { get; set; }
    }
}
