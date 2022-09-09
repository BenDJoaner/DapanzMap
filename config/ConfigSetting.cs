using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz.config
{
    public class ConfigSetting:ConfigBase
    {
        public Dictionary<string,Dictionary<int,ConfigBase>> configDic = new Dictionary<string,Dictionary<int,ConfigBase>>();

        public T GetConfig<T>(string configTypeName, int id) where T : ConfigBase
        {
            // 检查类型
            if (!configDic.ContainsKey(configTypeName))
            {
                throw new System.Exception("配置设置中不包含这个Key:" + configTypeName);
            }
            // 检查ID
            if (!configDic[configTypeName].ContainsKey(id))
            {
                throw new System.Exception($"配置设置中{configTypeName}不包含这个ID:{id}");
            }
            // 说明一切正常
            return configDic[configTypeName][id] as T;
        }
    }
}
