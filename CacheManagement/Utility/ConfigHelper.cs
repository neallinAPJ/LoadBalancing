using CacheManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManagement.Utility
{
    public class ConfigHelper
    {
        /// <summary>
        /// 读取Config文件,LoadBalancing节点的数据
        /// </summary>
        /// <returns></returns>
        public static LoadBalancingConfigurationModel GetLoadBalancingSettings()
        {
            LoadBalancingConfigurationModel loadBalancingSettings =new LoadBalancingConfigurationModel();
            loadBalancingSettings.ServerList = new List<ServerModel>();
            loadBalancingSettings.Cache = new CacheModel();
            try
            {
                LoadBalancingConfigurationSection loadBalancingSection = (LoadBalancingConfigurationSection)ConfigurationManager.GetSection("loadBalancing");
                loadBalancingSettings.ServerList = (from item in loadBalancingSection.KeyValues.Cast<ServerSetting>()
                                         select new ServerModel()
                                         {
                                             Index = item.Index,
                                             IP = item.IP,
                                             RequestUrl = item.RequestUrl,
                                             ValidateKey = item.ValidateKey
                                         }).ToList();
                loadBalancingSettings.Cache.Key = loadBalancingSection.Cache.Key;
                return loadBalancingSettings;
            }
            catch (Exception ex)
            {
                Console.Write(string.Format("Read the configuration file error, error message：{0}", ex.Message), "读取负载均衡节点");
                return loadBalancingSettings;
            }
        }
    }
}
