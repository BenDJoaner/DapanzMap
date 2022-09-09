using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class EventManager
    {
        static Dictionary<string, IEventInfo> eventInfoDic = new Dictionary<string, IEventInfo>();

        public static void AddEventListener(string eventName,Action action)
        {
            // 有没有对应的事件可以监听
            if (eventInfoDic.ContainsKey(eventName))
            {
                (eventInfoDic[eventName] as EventInfo).action += action;
            }
            // 没有的话，需要新增到字典中，并添加对应的Action
            else
            {
                EventInfo eventInfo = PoolManager.Instance.GetObject<EventInfo>();
                eventInfo.Init(action);
                eventInfoDic.Add(eventName, eventInfo);
            }
        }

        public static void RemoveListener(string eventName)
        {
            if (eventInfoDic.ContainsKey(eventName))
            {
                eventInfoDic[eventName].Destroy();
                eventInfoDic.Remove(eventName);
            }
        }

        public static void Trigger(string eventName)
        {
            if (eventInfoDic.ContainsKey(eventName))
            {
                (eventInfoDic[eventName] as EventInfo).action?.Invoke();
            }
        }

        public static void Clear()
        {
            foreach (var item in eventInfoDic)
            {
                item.Value.Destroy();
            }
            eventInfoDic.Clear();
        }
    }
}
