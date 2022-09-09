using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public interface IEventInfo
    {
        void Init(Action action);
        void Destroy();
        void ObjectPushPool();
    }
}
