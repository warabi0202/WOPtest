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





}
