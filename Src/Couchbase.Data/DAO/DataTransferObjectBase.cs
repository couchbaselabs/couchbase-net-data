using Newtonsoft.Json;

namespace Couchbase.Data.DAO
{
    public class DataTransferObjectBase : IDataTransferObject
    {
        private static string _typeName;

        public DataTransferObjectBase()
        {
            if (_typeName == null)
            {
                _typeName = GetType().Name;
            }
            Type = _typeName;
        }

        public virtual string Id { get; set; }

        public string Type { get; set; }

        [JsonIgnore]
        public uint Cas { get; set; }
    }
}