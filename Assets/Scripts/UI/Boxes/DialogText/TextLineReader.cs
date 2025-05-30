using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.TextShow
{
    public class TextLineReader
    {
        public Sprite ShownItemSprite;
        public string dialogText;
        public bool canRead = true;
        private Stack<TextLineWord> words = new Stack<TextLineWord>();
        private Action<TextMeshProUGUI> currentWordHander;

        private Dictionary<string, ImgSetter> imgDict = new Dictionary<string, ImgSetter>
        {
            { "leftimg", new ImgSetter() },
            { "rightimg", new ImgSetter() },
            { "centerimg", new ImgSetter() },
            { "background", new ImgSetter() }
        };

        Action specialFunc;
        private string id;
        private string nextId;

        public TextLineReader(string textLine)
        {
            ReadTextLines(textLine);
        }

        //读取文本行
        private void ReadTextLines(string textLine)
        {
            dialogText = textLine;
            if (!dialogText.Contains("<#"))
            {
                for (int i = 0; i < dialogText.Length; i++)
                {
                    words.Push(new TextLineWord(dialogText[i].ToString()));
                }
            }
            else
            {
                int startIndex = 0;
                int endIndex = 0;
                while (startIndex < dialogText.Length)
                {
                    if (!ReadTextLine(ref startIndex, ref endIndex))
                    {
                        break;
                    }
                }
            }
        }

        //读取并解析文本指令
        private bool ReadTextLine(ref int startIndex, ref int endIndex)
        {
            if (dialogText[startIndex] == '<')
            {
                endIndex = dialogText.IndexOf('>', startIndex);
                //如果结束符号之前还有<符号，则再次往下寻找一个>符号
                while (endIndex != -1 && dialogText.IndexOf('<', startIndex + 1) < endIndex &&
                       dialogText.IndexOf('<', startIndex + 1) != -1)
                {
                    startIndex = dialogText.IndexOf('<', startIndex + 1);
                    endIndex = dialogText.IndexOf('>', startIndex);
                }

                if (endIndex == -1)
                {
                    canRead = false;
                    Debug.LogError("文本格式错误，未找到结束符号>,文本内容:" + dialogText);
                    return false;
                }

                //Debug.Log("startIndex:" + startIndex + " endIndex:" + endIndex);
                currentWordHander = SetWordHander(dialogText.Substring(startIndex, endIndex - startIndex + 1));
                dialogText = dialogText.Remove(startIndex, endIndex - startIndex + 1);
            }
            else
            {
                words.Push(new TextLineWord(dialogText[startIndex].ToString(),
                    currentWordHander == null ? null : currentWordHander));
                startIndex++;
            }

            return true;
        }

        #region 数据处理

        //设置
        private Action<TextMeshProUGUI> SetWordHander(string text)
        {
            if (text[0] == '<')
            {
                text = text.Remove(0, 1);
            }

            if (text[text.Length - 1] == '>')
            {
                text = text.Remove(text.Length - 1, 1);
            }

            if (text[0] == '#')
            {
                text = text.Remove(0, 1);
            }

            //List<string> textList = SplitTool(text);
            //如果文本为default，则返回null,使用默认的文本处理方法
            if (text.ToLower() == "default")
            {
                return null;
            }

            string[] texts = System.Text.RegularExpressions.Regex.Split(text, "#(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            Action<TextMeshProUGUI> newWordHander = (t) => { };
            //Debug.Log(texts.Length);
            foreach (string t in texts)
            {
                //Debug.Log("SetWordHander:" + t);
                newWordHander += FuncSelector(t);
            }

            return newWordHander;
        }

        //设置文本处理方法，允许"<>"的嵌套
        private List<string> SplitTool(string text, char splitChar = '#')
        {
            int startIndex = 0, endIndex, flag = 0;
            text = text.Replace(" ", "");
            List<string> textList = new List<string>();

            text += splitChar.ToString();
            while (startIndex < text.Length)
            {
                if (text[startIndex] == splitChar)
                {
                    //遇上#号，则将该行文本放入列表中
                    //Debug.Log("flag:" + flag + " startIndex:" + startIndex);
                    textList.Add(text.Substring(flag, startIndex - flag));
                    //Debug.Log("texts:" + textList[0]);
                    //Debug.Log("text:" + text);
                    flag = startIndex + 1;
                }
                else if (text[startIndex] == '<')
                {
                    endIndex = text.IndexOf('>', startIndex);
                    //如果结束符号之前还有<符号，则再次往下寻找一个>符号
                    while (endIndex != -1 && dialogText.IndexOf('<', startIndex + 1) < endIndex &&
                           dialogText.IndexOf('<', startIndex + 1) != -1)
                    {
                        startIndex = dialogText.IndexOf('<', startIndex + 1);
                        endIndex = dialogText.IndexOf('>', startIndex);
                    }

                    if (endIndex == -1)
                    {
                        canRead = false;
                        Debug.LogError("文本格式错误，未找到结束符号>,文本内容:" + dialogText);
                        return null;
                    }

                    startIndex = endIndex;
                }

                startIndex++;
            }

            return textList;
        }

        private List<string> SplitToTwoText(string text, char splitChar = '#')
        {
            //Debug.Log("SplitToTwoText:" + text);
            int startIndex = text.IndexOf(splitChar);
            List<string> texts = new List<string>();
            if (startIndex != -1)
            {
                texts.Add(text.Substring(0, startIndex));
                texts.Add(text.Substring(startIndex + 1, text.Length - startIndex - 1));
            }
            else
            {
                texts.Add(text);
                texts.Add("");
            }

            return texts;
        }

        #endregion

        #region 功能选择器

        private Action<TextMeshProUGUI> FuncSelector(string text)
        {
            List<string> lines = SplitToTwoText(text, '=');
            //Debug.Log("FuncSelector:" + lines[0] + " " + lines[1]);
            switch (lines[0])
            {
                case "color":
                {
                    Color color = ColorSelector(lines[1]);
                    return (t) => { t.color = color; };
                }
                case "fontsize":
                {
                    int fontSize = int.Parse(lines[1]);
                    return (t) => { t.fontSize = fontSize; };
                }
                case "fontstyle":
                {
                    FontStyles fontStyle = FontStyleSelector(lines[1]);
                    return (t) => { t.fontStyle = fontStyle; };
                }
                case "leftimg":
                case "rightimg":
                case "centerimg":
                case "background":
                {
                    //Debug.Log("SetImg:" + lines[0] + " " + lines[1]);
                    SetImg(lines[0], lines[1]);
                    break;
                }
                case "id":
                {
                    id = lines[1].Trim();
                    break;
                }
                case "nextid":
                {
                    nextId = lines[1].Trim();
                    break;
                }
                default:
                {
                    Debug.LogWarning("未找到对应的指令处理方法，指令内容：" + text + ",错误文本:" + dialogText);
                    return null;
                }
            }

            return null;
        }

        #endregion

        #region 字体样式选择器

        private FontStyles FontStyleSelector(string v)
        {
            switch (v.ToLower())
            {
                case "bold":
                    return FontStyles.Bold;
                case "italic":
                    return FontStyles.Italic;
                case "underline":
                    return FontStyles.Underline;
                case "strikethrough":
                    return FontStyles.Strikethrough;
                default:
                    return FontStyles.Normal;
            }
        }

        private Color ColorSelector(string v)
        {
            //Debug.Log("ColorSelector:" + v);
            v = v.Replace("(", "").Replace(")", "");
            string[] colors = v.Split(',');
            float a = 1f, r, g, b;
            if (colors.Length == 4)
            {
                a = int.Parse(colors[3]) / 255f;
            }

            if (colors.Length == 3 || colors.Length == 4)
            {
                //Debug.Log("ColorSelector:" + colors[0] + " " + colors[1] + " " + colors[2]);
                r = int.Parse(colors[0]) / 255f;
                g = int.Parse(colors[1]) / 255f;
                b = int.Parse(colors[2]) / 255f;
                return new Color(r, g, b, a);
            }
            else
            {
                Debug.LogWarning("颜色格式错误，颜色值：" + v + " 错误文本:" + dialogText + " 请使用RGB或RGBA格式");
                return Color.black;
            }
        }

        #endregion

        #region 图片设置

        //设置图片名称
        private void SetImg(string targetImg, string text)
        {
            //Debug.Log("SetImg:" + targetImg + " " + text);
            text = text.Replace("(", "").Replace(")", "");
            string[] imgInfo = text.Split(',');
            switch (imgInfo.Length)
            {
                case 1:
                {
                    imgDict[targetImg].imgName = imgInfo[0];
                    //Debug.Log("SetImg:" + targetImg + " " + imgInfo[0]);
                }
                    break;
                case 2:
                {
                    imgDict[targetImg].imgName = imgInfo[0];
                    imgDict[targetImg].fadeAction = FadeActionSelector(imgInfo[1]);
                    //Debug.Log("SetImg:" + targetImg + " " + imgInfo[0]);
                }
                    break;
                default:
                    Debug.LogWarning("图片格式错误，图片信息：" + text + " 错误文本:" + dialogText);
                    break;
            }
        }

        private FadeActionEnum FadeActionSelector(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "fadein":
                    return FadeActionEnum.FadeIn;
                case "fadeout":
                    return FadeActionEnum.FadeOut;
                case "normalin":
                    return FadeActionEnum.NormalIn;
                case "normalout":
                    return FadeActionEnum.NormalOut;
                case "coverin":
                    return FadeActionEnum.CoverIn;
                default:
                {
                    Debug.LogWarning("图片行为格式错误，图片行为：" + v + " 错误文本:" + dialogText);
                    return FadeActionEnum.None;
                }
            }
        }

        #endregion

        #region 获取数据

        public Stack<TextLineWord> GetWords()
        {
            return words;
        }

        public Dictionary<string, ImgSetter> GetImgDict()
        {
            return imgDict;
        }

        public void UseSpecialFunc()
        {
            if (specialFunc != null)
            {
                specialFunc.Invoke();
                specialFunc = null;
            }
        }

        public string GetId()
        {
            return id;
        }

        public string GetNextId()
        {
            return nextId;
        }

        #endregion
    }

    public class TextLineWord
    {
        private string word;
        private Action<TextMeshProUGUI> wordHander;

        private Action<TextMeshProUGUI> defaultWordHander = (t) =>
        {
            t.color = Color.white;
            t.fontSize = 36;
            t.fontStyle = FontStyles.Normal;
        };

        public TextLineWord(string word, Action<TextMeshProUGUI> wordHander = null)
        {
            this.word = word;
            this.wordHander = wordHander == null ? defaultWordHander : wordHander;
        }

        public void ShowWord(TextMeshProUGUI text)
        {
            wordHander(text);
        }

        public string GetWords()
        {
            return word;
        }
    }

    public class ImgSetter
    {
        public string imgName;

        public FadeActionEnum fadeAction;

        public ImgSetter(FadeActionEnum fadeAction = FadeActionEnum.None)
        {
            imgName = "";
            this.fadeAction = fadeAction;
        }
    }
}