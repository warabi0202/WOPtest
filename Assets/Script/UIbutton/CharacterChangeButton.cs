using UnityEngine;
using System.Collections;

public class CharacterChangeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToDeckScene2AndCharacterChange(){
		PlayState.Instance.character_change_from = gameObject.transform.parent.GetComponent<CharacterMatome> ().number;
		Application.LoadLevel ("deckScene2");
	}
}
