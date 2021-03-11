using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dapanz.items
{
    [Serializable]
    public class Skep
    {
        private int id;
        public Dictionary<int, int> m_library;

        public int Id { get => id; }

        [Serializable]
        public struct SkepStruct
        {
            public Item entity;
            public int num;
        }

        public SkepStruct[] m_items;

        public void Init()
        {
            ItemManager.Register(this);
            foreach(SkepStruct info in m_items)
            {
                m_library.Add(info.entity.id, info.num);
                Item _item = ItemManager.GetItem(info.num);
                _item.Init();
            }
        }

        public void OnCreate(int _id)
        {
            id = _id;
        }

        public void Add(int _itemID, int _number = 1)
        {
            int curNum = 0;
            if (m_library.TryGetValue(_itemID, out curNum))
            {
                m_library[_itemID] += _number;
            }
            else
            {
                m_library.Add(_itemID, _number);
            }
        }

        public void Remove(int _itemID, int _number = 1)
        {
            int curNum = 0;
            if (m_library.TryGetValue(_itemID, out curNum))
            {
                if (curNum > _number)
                {
                    m_library[_itemID] -= _number;
                }
                else
                {
                    m_library.Remove(_itemID);
                }
            }
            else
            {
                Debug.LogError("移除物品失败，容器内不存在该物品！id=" + _itemID);
            }
        }
    }
}
