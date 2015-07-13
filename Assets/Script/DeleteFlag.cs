using UnityEngine;
using System.Collections;

public class DeleteFlag : MonoBehaviour {

	public bool delete_flag=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Change_delete_flag(){
		if (delete_flag)
			delete_flag = false;
		else
			delete_flag = true;
	}
}
