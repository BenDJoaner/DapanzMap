using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Dapanz
{
    public class GameRoot : MonoBehaviour
    {
        public static GameRoot Instance;

        protected void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitManagers();
        }
        private void InitManagers()
        {
            ManagerBase[] managers = GetComponents<ManagerBase>();
            for (int i = 0; i < managers.Length; i++)
            {
                managers[i].Init();
            }
        }

        //#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        public static void InitForEditor()
        {
            // 当前是否要进行播放或准备播放中
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }
            if (Instance == null && GameObject.Find("GameRoot") != null)
            {
                Instance = GameObject.Find("GameRoot").GetComponent<GameRoot>();
                // 清空事件
                EventManager.Clear();
                Instance.InitManagers();
                //Instance.GameSetting.InitForEditor();
                //UI_WindowBase[] window = In          stance.transform.GetComponentsInChil dren<UI_WindowBase>();
                //foreach (UI_WindowBase win in window)
                //{
                //    win.OnShow();
                //}
            }
        }
        //#endif
    }

}
