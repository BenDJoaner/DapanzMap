﻿using System.Collections.Generic;
using UnityEngine;

namespace Dapanz
{
    public class Backpack : MonoBehaviour
    {
        public List<Skep> SkepList;

        private void Start()
        {
            foreach(Skep info in SkepList)
            {
                info.Init();
            }
        }
    }
}
