using UnityEngine;
using System.Collections;

public class DeckSceneAudio :Singleton<DeckSceneAudio>{

	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName != "deckScene" && Application.loadedLevelName != "deckScene2")
			Destroy (gameObject);


//		if (count == 0 && Application.loadedLevelName == "deckScene2")
//			count = 1;
//		if (count == 1 && Application.loadedLevelName == "deckScene")
//			Destroy (gameObject);

	}
}
