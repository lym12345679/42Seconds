using System.Collections;
using System.Collections.Generic;
using Game.UI;
using UnityEngine;
namespace Game.UI
{
    public class TestUIManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            MessageBox.Open(new Message("测试标题", "测试内容"));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
