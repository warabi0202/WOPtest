using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateCharacterMatomeForPowerUpCardSerect : MonoBehaviour {
	
	//UI子要素格納用
	[SerializeField]
	RectTransform Contentprefab = null;

	//カウント用
	int selectCharaCount;


	/*	Instanciateする内容にCharacterMatome/CharacterPowerUpButtonが存在
		<CharacterPowerUpButton>内部でシーン遷移*/

	// Use this for initialization
	void Start () {
		//フロントキャラ表示
		for (int i=0; i<PlayState.Instance.selectCharaNumber.Length; i++) {	
			if(i==0) selectCharaCount = -1;
			selectCharaCount++;

			if (PlayState.Instance.selectCharaNumber [i] != -1) {

				var item = GameObject.Instantiate (Contentprefab) as RectTransform;
				item.SetParent (transform, false);
				item.GetComponent<CharacterMatome> ().number = selectCharaCount;
				item.FindChild("Image").GetComponent<Image>().sprite = PlayState.Instance.charImg[PlayState.Instance.character[PlayState.Instance.selectCharaNumber [i]].number];

				
				//名前
				RectTransform charaName = item.FindChild ("CharacterName") as RectTransform;
				charaName.GetComponentInChildren<Text> ().text = PlayState.Instance.character [PlayState.Instance.selectCharaNumber [i]].charaName;
				
				//攻撃力
				RectTransform charaAtk = item.FindChild ("CharacterAtk") as RectTransform;
				charaAtk.GetComponentInChildren<Text> ().text = "攻　" + PlayState.Instance.character [PlayState.Instance.selectCharaNumber [i]].atk.ToString ();
				
				//守備力
				RectTransform charaDef = item.FindChild ("CharacterDef") as RectTransform;
				charaDef.GetComponentInChildren<Text> ().text = "防　" + PlayState.Instance.character [PlayState.Instance.selectCharaNumber [i]].def.ToString ();
				
				//レベル
				RectTransform charaLv = item.FindChild ("CharacterLv") as RectTransform;
				charaLv.GetComponentInChildren<Text> ().text = "Lv　" + PlayState.Instance.character [PlayState.Instance.selectCharaNumber [i]].level.ToString ();
			
				//cost
				RectTransform charaCost = item.FindChild ("CharacterCost") as RectTransform;
				charaCost.GetComponentInChildren<Text> ().text = "Lv　" + PlayState.Instance.character [PlayState.Instance.selectCharaNumber [i]].cost.ToString ();
			}
		}
		//バックキャラ表示
		for (int i=0; i<PlayState.Instance.backCharaNumber.Count; i++) {

			selectCharaCount++;
			if (PlayState.Instance.backCharaNumber [i] != -1) {

				var item = GameObject.Instantiate (Contentprefab) as RectTransform;
				item.SetParent (transform, false);
				item.GetComponent<CharacterMatome> ().number = selectCharaCount;

				Debug.Log("バックキャラ番号"+PlayState.Instance.backCharaNumber [i]);
				Debug.Log("キャラナンバー"+PlayState.Instance.character[PlayState.Instance.backCharaNumber [i]].number);
				item.FindChild("Image").GetComponent<Image>().sprite = PlayState.Instance.charImg[PlayState.Instance.character[PlayState.Instance.backCharaNumber [i]].number];
				
				//名前
				RectTransform charaName = item.FindChild ("CharacterName") as RectTransform;
				charaName.GetComponentInChildren<Text> ().text = PlayState.Instance.character [PlayState.Instance.backCharaNumber [i]].charaName;
				
				//攻撃力
				RectTransform charaAtk = item.FindChild ("CharacterAtk") as RectTransform;
				charaAtk.GetComponentInChildren<Text> ().text = "攻　" + PlayState.Instance.character [PlayState.Instance.backCharaNumber [i]].atk.ToString ();
				
				//守備力
				RectTransform charaDef = item.FindChild ("CharacterDef") as RectTransform;
				charaDef.GetComponentInChildren<Text> ().text = "防　" + PlayState.Instance.character [PlayState.Instance.backCharaNumber [i]].def.ToString ();
				
				//レベル
				RectTransform charaLv = item.FindChild ("CharacterLv") as RectTransform;
				charaLv.GetComponentInChildren<Text> ().text = "Lv　" + PlayState.Instance.character [PlayState.Instance.backCharaNumber [i]].level.ToString ();
				
				//cost
				RectTransform charaCost = item.FindChild ("CharacterCost") as RectTransform;
				charaCost.GetComponentInChildren<Text> ().text = "Cost　" + PlayState.Instance.character [PlayState.Instance.backCharaNumber [i]].cost.ToString ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
