using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6_Monster_Data : MonoBehaviour {

	public GameObject thismonster;
	public Image hpbar;
	public GameObject hpbar_white;
	public int hp;
	public float currenthp;
	public int atk;
	public int def;
	public Vector2 pos;
	public int thismonsternumber;
	public string ability_1;
	public string ability_5;

	private int clicktimes;
	public bool monattacked;

	public bool died;

	S6_Battle battlecode;

	// Use this for initialization
	void Start () {
		pos = thismonster.transform.position;

		clicktimes = 0;
		monattacked = false;

		died = false;

		battlecode =GameObject.Find("Battle").GetComponent<S6_Battle>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		clicktimes++;
		if (!monattacked) {
			if (clicktimes % 2 == 0) {
				battlecode.onMonsterBoxCollider2D ();
				battlecode.offEnemyBoxCollider2D ();
				battlecode.Monster = null;
				thismonster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprite/MyMonster/non_sparkle/monster" + thismonsternumber.ToString ());
			} else {
				battlecode.offMonsterBoxCollider2D ();
				thismonster.GetComponent<BoxCollider2D> ().enabled = true;
				battlecode.onEnemyBoxCollider2D ();
				battlecode.Monster = thismonster;
				thismonster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprite/MyMonster/sparkle/monster" + thismonsternumber.ToString ());
			}

		}
	}

	public void editHp(int i){
		hp += i;
		PlayerPrefs.SetString ("main" + ability_1, thismonsternumber.ToString () + "," + ability_1 + "," + hp.ToString () + "," + atk.ToString () + "," + def.ToString () + "," + ability_5);
	}

	public void editAtk(int i){
		atk += i;
		PlayerPrefs.SetString ("main" + ability_1, thismonsternumber.ToString () + "," + ability_1 + "," + hp.ToString () + "," + atk.ToString () + "," + def.ToString () + "," + ability_5);
	}

	public void editDef(int i){
		def += i;
		PlayerPrefs.SetString ("main" + ability_1, thismonsternumber.ToString () + "," + ability_1 + "," + hp.ToString () + "," + atk.ToString () + "," + def.ToString () + "," + ability_5);
	}
}
