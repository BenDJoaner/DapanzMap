using System.Collections.Generic;
using UnityEngine;

namespace Dapanz
{
    public class InteractableManager:MonoBehaviour
    {
        public static InteractableManager instance;
        private List<InteractableBase> items;
        private List<InteractableBase> wakingItems;
        private InteractableBase focesItem;
        void Awake()
        {
            instance = this;
        }

        public void AddItem(InteractableBase item)
        {
            items.Add(item);
        }

        public void RemoveItem(InteractableBase item)
        {
            items.Remove(item);
        }

        /// <summary>
        ///  增加可用item
        /// </summary>
        /// <param name="item"></param>
        public void AddWakingItem(InteractableBase item)
        {
            wakingItems.Add(item);
            item.Wake();
        }

        /// <summary>
        /// 移除可用item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveWakingItem(InteractableBase item)
        {
            wakingItems.Remove(item);
            item.Sleep();
        }

        /// <summary>
        /// 聚焦item
        /// </summary>
        /// <param name="item"></param>
        public void OnItemFoces(InteractableBase item)
        {
            if (focesItem)
            {
                OnItemLostFoces(focesItem);
            }
            focesItem = item;
            focesItem.OnFocus();
        }

        /// <summary>
        /// 失焦item
        /// </summary>
        /// <param name="item"></param>
        public void OnItemLostFoces(InteractableBase item)
        {
            if(focesItem == item)
            {
                focesItem.OnLostFoces();
                focesItem = null;
            }
            else
            {
                Debug.LogError("移除焦点对象时错误！移除对象不是焦点对象！");
            }
        }
    }
}
