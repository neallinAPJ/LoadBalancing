using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class ServerModel
    {
        public string IP { get; set; }
        public string Index { get; set; }
        public string RequestUrl { get; set; }
        public string ValidateKey { get; set; }
    }
}
