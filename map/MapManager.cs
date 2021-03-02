using System.Collections.Generic;
using UnityEngine;

namespace Dapanz.map
{
    public class MapManager:MonoBehaviour
    {
        public Dictionary<int, Map> loadedMap;
        public static MapManager instance;

        public static MapManager Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                instance = FindObjectOfType<MapManager>();

                if (instance != null)
                    return instance;

                GameObject MapManager = new GameObject("MapManager");
                instance = MapManager.AddComponent<MapManager>();

                return instance;
            }
        }

        /// <summary>
        /// 初始化地图管理器
        /// </summary>
        /// <param name="target"></param>
        public void Init(GameObject targetObj)
        {
            GameObject obj = GameObject.Instantiate(targetObj);
            Map target = obj.GetComponent<Map>();
            SetMapState(MapState.awake, target);
            loadedMap.Add(target.mapID, target);
            string _info = "加载新地图 >>>> \n" + target.mapID;
            _info = _info + "\n周边地图 >>>> ";
            foreach (var _map in target.edgeMaps)
            {
                string.Format("{0}\n{1}", _info, _map.Key);
                SetMapState(MapState.sleep, _map.Value);
                loadedMap.Add(_map.Key, _map.Value);
            }
            Debug.Log(_info);
        }

        /// <summary>
        /// 自动加载，进入休眠状态地图时候
        /// </summary>
        /// <param name="target"></param>
        public void ChangeMap(Map target)
        {
            if (IsLoaded(target.mapID))
            {
                //TODO：唤醒进入的地图
                string _info = "唤醒地图 >>>> \n" + target.mapID;
                SetMapState(MapState.awake, target);

                //TODO：载入新周边地图
                _info = _info + "\n加载周边地图 >>>> ";
                foreach (var _map in target.edgeMaps)
                {
                    SetMapState(MapState.sleep, _map.Value);
                    if (!IsLoaded(_map.Key))
                    {
                        string.Format("{0}\n{1} - New", _info, _map.Key);
                        loadedMap.Add(_map.Key, _map.Value);
                    }
                    else
                    {
                        string.Format("{0}\n{1} - Old", _info, _map.Key);
                    }
                }
                //TODO：卸载多余地图
                _info = _info + "卸载地图 >>>> ";
                foreach (var _map in loadedMap)
                {
                   
                    if (!target.edgeMaps.ContainsKey(_map.Key))
                    {
                        string.Format("{0}\n{1}", _info, _map.Key);
                        SetMapState(MapState.unload, _map.Value);
                        loadedMap.Remove(_map.Key);
                    }
                }
                Debug.Log(_info);
            }
            else
            {
                Debug.LogError("加载相邻地图错误！尝试使用JumpMap()加载");
                JumpMap(target.gameObject);
            }
        }

        /// <summary>
        /// 主动加载，用于加载非相邻地图，传送、进特殊地图专用
        /// </summary>
        /// <param name="targetObj"></param>
        public void JumpMap(GameObject targetObj)
        {
            if (targetObj)
            {
                //TODO：清空字典
                foreach (var _map in loadedMap)
                {
                    SetMapState(MapState.unload, _map.Value);
                }
                loadedMap.Clear();

                //TODO：重新初始化
                Init(targetObj);
            }
            else
            {
                Debug.LogError("地图对象未实例化或者不存在！");
            }
        }

        private bool IsLoaded(int _id)
        {
            return loadedMap.ContainsKey(_id);
        }

        private void SetMapState(MapState _state,Map _map)
        {
            _map.SetPreSate(_state);
            _map.ExcuteMapState();
        }
    }
}
