using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Dapanz.items
{
    public class Shop : MonoBehaviour
    {
        public Skep commodity;

        private void Awake()
        {
            commodity.Init();
        }
    }
}
