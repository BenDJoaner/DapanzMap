using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class EventInfo : IEventInfo
    {
        public Action action;
        public void Init(Action action)
        {
            this.action = action;
        }

        public void Destroy()
        {
            action = null;
            this.ObjectPushPool();
        }

        public void ObjectPushPool()
        {
            throw new NotImplementedException();
        }
    }
}
