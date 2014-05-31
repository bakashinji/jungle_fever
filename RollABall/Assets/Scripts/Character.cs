using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private int hp = 100;

	public int Hp {
		get {
			return hp;
		}
		set {
			hp = value;
		}
	}

	private int maxHp = 100;
	Vector2 hpPos = new Vector2(20,20);
	Vector2 hpSize = new Vector2(120,40);
	public int hpReg = 1;

	private int level = 1;
	private int exp = 0;

	public int Exp {
		get {
			return exp;
		}
		set {
			exp = value;
		}
	}

	int lvlExp = 0;
	int neededExp = 5;
	int offsetExp = 5;
	Vector2 expPos = new Vector2(20,60);
	Vector2 expSize = new Vector2(120,40);

	public Texture2D progressBarEmpty;
	public Texture2D progressBarHP;
	public Texture2D progressBarExp;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("regHP", 0.1f, 1.0f);
	}

	void regHP() {
		if ((hpReg + hp) > maxHp)
			hp = maxHp;
		else
			hp += hpReg;
	}

	int AccSum(int level, int offsetExp){
		int sum = 0;
		for (int i = 1; i < level; i++) {
			sum += offsetExp*i;
		}
		return sum;
	}
	
	// Update is called once per frame
	void Update () {
		lvlExp = exp - AccSum (level, offsetExp);
		if (lvlExp >= neededExp) {
			level++;
			lvlExp -= neededExp;
			neededExp += offsetExp;
		}

		// HP

		//int regHP = (int)(maxHp * hpRegRate);

	}
	
	void OnGUI()
	{
		// HPBar

		GUI.BeginGroup(new Rect(hpPos.x, hpPos.y, hpSize.x, hpSize.y));
			GUI.Box(new Rect(0,0, hpSize.x, hpSize.y), progressBarEmpty);
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, hpSize.x * hp/maxHp, hpSize.y));
				GUI.Box(new Rect(0,0, hpSize.x, hpSize.y), progressBarHP);
			GUI.EndGroup();
		GUI.EndGroup();

		// ExpBar

		string disLevel = "Level: " + level.ToString ();
		
		//draw the background:
		GUI.BeginGroup(new Rect(expPos.x, expPos.y, expSize.x, expSize.y));
			GUI.Box(new Rect(0,0, expSize.x, expSize.y), progressBarEmpty);
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, expSize.x * lvlExp/neededExp, expSize.y));
				GUI.Box(new Rect(0,0, expSize.x, expSize.y), progressBarExp);
					GUI.Label(new Rect(0,0, expSize.x, expSize.y), disLevel);
		        GUI.EndGroup();
		GUI.EndGroup();

	} 

}
