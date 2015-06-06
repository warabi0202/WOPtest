using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateCharacterMatome2 : MonoBehaviour {
	
	//UI子要素格納用
	[SerializeField]
	RectTransform Contentprefab = null;

	
	// Use this for initialization
	void Start () {
		
		for(int i=0;i<PlayState.Instance.backCharaNumber.Count;i++){
			
			/*if(PlayState.Instance.backCharaNumber[i]!= -1){*/
				var item = GameObject.Instantiate(Contentprefab) as RectTransform;
				item.SetParent(transform,false);
				item.GetComponent<CharacterMatome>().number = i;
				Debug.Log(PlayState.Instance.backCharaNumber[i]);
				//名前
				RectTransform charaName = item.FindChild("CharacterName") as RectTransform;
				charaName.GetComponentInChildren<Text>().text = PlayState.Instance.character[PlayState.Instance.backCharaNumber[i]].charaName;
				
				//攻撃力
				RectTransform charaAtk = item.FindChild("CharacterAtk") as RectTransform;
				charaAtk.GetComponentInChildren<Text>().text = "攻　" + PlayState.Instance.character[PlayState.Instance.backCharaNumber[i]].atk.ToString();
				
				//守備力
				RectTransform charaDef = item.FindChild("CharacterDef") as RectTransform;
				charaDef.GetComponentInChildren<Text>().text = "防　" + PlayState.Instance.character[PlayState.Instance.backCharaNumber[i]].def.ToString();
				
				//レベル
				RectTransform charaLv = item.FindChild("CharacterLv") as RectTransform;
				charaLv.GetComponentInChildren<Text>().text = "Lv　" + PlayState.Instance.character[PlayState.Instance.backCharaNumber[i]].level.ToString();
				
				//cost
				RectTransform charaCost = item.FindChild("CharacterCost") as RectTransform;
				charaCost.GetComponentInChildren<Text>().text = "Lv　" + PlayState.Instance.character[PlayState.Instance.backCharaNumber[i]].cost.ToString();
				
				
			//}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}