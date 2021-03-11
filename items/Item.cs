using System;
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
        public Sprite m_icon;

        private int sid;

        public int Sid { get => sid; }

        public void Init()
        {
            ItemManager.Register(this);
        }

        public void OnCreate(int _sid)
        {
            sid = _sid;
        }
    }
}