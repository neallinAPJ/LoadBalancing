using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class CacheSetting : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }
    }
}
