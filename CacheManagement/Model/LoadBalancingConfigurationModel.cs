using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class LoadBalancingConfigurationModel
    {
        public List<ServerModel> ServerList { get; set; }
        public CacheModel Cache { get; set; }
    }
}
