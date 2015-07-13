﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateCharacterMatomeForPowerUpCardSerect2 : MonoBehaviour {

	
	//UI子要素格納用
	[SerializeField]
	RectTransform Contentprefab = null;
	
	int selectCharaCount;
	public bool CharacterListMakeFlag;

	// Use this for initialization
	void Start () {
		


		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (CharacterListMakeFlag == true) {

			for (int i=0; i<PlayState.Instance.selectCharaNumber.Length; i++) {	
			
				if (i == 0)
					selectCharaCount = 0;
			
				if (PlayState.Instance.selectCharaNumber [i] != -1
				    	&& selectCharaCount != PlayState.Instance.powerUpBase) {
				
					selectCharaCount++;
				
					if (selectCharaCount != PlayState.Instance.powerUpBase) {
					
						var item = GameObject.Instantiate (Contentprefab) as RectTransform;
						item.SetParent (transform, false);
						item.GetComponent<CharacterMatome> ().number = selectCharaCount;
					
					
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
			}
			for (int i=0; i<PlayState.Instance.backCharaNumber.Count; i++) {
			
				if (PlayState.Instance.backCharaNumber [i] != -1) {
				
					selectCharaCount++;
				
					if (PlayState.Instance.selectCharaNumber [i] != -1 
					    && selectCharaCount != PlayState.Instance.powerUpBase) {
						var item = GameObject.Instantiate (Contentprefab) as RectTransform;
						item.SetParent (transform, false);
						item.GetComponent<CharacterMatome> ().number = selectCharaCount;
					
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
			CharacterListMakeFlag = false;
		}
	}
}