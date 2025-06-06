using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class MessageBox : UIGeneralBox<MessageBox, Message, string>
    {
        public override void GetParams(Message param)
        {
            this.param = param;
        }

        public override string SendParams()
        {
            return "关闭UI";
        }

        void Start()
        {
        }
    }

    public class Message
    {
        public Message(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string title;
        public string content;
    }
}