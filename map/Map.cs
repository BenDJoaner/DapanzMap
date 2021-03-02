using System.Collections.Generic;
using UnityEngine;

namespace Dapanz.map
{
    public enum MapState
    {
        awake,
        sleep,
        unload,
    }
    public class Map:MonoBehaviour
    {
        [HideInInspector]
        public MapState preState;
        [HideInInspector]
        public MapState curSate;

        [SerializeField]
        private GameObject[] edgeMapObjects;
        [HideInInspector]
        public Dictionary<int, Map> edgeMaps;
        public int mapID;

        /// <summary>
        /// 设置等待改变的状态
        /// </summary>
        /// <param name="iState"></param>
        public void SetPreSate(MapState iState)
        {
            preState = iState;
        }

        /// <summary>
        /// 执行变成下一个状态
        /// </summary>
        public void ExcuteMapState()
        {
            if(preState != curSate)
            {
                curSate = preState;
                switch (curSate)
                {
                    case MapState.awake:
                        Wake();
                        break;
                    case MapState.sleep:
                        Sleep();
                        break;
                    case MapState.unload:
                        Unload();
                        break;
                }
            }
        }

        protected virtual void Wake()
        {
            LoadEdgeMap();
        }

        protected virtual void Sleep()
        {

        }

        protected virtual void Unload()
        {
            Destroy(gameObject);
        }

        public void LoadEdgeMap()
        {
            foreach (GameObject _obj in edgeMapObjects)
            {
                GameObject _mapObj = Instantiate(_obj);
                Map _map = _mapObj.GetComponent<Map>();
                edgeMaps.Add(_map.mapID, _map);
            }
        }
    }
}
