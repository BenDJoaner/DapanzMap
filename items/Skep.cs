using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dapanz.items
{
    [Serializable]
    public class Skep
    {
        public int id;
        public ItemType m_type = ItemType.NONE;
        public List<Item> items;

        Skep()
        {
            m_type = ItemType.NONE;
            items = new List<Item>();
            ItemManager.Instance.Register(this);
        }

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
            _item.skepID = id;
        }

        public void Remove(Item _item)
        {
            if (items.Contains(_item))
            {
                items.Remove(_item);
                _item.skepID = 0;
            }
            else
            {
                Debug.LogError("移除物品失败，容器内不存在该物品！id="+ _item.id);
            }
        }
    }
}
