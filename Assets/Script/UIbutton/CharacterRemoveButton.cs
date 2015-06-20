using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterRemoveButton : MonoBehaviour {

	[SerializeField]
	RectTransform characterEnter = null;
	//[SerializeField]
	//RectTransform parent = null;
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
//		RectTransform charaEnter = Instantiate (characterEnter) as RectTransform;
//		charaEnter.SetParent (transform.parent.parent);
//		Destroy (gameObject.transform.parent.gameObject);
		Application.LoadLevel (Application.loadedLevel);
	}
}
