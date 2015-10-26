using UnityEngine;
using System.Collections;

public class CharacterPowerUpButton2 : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int temp;
	
	public void BackToCardPowerUpScene(){

		int destroyCard;
		destroyCard = gameObject.transform.parent.GetComponent<CharacterMatome> ().number;

		//合成素材デストロイ
		if (destroyCard < PlayState.Instance.selectCharaNumber.Length) {
			Debug.Log("aaa");
			//リストからデータ削除
			PlayState.Instance.character.RemoveAt(PlayState.Instance.selectCharaNumber[destroyCard]);
			//リストの添え字をずらす
			for(int i=0;i<PlayState.Instance.selectCharaNumber.Length;i++){
				if(PlayState.Instance.selectCharaNumber[i] > PlayState.Instance.selectCharaNumber[destroyCard]){
					PlayState.Instance.selectCharaNumber[i] --;
				}	
			}
			for(int i=0;i<PlayState.Instance.backCharaNumber.Count;i++){
				if(PlayState.Instance.backCharaNumber[i] > PlayState.Instance.selectCharaNumber[destroyCard]){
			    	PlayState.Instance.backCharaNumber[i] --;
				}
			}

			PlayState.Instance.selectCharaNumber [destroyCard] = -1;

		} else {
			Debug.Log("bbb");
			Debug.Log("キャラデータ数　"+PlayState.Instance.character.Count);
			Debug.Log("セレクトキャラ数"+PlayState.Instance.selectCharaNumber.Length);
			Debug.Log("バックメンバー数"+PlayState.Instance.backCharaNumber.Count);
			PlayState.Instance.character.RemoveAt(
				PlayState.Instance.backCharaNumber [destroyCard - PlayState.Instance.selectCharaNumber.Length]);

			for(int i=0;i<PlayState.Instance.selectCharaNumber.Length;i++){
				if(PlayState.Instance.selectCharaNumber[i] > PlayState.Instance.backCharaNumber[destroyCard - PlayState.Instance.selectCharaNumber.Length])
					PlayState.Instance.selectCharaNumber[i]--;
			}
			for(int i=0;i<PlayState.Instance.backCharaNumber.Count;i++){
				if(PlayState.Instance.backCharaNumber[i] > PlayState.Instance.backCharaNumber[destroyCard - PlayState.Instance.selectCharaNumber.Length])
					PlayState.Instance.backCharaNumber[i]--;
			}
			PlayState.Instance.backCharaNumber.RemoveAt(destroyCard - PlayState.Instance.selectCharaNumber.Length);

			Debug.Log("キャラデータ数　"+PlayState.Instance.character.Count);
			Debug.Log("セレクトキャラ数"+PlayState.Instance.selectCharaNumber.Length);
			Debug.Log("バックメンバー数"+PlayState.Instance.backCharaNumber.Count);

		}

		//ベース強化処理
		if (PlayState.Instance.powerUpBase < PlayState.Instance.selectCharaNumber.Length) {
			//デッキメンバーに対してのカード強化処理
			//powerUpBaseは上から何番目につくられたキャラクターまとめかを示す
			//これがselectCharaNumberの長さを超える→backCharaNumberということ.なんでこんな面倒にしたのか昔の自分に言いたいいいいいいいいい
			int index = PlayState.Instance.selectCharaNumber[PlayState.Instance.powerUpBase];
			PlayState.Instance.character[index].level ++;
			PlayState.Instance.character[index].atk += 10 ;
			PlayState.Instance.character[index].def += 10;

		} else {
			//バックメンバーに対してのカード強化処理
			//powerUpBaseに入っているのはbackCharaNumberのはず
			int index = PlayState.Instance.backCharaNumber[PlayState.Instance.powerUpBase - PlayState.Instance.selectCharaNumber.Length];
			PlayState.Instance.character[index].level ++;

		}

//		temp = PlayState.Instance.selectCharaNumber [PlayState.Instance.character_change_from];
//		PlayState.Instance.selectCharaNumber [PlayState.Instance.character_change_from] = PlayState.Instance.backCharaNumber[gameObject.transform.parent.GetComponent<CharacterMatome>().number];
//		PlayState.Instance.backCharaNumber [gameObject.transform.parent.GetComponent<CharacterMatome> ().number] = temp;

		Application.LoadLevel (Application.loadedLevel);
	}

}
