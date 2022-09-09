using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapanz
{
    public class SaveManagerData
    {
        // 当前的存档ID
        public int currID = 0;
        // 所有存档的列表
        public List<SaveItem> saveItemList = new List<SaveItem>();
    }
}
