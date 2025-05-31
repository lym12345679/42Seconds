using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Traps
{
    public class WarnController : MonoBehaviour
    {
        public WarnEffect warnEffect;

        private void Start()
        {
        }

        public void Init()
        {
            warnEffect.Init();
        }
    }
}