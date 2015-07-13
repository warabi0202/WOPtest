using UnityEngine;
using System.Collections;

public class AnimationDestroyer : MonoBehaviour {
	
	public Animator animator;
	public int animationNumber;
	
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate(){
		//animator.SetInteger ("animationNumber",animationNumber);
	}
	
	void OnAnimationFinish(){
		Destroy (gameObject);
	}
}
