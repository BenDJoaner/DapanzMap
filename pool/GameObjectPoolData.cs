using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz
{
    public class GameObjectPoolData
    {
        public GameObject fatherObj;
        public Queue<GameObject> poolQueu;

        public GameObjectPoolData(GameObject obj, GameObject poolRootObj)
        {

        }

        public void PushObj(GameObject obj)
        {

        }

        public GameObject GetObj(Transform parent = null)
        {
            return null;
        }
    }
}
