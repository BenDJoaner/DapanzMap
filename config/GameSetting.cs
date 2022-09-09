using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Dapanz
{
    public class GameSetting: ConfigBase
    {
        Dictionary<Type,bool> cacheDic = new Dictionary<Type,bool>();
        Dictionary<Type,UIElement> UIElementDic = new Dictionary<Type,UIElement>();

        public void InitForEditor()
        {
            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            // 遍历程序集
            foreach (Assembly assembly in asms)
            {
                // 遍历程序集下的每一个类型
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    // 获取pool特性
                    //PoolAttribute pool = type.GetCustomAttribute<PoolAttribute>();
                    //if (pool != null)
                    //{
                        //cacheDic.Add(type, true);
                    //}
                }
            }
        }

        public void PoolAttributeOnEditor()
        {

        }

        public void UIElementAttributeEditor()
        {

        }
    }
}
