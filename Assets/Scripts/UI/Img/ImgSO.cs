using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Game.Img
{
    [CreateAssetMenu(fileName = "ImgSO", menuName = "SO/ImgSO")]
    public class ImgSO : ScriptableObject
    {
        public List<ImgSaver> imgSavers = new List<ImgSaver>();
    }
    [Serializable]
    public class ImgSaver
    {
        public string name;
        public Sprite sprite;
    }
}