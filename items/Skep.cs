using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dapanz.items
{
    public class Skep:MonoBehaviour
    {
        public int id;
        public ItemType m_type = ItemType.NONE;
        public List<Item> items;

        public void Add(Item _item)
        {
            if (m_type == ItemType.NONE)
            {
                m_type = _item.m_type;
            }
            else if(m_type != _item.m_type)
            {
                Debug.Log("添加物品失败！Skep类型为："+m_type+" item类型为："+_item.m_type);
                return;
            }

            items.Add(_item);
        }
    }
}
