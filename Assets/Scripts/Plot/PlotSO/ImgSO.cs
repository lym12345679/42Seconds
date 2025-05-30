using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Plot
{
    [CreateAssetMenu(fileName = "ImgSO", menuName = "SO/ImgSO")]
    public class ImgSO : ScriptableObject
    {
        public List<StringImg> values = new List<StringImg>();
    }

    public class StringImg
    {
        public string key;
        public Sprite value;
        public StringImg(string key, Sprite value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
