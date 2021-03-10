using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz.items
{
    public class ItemManager:MonoBehaviour
    {
        public static ItemManager instance;

        public static ItemManager Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                instance = FindObjectOfType<ItemManager>();

                if (instance != null)
                    return instance;

                GameObject ItemManager = new GameObject("ItemManager");
                instance = ItemManager.AddComponent<ItemManager>();

                return instance;
            }
        }

        public Dictionary<int, Item> itemList;
        public int _itemCount;

        /// <summary>
        /// 注册item
        /// </summary>
        /// <param name="_item"></param>
        public void Register(Item _item)
        {
            for(int i = 0; i < itemList.Count; i++)
            {

            }
            _itemCount++;
            _item.sid = _itemCount;
            itemList.Add(_itemCount, _item);
        }

        /// <summary>
        /// 反注册item
        /// </summary>
        /// <param name="_item"></param>
        public void Unregister(Item _item)
        {
            if (itemList.Remove(_item.sid))
            {
                Debug.Log("移除物品成功 sid = "+ _item.sid);
            }
            else
            {
                Debug.LogError("移除物品失败！sid = "+ _item.sid);
            }
        }

        /// <summary>
        /// 获取物品 by sid
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Item GetItem(int _id)
        {
            Item resualt;
            if( itemList.TryGetValue(_id, out resualt))
            {
                return resualt;
            }
            else
            {
                Debug.LogError("找不到物品！sid = " + _id);
                return null;
            }
        }

        public Dictionary<int,Skep> skepList;
        public int skepCout;
        /// <summary>
        /// 注册容器
        /// </summary>
        /// <param name="_item"></param>
        public void Register(Skep _skep)
        {
            _itemCount++;
            _skep.id = _itemCount;
            skepList.Add(_itemCount, _skep);
        }

        /// <summary>
        /// 反注册容器
        /// </summary>
        /// <param name="_id"></param>
        public void Unregister(Skep _skep)
        {
            if (skepList.Remove(_skep.id))
            {
                Debug.Log("移除容器成功 sid = " + _skep.id);
            }
            else
            {
                Debug.LogError("移除容器失败！sid = " + _skep.id);
            }
        }

        /// <summary>
        /// 获取容器 by sid
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Skep GetSkep(int _id)
        {
            Skep resualt;
            if (skepList.TryGetValue(_id, out resualt))
            {
                return resualt;
            }
            else
            {
                Debug.LogError("找不到容器！sid = " + _id);
                return null;
            }
        }

        public void ItemInSkep(int _itemID,int _skepID)
        {
            Item targetItem = GetItem(_itemID);
            Skep targetSkep = GetSkep(_skepID);
            if (targetItem.skepID != 0)
            {
                if (targetItem.skepID == _skepID)
                {
                    return;
                }
                else
                {
                    Skep originSkep = GetSkep(targetItem.skepID);
                    originSkep.Remove(targetItem);
                }
            }

            targetSkep.Add(targetItem);
        }
    }
}
