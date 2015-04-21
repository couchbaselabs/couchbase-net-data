﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Data.DAL;

namespace Couchbase.Data.RepositoryExample.Models
{
    public class Brewery : Document<Brewery>
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Code { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string Type { get; set; }

        public string Updated { get; set; }

        public string Description { get; set; }

        public List<string> Address { get; set; }

        public Geo Geo { get; set; }
    }
}