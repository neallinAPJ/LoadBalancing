using CacheManagement.Model;
using CacheManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CacheManagement.OpreationHelper
{
    public class CacheManagementController : Controller
    {
        /// <summary>
        /// 清理缓存
        /// </summary>
        /// <param name="validateKey">当前服务前的验证Key</param>
        [HttpPost]
        public void ClearCache(string validateKey)
        {
            LoadBalancingConfigurationModel LoadBalancingConfiguration = ConfigHelper.GetLoadBalancingSettings();
            var addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            string currentServerKey = LoadBalancingConfiguration.ServerList.Where(i => i.IP == HttpContext.Request.UserHostAddress
            || (addressList != null && addressList.Count() > 1 && i.IP == addressList[1].ToString())).Select(i => i.ValidateKey).FirstOrDefault();
            if (string.Compare(currentServerKey, validateKey) == 0)
            {
                ClearCurrentServiceCache(LoadBalancingConfiguration.Cache);
            }
        }
        /// <summary>
        /// 清理当前服务器的缓存
        /// </summary>
        /// <param name="cache">缓存Key集合</param>
        private static void ClearCurrentServiceCache(CacheModel cache)
        {
            foreach (var item in cache.KeyList)
            {
                System.Web.HttpRuntime.Cache.Remove(item);
            }
        }
    }
}
