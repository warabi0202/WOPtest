using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToGachaScene(){
		Application.LoadLevel ("gachaScene");
	}
	public void ToMenuScene(){
		Application.LoadLevel ("menuScene");
	}
	public void ToStoryScene(){
		Application.LoadLevel ("storyScene");
	}
	public void ToDeckScene(){
		Application.LoadLevel ("deckScene");
	}
	public void ToGachaResultScene_single(){
		PlayState.Instance.gacha_left_count = 1;
		Application.LoadLevel ("gachaResultScene");
	}
	public void ToGachaResultScene_multiple(){
		PlayState.Instance.gacha_left_count = 10;
		Application.LoadLevel ("gachaResultScene");
	}





}
