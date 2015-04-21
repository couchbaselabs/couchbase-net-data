﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couchbase.Data.DAL
{
    public interface IEntity
    {
        string Id { get; set; }

        string Type { get; set; }

        uint Cas { get; set; }
    }
}
