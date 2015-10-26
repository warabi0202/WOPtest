using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class XmlPractice : MonoBehaviour {


	public class TestData{
		public int x;
		public int[] array_x;
		public List<int> list_x;
	}

	public TestData testData;

	private string serializeDataPath;
	// Use this for initialization
	void Start () {
		serializeDataPath = Application.dataPath + "/SerializeData.xml";

//		testData = new TestData ();
//		testData.x = 100;
//		testData.array_x = new int[]{1,2,3,4,5};
//		testData.list_x = new List<int>();
//		testData.list_x.Add (1000);
//		testData.list_x.Add (2000);
	}
	
	// Update is called once per frame
	void Update() {
		if ( Input.GetKeyDown(KeyCode.S) ) {
			XMLUtility.Seialize<TestData>(serializeDataPath, testData);
		}
		if ( Input.GetKeyDown(KeyCode.D) ) {
			testData = XMLUtility.Deserialize<TestData>(serializeDataPath);
			for(int i=0;i<testData.array_x.Length;i++){
				Debug.Log(testData.array_x[i]);
			}
		}
	}
}
