using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz
{
    public class ItemManager:MonoBehaviour
    {
        private static ItemManager instance;

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

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        public Dictionary<int, Item> itemList;
        public int _itemCount;

        /// <summary>
        /// 注册item
        /// </summary>
        /// <param name="_item"></param>
        public static void Register(Item _item)
        {
            for(int i = 0; i <= Instance.itemList.Count; i++)
            {
                if (!Instance.itemList.ContainsKey(i))
                {
                    Instance.itemList.Add(i, _item);
                    _item.OnCreate(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 反注册item
        /// </summary>
        /// <param name="_item"></param>
        public static void Unregister(Item _item)
        {
            if (Instance.itemList.Remove(_item.Sid))
            {
                Debug.Log("移除物品成功 sid = "+ _item.Sid);
            }
            else
            {
                Debug.LogError("移除物品失败！sid = "+ _item.Sid);
            }
        }

        /// <summary>
        /// 获取物品 by sid
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static Item GetItem(int _id)
        {
            Item resualt;
            if( Instance.itemList.TryGetValue(_id, out resualt))
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
        public static void Register(Skep _skep)
        {
            for (int i = 0; i <= Instance.skepList.Count; i++)
            {
                if (!Instance.skepList.ContainsKey(i))
                {
                    Instance.skepList.Add(i, _skep);
                    _skep.OnCreate(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 反注册容器
        /// </summary>
        /// <param name="_id"></param>
        public static void Unregister(Skep _skep)
        {
            if (Instance.skepList.Remove(_skep.Id))
            {
                Debug.Log("移除容器成功 sid = " + _skep.Id);
            }
            else
            {
                Debug.LogError("移除容器失败！sid = " + _skep.Id);
            }
        }

        /// <summary>
        /// 获取容器 by sid
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static Skep GetSkep(int _id)
        {
            Skep resualt;
            if (Instance.skepList.TryGetValue(_id, out resualt))
            {
                return resualt;
            }
            else
            {
                Debug.LogError("找不到容器！sid = " + _id);
                return null;
            }
        }
    }
}
