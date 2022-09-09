using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class ObjectPoolData
    {
        public Queue<object> poolQueue;
        public Dictionary<string, ObjectPoolData> objectPoolDic = new Dictionary<string, ObjectPoolData>();

        public ObjectPoolData(object obj)
        {

        }

        public void PushObj(object obj)
        {

        }

        public object GetObj()
        {
            return null;
        }
    }
}
