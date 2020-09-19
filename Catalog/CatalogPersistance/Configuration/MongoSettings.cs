using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogPersistance.Configuration
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
