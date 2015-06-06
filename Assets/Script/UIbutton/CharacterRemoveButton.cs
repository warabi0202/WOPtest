using UnityEngine;
using System.Collections;

public class CharacterRemoveButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CharacterRemover(){
		PlayState.Instance.selectCharaNumber
			[gameObject.transform.parent.GetComponent<CharacterMatome> ().number]
			= -1;
		Destroy (gameObject.transform.parent.gameObject);
	}
}
