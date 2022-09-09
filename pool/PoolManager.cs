using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz
{
    public class PoolManager:ManagerBase
    {
        public static PoolManager Instance;
        GameObject poolRootObj = new GameObject();
        public Dictionary<string,GameObjectPoolData> gameObjectPoolDic = new Dictionary<string,GameObjectPoolData>();
        public Dictionary<string, ObjectPoolData> objectPoolDic = new Dictionary<string,ObjectPoolData>();

        public GameObject GetGameObject(string path, Transform parent = null)
        {
            GameObject obj = null;


            return obj;
        }

        public GameObject GetGameObject(GameObject prefab, Transform parent = null)
        {
            GameObject obj = null;
            string name = prefab.name;
            // 检查有没有这一层
            if (CheckGameObjectCache(prefab))
            {
                obj = gameObjectPoolDic[name].GetObj(parent);
            }
            // 没有的话给你实例化一个
            else
            {
                // 确保实例化后的游戏物体和预制体名称一致
                obj = GameObject.Instantiate(prefab, parent);
                obj.name = name;
            }
            return obj;
        }

        public void PushGameObject(GameObject obj)
        {
            string name = obj.name;
            // 现在有没有这一层
            if (gameObjectPoolDic.ContainsKey(name))
            {
                gameObjectPoolDic[name].PushObj(obj);
            }
            else
            {
                gameObjectPoolDic.Add(name, new GameObjectPoolData(obj, poolRootObj));
            }
        }

        public bool CheckGameObjectCache(GameObject prebfa)
        {
            return true;
        }

        public GameObject CheckCacheAndLoadGameObject(string path,Transform parent = null)
        {
            return null;
        }

        public T GetObject<T>()
        {
            throw new NotImplementedException();
        }

        public void PushObjecct(object obj)
        {

        }

        public bool CheckObjectCache<T>()
        {
            throw new NotImplementedException();
        }
    }
}
