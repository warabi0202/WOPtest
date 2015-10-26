using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateCharacterMatome : MonoBehaviour {

	//UI子要素格納用
	[SerializeField]
	RectTransform Contentprefab = null;
	[SerializeField]
	RectTransform Contentprefab2 = null;

	// Use this for initialization
	void Start () {

		bool IsAbleCharaEnter = false;

		for (int i=0; i<PlayState.Instance.selectCharaNumber.Length; i++) {

			if (PlayState.Instance.selectCharaNumber [i] != -1) {
				var item = GameObject.Instantiate (Contentprefab) as RectTransform;
				item.SetParent (transform, false);
				item.GetComponent<CharacterMatome> ().number = i;
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

		
			} else {
				IsAbleCharaEnter = true;
			}
		}
		if(IsAbleCharaEnter == true){
			var item2 = GameObject.Instantiate(Contentprefab2) as RectTransform;
			item2.SetParent(transform,false);

		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
