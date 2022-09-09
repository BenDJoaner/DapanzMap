using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz
{
    public class ResManager:ManagerBase
    {
        Dictionary<Type,bool> wantCacheDic = new Dictionary<Type,bool>();
        public Dictionary<string,GameObjectPoolData> gameObjectPoolDic = new Dictionary<string,GameObjectPoolData>();
        public Dictionary<string, ObjectPoolData> objectPoolDic = new Dictionary<string, ObjectPoolData>();

        public override void Init()
        {
            base.Init();

        }

        public bool CheckCacheDic(Type type)
        {
            return true;
        }

        public T LoadAsset<T>(string path) where T : UnityEngine.Object
        {
            return Resources.Load<T>(path);
        }

        public GameObject LoadGameObject(string path)
        {
            GameObject go = Resources.Load<GameObject>(path);
            return PoolManager.Instance.GetGameObject(go);
        }

        public T Load<T>() where T : class, new()
        {
            // 需要缓存
            if (CheckCacheDic(typeof(T)))
            {
                return PoolManager.Instance.GetObject<T>();
            }
            else
            {
                return new T();
            }
        }

        public T Load<T>(string path, Transform parent = null)
        {
            throw new NotImplementedException();
        }

        public void LoadGameObjectAsync<T>(string path, Action<T> callback = null,Transform parent = null)
        {

        }

        IEnumerator DoLoadGameObjectAsync<T>(string path, Action<T> callBack = null, Transform parent = null) where T : UnityEngine.Object
        {
            ResourceRequest request = Resources.LoadAsync<GameObject>(path);
            yield return request;
            GameObject go = InstantiateForPrefab(request.asset as GameObject, parent);
            callBack?.Invoke(go.GetComponent<T>());
        }

        public GameObject GetPrefab(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                return prefab;
            }
            else
            {
                throw new Exception("预制体路径有误，没有找到预制体");
            }
        }

        public GameObject InstantiateForPrefab(string path, Transform parent = null)
        {
            GameObject go = null;
            return go;
        }

        public GameObject InstantiateForPrefab(GameObject prefab,Transform parent = null)
        {
            GameObject go = null;
            return go;
        }
    }
}
