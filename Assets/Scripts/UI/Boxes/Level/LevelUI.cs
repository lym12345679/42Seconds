using System;
using System.Collections;
using System.Collections.Generic;
using Game.Level;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.UI
{
    public class LevelUI : UIGeneralBox<LevelUI, string, string>
    {
        public TextMeshProUGUI timeText;

        private void FixedUpdate()
        {
            timeText.text = Mathf.FloorToInt(LevelManager.Instance.CurrentTime).ToString();
        }

        public override void GetParams(string param)
        {
            base.GetParams(param);
            Debug.Log("LevelUI GetParams: " + param);
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("LevelUI Closed");
        }
    }
}