using UnityEngine;
using System.Collections;

public class AddMember : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToDeckScene2AndCharacterEnter(){
		for (int i=0; i<PlayState.Instance.selectCharaNumber.Length; i++) {
			if(PlayState.Instance.selectCharaNumber[i] == -1){
				PlayState.Instance.character_change_from = i;
				break;
			}
		}
		Application.LoadLevel ("deckScene2");
	}
}
