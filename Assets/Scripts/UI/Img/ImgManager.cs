using System.Collections.Generic;
using Game.Instance;
using UnityEngine;

namespace Game.Img
{
    public class ImgManager : GeneralInstance<ImgManager>
    {
        public ImgSO imgSO;

        public Dictionary<string, Sprite> imgDict = new Dictionary<string, Sprite>();

        //在这里注册图片SO或字典,
        public ImgManager()
        {
            RigisterAction();
        }

        private void RigisterAction()
        {
            RigisterImg(Resources.Load<ImgSO>("SO/Img/ImgSO"));
        }

        private void RigisterImg(ImgSO imgSO)
        {
            foreach (var imgSaver in imgSO.imgSavers)
            {
                imgDict.Add(imgSaver.name, imgSaver.sprite);
            }
        }

        public Sprite GetImg(string name)
        {
            if (imgDict.ContainsKey(name))
            {
                return imgDict[name];
            }
            else
            {
                Debug.LogError("未找到图片:" + name);
                return null;
            }
        }
    }
}