using UnityEngine;

namespace Dapanz.data
{
    public enum ItemState
    {
        SLEAP,
        AWAKE,
    }

    public abstract class InteractableBase : MonoBehaviour
    {
        private InteractableManager manager;
        public ItemState state = ItemState.AWAKE;
        public void Init(ItemState defualtState)
        {
            state = defualtState;
            manager = InteractableManager.instance;
            manager.AddItem(this);
        }
        /// <summary>
        /// 交互
        /// </summary>
        public virtual void OnInteract() { }
        /// <summary>
        /// 焦点
        /// </summary>
        public virtual void OnFocus() { }
        /// <summary>
        /// 失焦
        /// </summary>
        public virtual void OnLostFoces() { }
        /// <summary>
        /// 休眠
        /// </summary>
        public void Sleep()
        {
            state = ItemState.SLEAP;
        }
        /// <summary>
        /// 唤醒
        /// </summary>
        public void Wake()
        {
            state = ItemState.AWAKE;
        }

        public bool Use()
        {
            if(state == ItemState.AWAKE)
            {
                OnInteract();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
