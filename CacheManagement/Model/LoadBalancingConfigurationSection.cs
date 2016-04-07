using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class LoadBalancingConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property = new ConfigurationProperty(string.Empty, typeof(ServerSettingCollection), null, ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public ServerSettingCollection KeyValues
        {
            get
            {
                return (ServerSettingCollection)base[s_property];
            }
        }
        [ConfigurationProperty("cache", IsRequired = true)]
        public CacheSetting Cache
        {
            get { return (CacheSetting)this["cache"]; }
        }
    }
}
