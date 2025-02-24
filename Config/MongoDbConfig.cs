using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCSharpBackend.Config
{
    public class MongoDbConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}