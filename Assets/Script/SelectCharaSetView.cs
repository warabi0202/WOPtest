//using System.Collections;
//using UnityEngine;
//using System.Linq;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using System;
//
//public class SelectCharaSetView : MonoBehaviour
//{
//    public CharaPanel charaPanelPrefab;
//
//    List<CharaPanel> charaPanelList = new List<CharaPanel>();
//    // Use this for initialization
//    void Start()
//    {
//        foreach (var cName in PlayState.Instance.charaName)
//        {
//            //panel作成
//            var panel = Instantiate(charaPanelPrefab) as CharaPanel;
//            //panel内の名前変更
//            panel.transform.FindChild("Name").GetComponent<Text>().text = cName;
//            //親に指定
//            panel.transform.SetParent(this.transform, false);
//
//            //リストに入れる
//            charaPanelList.Add(panel);
//        }
//        foreach (var i in Enumerable.Range(0, 2))
//        {
//            charaPanelList[0].ActivateMark(i);
//        }
//
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        ChangeSelectChara();
//
//    }
//
//    public class SelectCursor
//    {
//        public int selectCount = 0;
//        public bool decideFlag = false;
//    }
//    SelectCursor[] selectCursor = new SelectCursor[2] { new SelectCursor(), new SelectCursor() };
//
//    void ChangeSelectChara()
//    {
//        foreach (var i in Enumerable.Range(0, Enum.GetNames(typeof(PlayerName)).Length))
//        {
//            if (selectCursor[i].decideFlag == false)
//                //{
//                //選択肢の移動
//
//                if (Input.GetButtonDown(((PlayerName)i).ToString() + " " + "Vertical"))
//                {
//                    //上
//                    if (Input.GetAxisRaw(((PlayerName)i).ToString() + " " + "Vertical") > 0 && selectCursor[i].selectCount > 0)
//                    {
//                        charaPanelList[selectCursor[i].selectCount].InactivateMark(i);
//                        selectCursor[i].selectCount--;
//                        charaPanelList[selectCursor[i].selectCount].ActivateMark(i);
//
//                    }
//                    //下
//                    else if (Input.GetAxisRaw(((PlayerName)i).ToString() + " "+ "Vertical") < 0 && selectCursor[i].selectCount < charaPanelList.Count - 1)
//                    {
//                        charaPanelList[selectCursor[i].selectCount].InactivateMark(i);
//                        selectCursor[i].selectCount++;
//                        charaPanelList[selectCursor[i].selectCount].ActivateMark(i);
//
//                    }
//                }
//                //キャラの決定
//                else if (Input.GetButtonDown(((PlayerName)i).ToString() + " " + "OK"))
//                {
//                    selectCursor[i].decideFlag = true;
//                    charaPanelList[selectCursor[i].selectCount].DecideMark(i);
//                    //決定音
//                    SoundManager.Instance.PlaySoundFromName("kettei", SoundManager.AudioKind.SE);
//                    //1P,2Pが両方決定
//                    if (selectCursor.Any(s => s.decideFlag == false) == false)
//                    {
//                        //PlayStateに名前更新
//                        PlayState.Instance.playerCharaName = selectCursor.Select(x => PlayState.Instance.charaName[x.selectCount]).ToArray();
//
//                        SelectScene.Instance.SetNextScene();
//
//                    }
//
//                }
//
//        }
//    }
//
//}

