using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CacheManagement.Model;
using System.Configuration;
using System.Web;
using System.Net.Http.Formatting;
using System.Web.Security;
using CacheManagement.Utility;

namespace CacheManagement
{
    public class CacheManagementHelper
    {
        public static string ActionName = "/ClearCache?key={0}";
        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearCache()
        {
            LoadBalancingConfigurationModel LoadBalancingConfiguration = ConfigHelper.GetLoadBalancingSettings();
            ClearCurrentServiceCache(LoadBalancingConfiguration.Cache);
            foreach (var server in LoadBalancingConfiguration.ServerList)
            {
                try
                {
                    var addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                    if (HttpContext.Current.Request.UserHostAddress == server.IP || (addressList != null && addressList.Count() > 1 && addressList[1].ToString() == server.IP))
                    {
                        continue;
                    }
                    IDictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("validateKey", server.ValidateKey);
                    WebRequestUtility.CreatePostHttpResponse(server.RequestUrl, parameters, null, null, Encoding.UTF8, null);
                }
                catch(Exception ex)
                {
                    throw ex;
                } 
            }
        }
        /// <summary>
        /// 清理当前服务器的缓存
        /// </summary>
        /// <param name="cache">缓存Key集合</param>
        private static void ClearCurrentServiceCache(CacheModel cache)
        {
            foreach(var item in cache.KeyList)
            {
                System.Web.HttpRuntime.Cache.Remove(item);
            }
        }
    }
}
