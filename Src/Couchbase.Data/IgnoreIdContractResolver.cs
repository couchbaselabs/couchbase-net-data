using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Couchbase.Data
{
    public class IgnoreIdContractResolver : DefaultContractResolver
    {
        const string IgnoreField = "Id";
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return (from x in base.CreateProperties(type, memberSerialization)
                   where x.PropertyName != IgnoreField
                   select x).ToList();
        }
    }
}
