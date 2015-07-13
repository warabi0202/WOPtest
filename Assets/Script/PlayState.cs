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
	
	
	//定数
	public string[] charaName = new string[] { "Betelgeuse" };

	//キャラのclass
	public class Character{
		public int number;
		public int atk;
		public int def;
		public int level;
		public int rarerity;
		public int cost;
		public int skill;
		public string charaName;
		public string skillName;
		public int skilllevel;
		public Sprite img;
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
	{Debug.Log("init");
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
			character [i].number = i;
			character [i].charaName = "かぐや" + i.ToString();
			character [i].atk = 100 * i;
			character [i].def = 50 * i;
			character [i].level = 5 * i;
			character [i].rarerity = i;
			character [i].cost = i;
			character [i].skill = 1;
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
}
