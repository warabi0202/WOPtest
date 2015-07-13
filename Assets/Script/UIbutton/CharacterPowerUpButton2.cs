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



		if (PlayState.Instance.powerUpBase < PlayState.Instance.selectCharaNumber.Length) {

		//デッキメンバーに対してのカード強化処理

		} else {

		//バックメンバーに対してのカード強化処理

		}

//		temp = PlayState.Instance.selectCharaNumber [PlayState.Instance.character_change_from];
//		PlayState.Instance.selectCharaNumber [PlayState.Instance.character_change_from] = PlayState.Instance.backCharaNumber[gameObject.transform.parent.GetComponent<CharacterMatome>().number];
//		PlayState.Instance.backCharaNumber [gameObject.transform.parent.GetComponent<CharacterMatome> ().number] = temp;

		Application.LoadLevel (Application.loadedLevel);
	}

}
