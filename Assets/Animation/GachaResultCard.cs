using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaResultCard : MonoBehaviour {

	[SerializeField]
	RectTransform NextButton = null;

	// Use this for initialization
	void Start () {
		Debug.Log ("reached");
		NextButton = GameObject.Find ("PreCanvas/AllWindowOverrayButton").transform as RectTransform;
		Debug.Log (NextButton);
	}
	
	// Update is called once per frame
	void Update () {


	
	}


	public void OnAnimationFinish(){
		Debug.Log ("Reached");
		Destroy (gameObject);
	}

	public void OverRayButtonEnabled(){
		NextButton.GetComponent<Button>().interactable = true;
	}

}
