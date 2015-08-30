using UnityEngine;
using System.Collections;

public class AnimationTestor : MonoBehaviour {

	public GameObject attackAnimationPrefab;
	public int animationNumber;

	float timer;
	// Use this for initialization
	void Start () {
		animationNumber = 1;
		//Create_animation (1, transform);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 3.0f) {
			Create_animation(animationNumber,transform);
			timer = 0.0f;
		}
	
	}

	void Create_animation(int selectnumber,Transform origin){
		//attackDonki.GetComponent<AnimationDestroyer> ().animationNumber = 1;
		GameObject attackDonki_ins = Instantiate( attackAnimationPrefab ,origin.position + (Vector3.down * 0.3f), origin.rotation) as GameObject;
		
		attackDonki_ins.GetComponent<Animator> ().SetInteger ("animationNumber",selectnumber);
		//attackDonki_ins.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

	}
}
