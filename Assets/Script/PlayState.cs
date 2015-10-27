using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


//コピーバージョン　WoP

//ゲームシーンで破棄されない
//シングルトン設計
public class PlayState : Singleton<PlayState> {

	//Playerのステータス表示
	public class PlayerStatus{
		public int lv;
		public int stone;
		public int stp;
		public int stp_max;
		public DateTime oldDateTime;
	}
	
	public PlayerStatus playerStatus;
	public string serializeDataPath;

	public Sprite[] characterimg = new Sprite[6];
	//キャラのclass
	public class Character{

		public int atk;
		public int def;
		public int level;
		public int skilllevel;


		public string charaName;
		public string skillName;
		public int number;
		public int rarerity;
		public int cost;

	}

//	public class BaseCharacter
//	{
//		public int atk;
//		public int def;
//		public int level;
//		public int skilllevel;
//		public string charaName;
//		public string skillName;
//		public int number;
//		public int rarerity;
//		public int cost;
//		public Sprite img;
//
//	}

	public Sprite[] charImg = new Sprite[6];

	//シーン更新の際引き継ぐデータ
	[System.NonSerialized]
	public string[] playerCharaName = new string[2];

	//キャラクターデータ
//	public Character[] character = new Character[9]
//	{
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character(),
//		new Character()
//	};

	public Character temp;

	public Character[] basecharacter = new Character[6]
	{
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character(),
		new Character()
	};
	public List<Character> character = new List<Character> ();

	//デッキに選択されているキャラ
	public int[] selectCharaNumber = new int[3];
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
		Debug.Log("init");

		//データパス設定→宣言→データ読み込み→初回起動処理
		//データ書き込みはアプリ終了時のみで十分
		serializeDataPath = Application.dataPath + "/PlayerData.xml";
		playerStatus = XMLUtility.Deserialize<PlayerStatus>(serializeDataPath);
//		playerStatus.lv = 2;
//		playerStatus.stp = 30;
//		playerStatus.stp_max = 35;
		//XMLUtility.Seialize<PlayerStatus> (serializeDataPath, playerStatus);
		//ここまで

		//セレクトキャラデータ
		serializeDataPath = Application.dataPath + "/SelectCharaData.xml";
		selectCharaNumber = XMLUtility.Deserialize<int[]> (serializeDataPath);
		//バックメンバーデータ
		serializeDataPath = Application.dataPath + "/BackMemberData.xml";
		backCharaNumber = XMLUtility.Deserialize<List<int>> (serializeDataPath);

		serializeDataPath = Application.dataPath + "/CharacterData.xml";
		character = XMLUtility.Deserialize<List<Character>> (serializeDataPath);

		serializeDataPath = Application.dataPath + "/BaseCharacterData.xml";
		basecharacter = XMLUtility.Deserialize<Character[]> (serializeDataPath);

		for(int i=0;i<character.Count;i++){
			//Debug.Log(character[i].charaName);
//			character[i].img = Resources.Load<Sprite>(character[i].charaName);
//			switch (character[i].number){
//			case 1:
//				character[i].img = Resources.Load<Sprite>("かぐや蘭子");
//				break;
//			case 2:
//				character[i].img = Resources.Load<Sprite>("御影");
//				break;
//			case 3:
//				character[i].img = Resources.Load<Sprite>("アマリア");
//				break;
//			case 4:
//				character[i].img = Resources.Load<Sprite>("エレノア");
//				break;
//			case 5:
//				character[i].img = Resources.Load<Sprite>("クロマジ");
//				break;
//			case 6:
//				character[i].img = Resources.Load<Sprite>("カーミラ");
//				break;
//			}
		}
		//Sprite sp = Resources.Load<Sprite> ("kaguyaRanko");
		//character [0].img = sp;

		//	とりあえず初期化
//		for (int i=0; i<selectCharaNumber.Length; i++) {
//			selectCharaNumber [i] = i;
//		}
//		selectCharaNumber [4] = -1;
//		backCharaNumber.Add (5);
//		backCharaNumber.Add (6);
//		backCharaNumber.Add (7);
//		backCharaNumber.Add (8);

//		for (int i=0; i<character.Length; i++) {
//			character [i].number = i;
//			character [i].charaName = "かぐや" + i.ToString();
//			character [i].atk = 100 * i;
//			character [i].def = 50 * i;
//			character [i].level = 5 * i;
//			character [i].rarerity = i;
//			character [i].cost = i;
//			character [i].skillName = "ポイズン";
//			character [i].skilllevel = 1;
//		}

//		for (int i=0; i<basecharacter.Length; i++) {
//			basecharacter [i].number = i;
//			basecharacter [i].charaName = "かぐや" + i.ToString();
//			basecharacter [i].atk = 100 * i;
//			basecharacter [i].def = 50 * i;
//			basecharacter [i].level = 5 * i;
//			basecharacter [i].rarerity = i;
//			basecharacter [i].cost = i;
//			basecharacter [i].skillName = "ポイズン";
//			basecharacter [i].skilllevel = 1;
//		}
	}
	void Update()
	{


		for (int i=0; i<selectCharaNumber.Length; i++)
			if (selectCharaNumber [i] == -1)
				Debug.Log ("selectCharNumber[" + i + "] is -1");

		for (int i=0; i<backCharaNumber.Count; i++)
			if (backCharaNumber [i] == -1)
				Debug.Log ("backCharNumber[" + i +"] is -1");

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
		serializeDataPath = Application.dataPath + "/PlayerData.xml";
		XMLUtility.Seialize<PlayerStatus>(serializeDataPath,playerStatus);
		serializeDataPath = Application.dataPath + "/SelectCharaData.xml";
		XMLUtility.Seialize<int[]> (serializeDataPath, selectCharaNumber);
		serializeDataPath = Application.dataPath + "/BackMemberData.xml";
		XMLUtility.Seialize<List<int>> (serializeDataPath, backCharaNumber);
		serializeDataPath = Application.dataPath + "/CharacterData.xml";
		XMLUtility.Seialize<List<Character>> (serializeDataPath, character);
		serializeDataPath = Application.dataPath + "/BaseCharacterData.xml";
		XMLUtility.Seialize<Character[]> (serializeDataPath, basecharacter);

	}




}