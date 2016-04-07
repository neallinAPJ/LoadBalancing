using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Model
{
    public class ServerSetting : ConfigurationElement
    {
        [ConfigurationProperty("ip", IsRequired = true)]
        public string IP
        {
            get { return this["ip"].ToString(); }
            set { this["ip"] = value; }
        }

        [ConfigurationProperty("requestUrl", IsRequired = true)]
        public string RequestUrl
        {
            get { return this["requestUrl"].ToString(); }
            set { this["requestUrl"] = value; }
        }
        [ConfigurationProperty("validateKey", IsRequired = true)]
        public string ValidateKey
        {
            get { return this["validateKey"].ToString(); }
            set { this["validateKey"] = value; }
        }
        [ConfigurationProperty("index", IsRequired = true)]
        public string Index
        {
            get { return this["index"].ToString(); }
            set { this["index"] = value; }
        }
    }
}
