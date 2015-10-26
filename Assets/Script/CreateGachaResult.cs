using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class CreateGachaResult : MonoBehaviour {

	//UI子要素格納用
	[SerializeField]
	RectTransform Card = null;
	[SerializeField]
	RectTransform NextButton = null;
	[SerializeField]
	RectTransform NextButton2 = null;
	[SerializeField]
	RectTransform PrefabsForShowAllCard = null;
	[SerializeField]
	RectTransform Vertical = null;

	//ガチャシーンで使用

	int result;
	int func_state;
	int[] table = new int[]
	{0, 1, 2, 3, 4, 5};

	float waitTimer;
	
	public List<int> gachaResultCharaNumber = new List<int>();
	// Use this for initialization
	void Start () {
		func_state = 0;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (func_state);
		switch (func_state) {
		case 0://ガチャ結果代入
			result = table[UnityEngine.Random.Range (0, table.Length)];
			gachaResultCharaNumber.Add (PlayState.Instance.character.Count);
			PlayState.Instance.gacha_left_count --;

			//PlayStateに結果代入(バックメンバーに追加)
			PlayState.Instance.backCharaNumber.Add(PlayState.Instance.character.Count);

			PlayState.Instance.temp = PlayState.Instance.basecharacter[result];
			PlayState.Instance.character.Add(PlayState.Instance.temp);

			//画像表示用のカード作成
			var item = GameObject.Instantiate (Card) as RectTransform;
			item.SetParent (transform, false);
			item.GetComponent<Image> ().sprite = PlayState.Instance.characterimg[result];

			func_state = 10;
			break;
		case 10://ガチャ結果表示１　クリックされるまで待機
			//ButtonをOnClickでcase20
			break;
		case 20:
			//OnClickをONにしAnimationのstateを進める　//animationは自動でdestoryされる設定
			GetComponentInChildren<Animator>().SetBool("OnClicked",true);
			//Timerを使いたいので初期化
			waitTimer = 0.0f;
			func_state = 25;
			break;
		case 25:
			//一定時間待ったら次の動作
			waitTimer += Time.deltaTime;

			if(waitTimer >= 1.0f){
				if (PlayState.Instance.gacha_left_count >= 1)
					func_state = 0;
				else
					func_state = 30;
			}
			break;
		case 30:
			//全てのカードの表示
			Debug.Log("Result");
			for (int i=0; i<gachaResultCharaNumber.Count; i++) {

				//ScrollViewの中身をInstanciate
				var item2 = GameObject.Instantiate (PrefabsForShowAllCard) as RectTransform;
				item2.SetParent (Vertical, false);


				//要素代入
				RectTransform image = item2.FindChild("Image") as RectTransform;
				image.GetComponentInChildren<Image>().sprite = PlayState.Instance.charImg[PlayState.Instance.character[gachaResultCharaNumber[i]].number];

				//名前
				RectTransform charaName = item2.FindChild("CharacterName") as RectTransform;
				charaName.GetComponentInChildren<Text>().text = PlayState.Instance.character[gachaResultCharaNumber[i]].charaName;
				
				//攻撃力
				RectTransform charaAtk = item2.FindChild("CharacterAtk") as RectTransform;
				charaAtk.GetComponentInChildren<Text>().text = "攻　" + PlayState.Instance.character[gachaResultCharaNumber[i]].atk.ToString();
				
				//守備力
				RectTransform charaDef = item2.FindChild("CharacterDef") as RectTransform;
				charaDef.GetComponentInChildren<Text>().text = "防　" + PlayState.Instance.character[gachaResultCharaNumber[i]].def.ToString();
				
				//レベル
				RectTransform charaLv = item2.FindChild("CharacterLv") as RectTransform;
				charaLv.GetComponentInChildren<Text>().text = "Lv　" + PlayState.Instance.character[gachaResultCharaNumber[i]].level.ToString();
				
				//cost
				RectTransform charaCost = item2.FindChild("CharacterCost") as RectTransform;
				charaCost.GetComponentInChildren<Text>().text = "コスト　" + PlayState.Instance.character[gachaResultCharaNumber[i]].cost.ToString();

			}

			//次でもtimerを使いたい
			waitTimer=0.0f;
			func_state = 35;
			break;
		case 35:
			//一定時間待って次の動作
			waitTimer += Time.deltaTime;
			if(waitTimer >= 0.2f){
				func_state = 40;

				//OverRayButtonがマジで邪魔になるのでsetactive=false
				//下に小さなOKButtonをactivate

				NextButton2.gameObject.SetActive(true);
				NextButton.gameObject.SetActive(false);

				//NextButton.GetComponent<Button>().interactable = true;
			}
			break;
		case 40:
			//ButtonをOnClickでcase50
			break;
		case 50:
			waitTimer=0.0f;
			func_state = 55;
			break;
		case 55:
			//クリックされたら一定wait後ガチャシーンへ戻る
			waitTimer += Time.deltaTime;
			if(waitTimer >= 0.2f)
				Application.LoadLevel ("GachaScene");
			break;
		
		default:
			break;
		}
	}
	//他から呼ぶ
	public void GoNextStep(){
		func_state += 10;
	}
}