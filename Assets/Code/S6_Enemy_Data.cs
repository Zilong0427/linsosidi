using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6_Enemy_Data : MonoBehaviour {

	public GameObject thisenemy;
	public Image hpbar;
	public GameObject hpbar_white;
	public int hp;
	public float currenthp;
	public int atk;
	public int def;
	public Vector2 pos;

	S6_Battle battlecode;

	// Use this for initialization
	void Start () {
		pos = thisenemy.transform.position;

		battlecode =GameObject.Find("Battle").GetComponent<S6_Battle>();
		currenthp = hp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		battlecode.offMonsterBoxCollider2D ();
		battlecode.offEnemyBoxCollider2D ();
		battlecode.Enemy = thisenemy;
	}
}
