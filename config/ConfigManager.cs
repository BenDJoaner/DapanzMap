using Dapanz.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class ConfigManager:ManagerBase
    {
        ConfigSetting configSetting  = new ConfigSetting();

        public T GetConfig<T>(string configTypeName, int id = 0) where T : ConfigBase
        {
            return configSetting.GetConfig<T>(configTypeName, id);
        }
    }
}
