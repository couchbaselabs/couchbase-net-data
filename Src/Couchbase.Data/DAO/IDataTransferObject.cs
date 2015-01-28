using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Annotations;

namespace Couchbase.Data.DAO
{
    public interface IDataTransferObject
    {
        string Id { get; set; }

        string Type { get; set; }

        uint Cas { get; set; }
    }
}
