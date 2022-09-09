using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class SaveItem
    {
        public int saveID;
        public float lastSaveTime;
        public void UpdateTime(DateTime lastSaveTime)
        {

        }

        public SaveItem(int saveID, float lastSaveTime)
        {
            this.saveID = saveID;
            this.lastSaveTime = lastSaveTime;
        }
    }
}
