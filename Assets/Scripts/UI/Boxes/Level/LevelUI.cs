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

        private float timeLeft
        {
            get { return 42 - LevelManager.Instance.CurrentTime; }
        }

        private void FixedUpdate()
        {
            timeText.text = Mathf.FloorToInt(timeLeft > 0 ? timeLeft : 0).ToString();
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