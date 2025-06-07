using System;
using System.Collections.Generic;
using Game.Img;
using Game.Recycle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class TextShowController : MonoBehaviour
    {
        public RectTransform Panel;

        //图片相关的UI，如果用不上可以不导入TextShowUIEffect
        public Image LeftImg;
        public Image RightImg;
        public Image CenterImg;
        public Image Background;
        public TextShowUIEffect SelfTextShowUIEffect;
        private static float originalShowInterval = 0.05f;
        private static float correctedShowInterval = 0f;
        private static float showInterval = originalShowInterval;
        private float showTick = 0f;
        private Stack<TextLineReader> lineStack = new Stack<TextLineReader>();
        private Dictionary<string, TextLineReader> lineDict = new Dictionary<string, TextLineReader>();
        private Stack<TextLineWord> wordStack = new Stack<TextLineWord>();
        private string nextId;
        private bool isShowing = true;

        ///是否正在展示文本
        private Action onTextOver;

        ///文本清空时的回调函数
        private Action onPanelCleared;

        ///文本输出一个字符后的回调函数
        private Action onOneWordShown;

        void FixedUpdate()
        {
            if (showTick > 0)
            {
                showTick -= Time.fixedDeltaTime;
            }
            else
            {
                showTick = showInterval;
                ShowOneWord();
            }
        }


        private void ShowOneWord()
        {
            if (wordStack.Count > 0)
            {
                TextLineWord word = wordStack.Pop();
                Recycle.RecyclePool.Request(RecycleItemEnum.TextItem, r =>
                {
                    r.GetMainComponent<TextMeshProUGUI>().text = word.GetWords();
                    word.ShowWord(r.GetMainComponent<TextMeshProUGUI>());
                }, Panel);
                onOneWordShown?.Invoke();
            }
            else
            {
                isShowing = false;
            }
        }

        public void GetTextAsset(TextAsset textAsset)
        {
            string[] textLines = TextLineDefine(textAsset.text.Replace("\n", "").Replace("\t", ""));
            for (int i = textLines.Length - 1; i >= 0; i--)
            {
                SetTextLine(textLines[i]);
            }

            ShowOneLine();
        }

        public void GetText(string text)
        {
            string[] textLines = TextLineDefine(text);
            for (int i = textLines.Length - 1; i >= 0; i--)
            {
                SetTextLine(textLines[i]);
            }

            ShowOneLine();
        }

        public string[] TextLineDefine(string text)
        {
            //;(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)(?=(?:[^<>]*<[^<>]*>)*[^<>]*$)
            //匹配不包含在<>中的;符号进行分割
            string[] lines = System.Text.RegularExpressions.Regex.Split(text,
                ";(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)(?=(?:[^<>]*<[^<>]*>)*[^<>]*$)");
            /*foreach (var item in lines)
            {
                Debug.Log(item);
            }*/
            return lines;
        }

        private void SetTextLine(string text)
        {
            TextLineReader lineReader = new TextLineReader(text);

            if (lineReader.GetId() != null)
            {
                string id = lineReader.GetId();
                if (lineDict.ContainsKey(id))
                {
                    Debug.LogError("该ID已经存在，ID为：" + id);
                }
                else
                {
                    Debug.Log("添加ID为：" + id + "的文本行");
                    lineDict.Add(id, lineReader);
                }
            }
            else
            {
                lineStack.Push(lineReader);
            }
        }

        #region 单行处理

        //只展示文本中的一行
        private bool ShowOneLine()
        {
            if (nextId != null)
            {
                if (!lineDict.ContainsKey(nextId))
                {
                    Debug.LogError("没有找到该行文本，搜索ID为：" + nextId);
                }

                ClearPanel();
                TextLineReader line = lineDict[nextId];
                nextId = null;
                return OneLineHander(line);
            }

            if (lineStack.Count > 0)
            {
                ClearPanel();
                TextLineReader line = lineStack.Pop();
                return OneLineHander(line);
            }

            return false;
        }

        private bool OneLineHander(TextLineReader line)
        {
            line.UseSpecialFunc();
            //如该行"不可读"，则跳过该行，并且读取下一行
            while (!line.canRead)
            {
                if (lineStack.Count > 0)
                {
                    line = lineStack.Pop();
                }
                else
                {
                    return false;
                }
            }

            nextId = line.GetNextId();
            //从TextLineReader获取处理后的一行文本  
            Stack<TextLineWord> words = line.GetWords();
            //Debug.Log("当前行文本：" + line.dialogText);
            Dictionary<string, ImgSetter> imgDict = line.GetImgDict();
            SetImgDict(imgDict);
            //将处理后的文本压入WordStack
            while (words.Count > 0)
            {
                wordStack.Push(words.Pop());
            }

            //检测该行是否能够展示
            if (CheckDialogText(line.dialogText))
            {
                ShowNextLine();
                return true;
            }

            return true;
        }

        //显示下一行
        public void ShowNextLine()
        {
            if (isShowing)
            {
                showInterval = correctedShowInterval;
                return;
            }

            showInterval = originalShowInterval;
            isShowing = true;
            //在此处添加对话框的显示效果
            if (!ShowOneLine())
            {
                if (onTextOver != null)
                {
                    //Debug.Log("该文本已经读完，执行后续操作");
                    onTextOver.Invoke();
                }
                else
                {
                    Debug.Log("该文本已经读完，但你没有设置任何后续操作");
                }
            }
        }

        #endregion

        #region 图片处理

        private void SetImgDict(Dictionary<string, ImgSetter> imgDict)
        {
            SetImg(LeftImg, imgDict["leftimg"]);
            SetImg(RightImg, imgDict["rightimg"]);
            SetImg(CenterImg, imgDict["centerimg"]);
            SetImg(Background, imgDict["background"]);
        }

        private void SetImg(Image image, ImgSetter imgSetter)
        {
            //如果没有图片，则不进行处理
            if (image == null)
            {
                return;
            }

            //Debug.Log(image.name + ":图片名称：" + imgSetter.imgName + " 图片行为：" + imgSetter.fadeAction.ToString());
            switch (imgSetter.fadeAction)
            {
                case FadeActionEnum.FadeIn:
                {
                    image.sprite = GetImg(imgSetter.imgName);
                    SelfTextShowUIEffect.ShowImg(image);
                }
                    break;
                case FadeActionEnum.FadeOut:
                {
                    SelfTextShowUIEffect.HideImg(image);
                }
                    break;
                case FadeActionEnum.NormalIn:
                {
                    image.gameObject.SetActive(true);
                    //Debug.Log(imgSetter.imgName);
                    image.sprite = GetImg(imgSetter.imgName);
                }
                    break;
                case FadeActionEnum.NormalOut:
                {
                    image.gameObject.SetActive(false);
                    break;
                }
                case FadeActionEnum.CoverIn:
                {
                    //获取到当前图片的父物体的第一个子物体，作为备份图片
                    Image backup = image.transform.parent.GetChild(0).GetComponent<Image>();
                    backup.sprite = image.sprite;
                    backup.gameObject.SetActive(true);
                    //Debug.Log(backup.transform.name);
                    image.sprite = GetImg(imgSetter.imgName);
                    SelfTextShowUIEffect.ShowImg(image, (hander) => { backup.gameObject.SetActive(false); });
                }
                    break;
                case FadeActionEnum.None:
                    break;
            }
        }

        private Sprite GetImg(string imgName)
        {
            return ImgManager.Instance.GetImg(imgName);
        }

        #endregion

        #region 其他

        private void ClearPanel()
        {
            for (int i = Panel.childCount - 1; i >= 0; i--)
            {
                Recycle.RecyclePool.ReturnToPool(Panel.GetChild(i).gameObject);
            }

            onPanelCleared?.Invoke();
        }

        public void SetEndHander(Action endHander)
        {
            onTextOver = endHander;
        }

        //检测文本是否满足显示条件
        private bool CheckDialogText(string text)
        {
            if (text.Length <= 2)
            {
                Panel.gameObject.SetActive(false);
            }
            else
            {
                Panel.gameObject.SetActive(true);
            }

            return false;
        }

        public void Init()
        {
            //初始化文本展示控制器
            showInterval = originalShowInterval;
            isShowing = true;
            onTextOver = null;
            onPanelCleared = null;
            onOneWordShown = null;
            lineStack.Clear();
            wordStack.Clear();
            LeftImg.gameObject.SetActive(false);
            RightImg.gameObject.SetActive(false);
            CenterImg.gameObject.SetActive(false);
            Background.gameObject.SetActive(false);
            ClearPanel();
        }

        #endregion
    }
}