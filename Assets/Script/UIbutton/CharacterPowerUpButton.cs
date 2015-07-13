using UnityEngine;
using System.Collections;

public class CharacterPowerUpButton : MonoBehaviour {

	public Canvas afterCanvas;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		afterCanvas = GameObject.Find ("AfterCanvas").GetComponent<Canvas>();
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToCardpowerUpScene2AndBaseDecide(){
		PlayState.Instance.powerUpBase = gameObject.transform.parent.GetComponent<CharacterMatome> ().number;
//		Application.LoadLevel ("CardPowerUpScene2");
		afterCanvas.enabled = true;
		canvas.enabled = false;
		afterCanvas.GetComponentInChildren<CreateCharacterMatomeForPowerUpCardSerect2> ().CharacterListMakeFlag = true;
	}
}
