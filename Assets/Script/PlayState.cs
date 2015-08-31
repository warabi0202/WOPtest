using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;6
using System;


//コピーバージョン　WoP

//ゲームシーンで破棄されない
//シングルトン設計
public class PlayState : Singleton<PlayState> {
	
	public class PlayerStatus{
		public int lv;
		public int stp;
		public int stp_max;
		public DateTime oldDateTime;
	}
	
	public PlayerStatus playerStatus;
	private string serializeDataPath;


	
	//定数
	public string[] charaName = new string[] { "Betelgeuse" };

	//キャラのclass
	public class Character{

		public int atk;
		public int def;
		public int level;
		public int skilllevel;


		public string charaName;
		public Sprite img;
		public string skillName;
		public int number;
		public int rarerity;
		public int cost;

	}
	//シーン更新の際引き継ぐデータ
	[System.NonSerialized]
	public string[] playerCharaName = new string[2];

	//キャラクターデータ
	public Character[] character = new Character[9]{
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character()
	};

	//デッキに選択されているキャラ
	public int[] selectCharaNumber = new int[5];
	//選択されていないキャラ
	public List<int> backCharaNumber = new List<int> ();
	//public int[] backCharaNumber = new int[4];
	//キャラ変更時格納用
	public int character_change_from;
	public int character_change_to;
	public int for_temp;
	public int powerUpBase;

	//ガチャシーン→ガチャリザルトシーンで使用
	public int gacha_left_count;

	//プロパティ
	public override void onAwake()
	{
		base.onAwake();
		//Init ();

	}

	void Start()
	{
		serializeDataPath = Application.dataPath + "/PlayerData.xml";

//		playerStatus = new PlayerStatus ();
//		playerStatus.lv = 1;
//		playerStatus.stp = 30;
//		playerStatus.stp_max = 35;
//		XMLUtility.Seialize<PlayerStatus> (serializeDataPath, playerStatus);
		playerStatus = XMLUtility.Deserialize<PlayerStatus>(serializeDataPath);
		Debug.Log (playerStatus.lv);

		Debug.Log("init");
		//	とりあえず初期化
		for (int i=0; i<selectCharaNumber.Length; i++) {
			selectCharaNumber [i] = i;
		}
		selectCharaNumber [4] = -1;
		backCharaNumber.Add (5);
		backCharaNumber.Add (6);
		backCharaNumber.Add (7);
		backCharaNumber.Add (8);

		
		/*backCharaNumber [0] = 5;
		backCharaNumber [1] = 6;
		backCharaNumber [2] = 7;
		backCharaNumber [3] = 8;
*/

		for (int i=0; i<character.Length; i++) {
			//カグヤデータ

//			atk;
//			 int def;
//			public int level;
//			public int skilllevel;



			
//			public string charaName;
//			public Sprite img;
//			public string skillName;
//			public int number;
//			public int rarerity;
//			public int cost;
	
			character [i].number = i;
			character [i].charaName = "かぐや" + i.ToString();
			character [i].atk = 100 * i;
			character [i].def = 50 * i;
			character [i].level = 5 * i;
			character [i].rarerity = i;
			character [i].cost = i;
			character [i].skillName = "ポイズン";
			character [i].skilllevel = 1;
		}
	}
	void Update()
	{
		CheckEnd();
	}
	
	void CheckEnd()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void OnApplicationQuit() {
		XMLUtility.Seialize<PlayerStatus>(serializeDataPath,playerStatus);
	}




}
