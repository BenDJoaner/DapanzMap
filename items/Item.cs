using UnityEngine;

namespace Dapanz.items
{
    public enum ItemType
    {
        NONE,//空
        MONEY,//货币
        KEY,//重要物品
        EXCHANGE,//交换物品
        UPGRADE,//升级材料
        CONSUME,//消耗品
        TOOL,//功能道具
        COLLECTION//收藏品
    }
    public class Item
    {
        public int id;
        public string m_name;
        public ItemType m_type;
        public int m_price = 1;

        [HideInInspector]
        public int m_number;
        [HideInInspector]
        public int sid;

        public void Create()
        {

        }

        public void ModifyNumber(int _value)
        {
            m_number = _value;
        }
    }
}