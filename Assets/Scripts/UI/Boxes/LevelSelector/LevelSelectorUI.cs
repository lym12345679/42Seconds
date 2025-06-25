using System;
using System.Collections;
using System.Collections.Generic;
using Game.Plot;
using Game.Scene;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class LevelSelectorUI : UIGeneralBox<LevelSelectorUI, string, string>
    {
        public static LevelSelectorUI Instance { get; private set; }
        public List<LevelSelectorUIBtn> LevelSelectorUIBtns = new List<LevelSelectorUIBtn>();
        public TextMeshProUGUI BackToMenuBtnText, ReportText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            BackToMenuBtnText.text = PlotDict.Instance.GetUIDict("Main Menu");
            ReportText.text = PlotDict.Instance.GetUIDict("Lab Report");
        }

        public override void GetParams(string param)
        {
            base.GetParams(param);
            //Debug.Log("LevelSelectorUI GetParams: " + param);
        }

        public override void Close()
        {
            base.Close();
            //Debug.Log("LevelSelectorUI Closed");
        }

        public void GoToLevel(SceneType scene)
        {
            GamePlayManager.LoadScene(scene);
        }

        public void GoToMenu()
        {
            GamePlayManager.LoadScene(SceneType.Menu);
        }
    }
}