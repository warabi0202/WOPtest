using UnityEngine;
using System.Collections;

public class MenuCharChange : MonoBehaviour {

	private bool IniFlag=false;
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		if (IniFlag == false) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = PlayState.Instance.characterimg [PlayState.Instance.character [PlayState.Instance.selectCharaNumber [0]].number];

			switch(PlayState.Instance.character [PlayState.Instance.selectCharaNumber [0]].number){
			case 0://ran
				transform.position = new Vector3(-1.0f,-1.0f,0.0f);
				transform.localScale = new Vector3(1.0f,1.0f,1.0f);
				break;

			case 1://mikage
				transform.position = new Vector3(0.5f,0.0f,0.0f);
				transform.localScale = new Vector3(0.7f,0.7f,1.0f);
				break;
			case 2://amalia
				transform.position = new Vector3(-1.0f,-0.1f,0.0f);
				transform.localScale = new Vector3(1.0f,1.0f,1.0f);
				break;
			case 3://elenoa
				transform.position = new Vector3(-1.0f,-0.1f,0.0f);
				transform.localScale = new Vector3(1.0f,1.0f,1.0f);
				break;
			case 4://magi
				transform.position = new Vector3(-1.4f,0.0f,0.0f);
				transform.localScale = new Vector3(1.2f,1.2f,1.0f);
				break;
			case 5://kar
				transform.position = new Vector3(-1.7f,-0.4f,0f);
				transform.localScale = new Vector3(0.5f,0.5f,1f);
				break;
			}
			IniFlag = true;
		}
	}
}
