using UnityEngine;
using System.Collections;

public class AnimationNumberChange : MonoBehaviour {

	public GameObject animationMaker;

	public void AddAnimationNumber(){
		animationMaker.GetComponent<AnimationTestor> ().animationNumber =
			(animationMaker.GetComponent<AnimationTestor> ().animationNumber+1)%7;
	}
}
