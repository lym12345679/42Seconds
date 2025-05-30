using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class PauseUI : UIGeneralBox<PauseUI, string, string>
    {
        public static PauseUI Instance { get; private set; }
        [HideInInspector] public bool IsOpen = true;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            GamePlayManager.PauseGame();
        }


        public void PauseGame()
        {
            IsOpen = true;
            this.gameObject.SetActive(true);
            GamePlayManager.PauseGame();
        }

        public override void Close()
        {
            IsOpen = false;
            this.gameObject.SetActive(false);
            GamePlayManager.ResumeGame();
        }
    }
}