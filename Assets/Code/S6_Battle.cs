using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S6_Battle : MonoBehaviour {
	
	//initial section
	public GameObject[] monster;
	public GameObject[] enemy;

	public GameObject Enemy_1_1;
	public GameObject Enemy_1_2;
	public GameObject Enemy_2_1;
	public GameObject Enemy_2_2;
	public GameObject Enemy_3_1;
	public GameObject Enemy_3_2;
	public GameObject Enemy_4_1;
	public GameObject Enemy_4_2;
	public GameObject Enemy_5_1;
	public GameObject Enemy_5_2;
	public GameObject Enemy_6_1;
	public GameObject Enemy_6_2;
	public GameObject Enemy_7_1;
	public GameObject Enemy_7_2;
	public GameObject Enemy_8_1;
	public GameObject Enemy_8_2;
	public GameObject Enemy_9_1;
	public GameObject Enemy_9_2;
	public GameObject Enemy_10_1;
	public GameObject Enemy_10_2;
	public GameObject Enemy_11_1;
	public GameObject Enemy_11_2;
	public GameObject Enemy_12_1;
	public GameObject Enemy_12_2;

	public GameObject grass;
	public GameObject forest;
	public GameObject valley;
	public GameObject snow;
	public GameObject volcano;
	public GameObject[] Panel_end;

	private int now_level;
	public int battle_level;
	private bool choosed;

	string abilitystring;
	string[] ability;

	//Attack section
	public GameObject Monster;
	public GameObject Enemy;

	private int monattacktimes;

	private int mon_died;
	private int ene_died;

	private bool startmonatk;
	private bool starteneatk;
	private bool startvictory;
	private bool startdefeat;
	private bool is49;

	//animation for mon atk
	public Animator bite;
	public Animator hit;
	public Animator craw;
	private Vector2 bitepos;
	private Vector2 hitpos;
	private Vector2 crawpos;

	//Victiry V Defeat
	public GameObject back_button;
	public GameObject bg_for_v_d;
	public GameObject victory;
	public GameObject defeat;
	public GameObject three_choice;
	public GameObject ScenceManagement;
	public bool loadscence2;
	public GameObject[] flowchart;
	// Use this for initialization
	void Start () {
		//get now & battle level
		now_level = PlayerPrefs.GetInt("now_level");
		battle_level = PlayerPrefs.GetInt("battle_level");
		//get info of passed or not
		int b = PlayerPrefs.GetInt ("choosed" + battle_level.ToString ());
		if (b == 1) {
			choosed = true; 
		} else {
			choosed = false;
		}

		//initial bk mon ene
		initialBackGround ();
		initialMonster ();
		initialEnemy ();

		monattacktimes = 0;

		mon_died=0;
		ene_died=0;

		startmonatk = false;
		starteneatk = false;
		startvictory = false;
		startdefeat = false;
		is49 = false;

		bitepos=bite.gameObject.transform.position;
		hitpos=hit.gameObject.transform.position;
		crawpos=craw.gameObject.transform.position;

		loadscence2 = false;
		if (battle_level == 12) {
			offInitial ();
			openFlowchart ();
		}
	}

	IEnumerator LoadMonAtk(){
		startmonatk = true;
		MonAtk ();
		switch ((Monster.GetComponent<S6_Monster_Data>().thismonsternumber-1) / 12) {
		case 0:
			hit.gameObject.transform.position = Enemy.GetComponent<S6_Enemy_Data>().pos;
			hit.Play ("hit");
			yield return new WaitForSeconds (1);
			hit.gameObject.transform.position = hitpos;
			break;
		case 1:
			bite.gameObject.transform.position = Enemy.GetComponent<S6_Enemy_Data>().pos;
			bite.Play ("bite");
			yield return new WaitForSeconds (1);
			bite.gameObject.transform.position = bitepos;
			break;
		case 2:
			craw.gameObject.transform.position = Enemy.GetComponent<S6_Enemy_Data>().pos;
			craw.Play ("craw");
			yield return new WaitForSeconds (1);
			craw.gameObject.transform.position = crawpos;
			break;
		}

		Monster.GetComponent<S6_Monster_Data> ().monattacked = true;

		Enehpedit ();
		//yield return new WaitForSeconds(1);

		S6_Monster_Data i = Monster.GetComponent<S6_Monster_Data> ();
		i.thismonster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprite/MyMonster/non_sparkle/monster" + i.thismonsternumber.ToString ());
		Monster.transform.position = Monster.GetComponent<S6_Monster_Data>().pos;
		Monster = null;
		Enemy = null;

		if(monattacktimes!=3){
			onMonsterBoxCollider2D ();
		}
		startmonatk = false;
		monattacktimes++;
	}

	IEnumerator LoadEneAtk(){
		yield return new WaitForSeconds(1);
		for(int i=0;i<2-ene_died;i++){
			EneAtk (i);
			yield return new WaitForSeconds(2);
			enemy[i].transform.position=enemy[i].GetComponent<S6_Enemy_Data>().pos;
			if (mon_died == 3) {
				//Debug.Log ("defeat-1");
				startdefeat = true;
				break;
			}
		}
		onMonsterBoxCollider2D ();
		monattacktimes = 0;


		for(int j=0;j<3;j++){
			monster[j].GetComponent<S6_Monster_Data>().monattacked=false;
		}

		starteneatk = false;
	}

	IEnumerator LoadVictory(){

		if (battle_level == 4 || battle_level == 9 || battle_level == 12 ) {
			is49 = true;
		}

		yield return new WaitForSeconds (2);
		bg_for_v_d.SetActive (true);
		Victory ();
		yield return new WaitForSeconds (3);
		if (battle_level != (now_level + 1) || choosed) {
			loadscence2 = true;
			ScenceManagement.SetActive (true);
		} else if (battle_level == (now_level + 1) && !choosed && !is49) {
			//offInitial ();
			three_choice.SetActive (true);
			victory.GetComponent<Image> ().color = new Color (0, 0, 0, 0);
		} else if (battle_level == (now_level + 1) && !choosed && is49 && battle_level != 12) {
			editNowLevel ();
			openFlowchart ();
			offInitial ();
			victory.GetComponent<Image> ().color = new Color (0, 0, 0, 0);
		} else if (battle_level == (now_level + 1) && !choosed && is49 && battle_level == 12) {
			offInitial ();
			victory.GetComponent<Image> ().color = new Color (0, 0, 0, 0);

			string m1 = PlayerPrefs.GetString("main1");
			string[] tm1 = m1.Split (',');
			int i1=int.Parse (tm1[0]);
			string m2 = PlayerPrefs.GetString("main2");
			string[] tm2 = m2.Split (',');
			int i2=int.Parse (tm2[0]);
			string m3 = PlayerPrefs.GetString("main3");
			string[] tm3 = m3.Split (',');
			int i3=int.Parse (tm3[0]);
			if( (i1==12||i1==24||i1==36) && (i2==12||i2==24||i2==36) && (i3==12||i3==24||i3==36)){
				Panel_end [0].SetActive (true);
			}
			else
				Panel_end [1].SetActive (true);
		}
	}



	IEnumerator LoadDefeat(){
		//Debug.Log ("defeat1");
		yield return new WaitForSeconds (2);
		//Debug.Log ("defeat2");
		Defeat ();
		//Debug.Log ("defeat6");
		yield return new WaitForSeconds (2);
		//Debug.Log ("defeat7");
		SceneManager.LoadScene ("Scence4_Advan");
	}



	// Update is called once per frame
	void Update () {
		if (ene_died == 2 && !startvictory) {
			startvictory = true;
			StartCoroutine ("LoadVictory");
		}

		if (startdefeat && !starteneatk) {
			startdefeat = false;
			//Debug.Log ("defeat0");
			StartCoroutine ("LoadDefeat");
		}

		if (monattacktimes == 3 - mon_died && 3 - mon_died != 0 && !starteneatk) {
			starteneatk = true;
			StartCoroutine ("LoadEneAtk");
		}

		if (Monster != null && Enemy != null && !startmonatk) {
			startmonatk = true;
			StartCoroutine ("LoadMonAtk");
		}
	}

	private void initialBackGround(){
		if (battle_level < 4) {
			grass.SetActive (true);
		} else if (battle_level >= 4 && battle_level < 7) {
			forest.SetActive (true);
		} else if (battle_level >= 7 && battle_level < 9) {
			valley.SetActive (true);
		} else if (battle_level >= 9 && battle_level < 11) {
			snow.SetActive (true);
		} else {
			volcano.SetActive (true);
		}
	}

	private void initialMonster(){
		int mon_num = 0;
		for(int i=2;i<5;i++){
			S6_Monster_Data j = monster [mon_num].GetComponent<S6_Monster_Data> ();
			mon_num++;
			abilitystring = PlayerPrefs.GetString ("main" + (i % 3 + 1));
			ability = abilitystring.Split (',');
			j.thismonsternumber = int.Parse (ability [0]);
			j.hp = int.Parse (ability [2]);
			j.currenthp = j.hp;
			j.atk = int.Parse (ability [3]);
			j.def = int.Parse (ability [4]);
			j.ability_1 = int.Parse (ability [1]).ToString();
			j.ability_5 = int.Parse (ability [5]).ToString();
			j.thismonster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprite/MyMonster/non_sparkle/monster" + j.thismonsternumber.ToString ());
		}
	}

	private void initialEnemy(){
		switch (battle_level) {
		case 1:
			enemy [0] = Enemy_1_1;
			enemy [1] = Enemy_1_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 2:
			enemy [0] = Enemy_2_1;
			enemy [1] = Enemy_2_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 3:
			enemy [0] = Enemy_3_1;
			enemy [1] = Enemy_3_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 4:
			enemy [0] = Enemy_4_1;
			enemy [1] = Enemy_4_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 5:
			enemy [0] = Enemy_5_1;
			enemy [1] = Enemy_5_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 6:
			enemy [0] = Enemy_6_1;
			enemy [1] = Enemy_6_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 7:
			enemy [0] = Enemy_7_1;
			enemy [1] = Enemy_7_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 8:
			enemy [0] = Enemy_8_1;
			enemy [1] = Enemy_8_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 9:
			enemy [0] = Enemy_9_1;
			enemy [1] = Enemy_9_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 10:
			enemy [0] = Enemy_10_1;
			enemy [1] = Enemy_10_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 11:
			enemy [0] = Enemy_11_1;
			enemy [1] = Enemy_11_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		case 12:
			enemy [0] = Enemy_12_1;
			enemy [1] = Enemy_12_2;
			for (int i = 0; i < 2; i++) {
				enemy [i].SetActive (true);
			}
			break;
		}
	}

	public void onEnemyBoxCollider2D(){
		for (int i = 0; i < 2; i++) {
			enemy [i].GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	public void offEnemyBoxCollider2D(){
		for (int i = 0; i < 2; i++) {
			enemy [i].GetComponent<BoxCollider2D> ().enabled = false;
		}
	}

	public void onMonsterBoxCollider2D(){
		for (int i = 0; i < 3; i++) {
			monster [i].GetComponent<BoxCollider2D> ().enabled = true;
		}
	}

	public void offMonsterBoxCollider2D(){
		for (int i = 0; i < 3; i++) {
			monster [i].GetComponent<BoxCollider2D> ().enabled = false;
		}
	}

	public void editNowLevel(){
		if (!choosed) {
			PlayerPrefs.SetInt ("choosed" + battle_level.ToString (), 1);
			if(battle_level == now_level + 1){
				now_level++;
				PlayerPrefs.SetInt ("now_level", now_level);
			}
		}
	}

	private void MonAtk(){
		Vector2 monpos = Monster.GetComponent<S6_Monster_Data>().pos;
		Vector2 enepos = Enemy.GetComponent<S6_Enemy_Data>().pos;
		Monster.transform.Translate ((enepos - monpos) / 1.5f);
		Monster.GetComponent<S6_Monster_Data> ().monattacked = true;
		//monattacktimes++;
	}

	//edit ene hp & hpbar
	private void Enehpedit(){
		S6_Monster_Data oo = Monster.GetComponent<S6_Monster_Data> ();
		S6_Enemy_Data o = Enemy.GetComponent<S6_Enemy_Data> ();
		if (oo.atk - o.def > 0) {
			o.currenthp -= (oo.atk - o.def);
			if (o.currenthp <= 0) {
				Enemy.SetActive (false);
				Enemy.GetComponent<S6_Enemy_Data> ().hpbar_white.SetActive (false);
				ene_died++;
			}
		} else {
			o.currenthp -= 10;
		}
		o.hpbar.fillAmount = o.currenthp / o.hp;
	}

	private void EneAtk(int j){
		int i;
		do{	
			i = Random.Range (0, 3);
		}while(monster[i].GetComponent<S6_Monster_Data>().died);
		Vector2 monpos = monster [i].GetComponent<S6_Monster_Data>().pos;
		Vector2 enepos = enemy [j].GetComponent<S6_Enemy_Data>().pos;
		enemy [j].transform.Translate ((monpos - enepos) / 2);
		S6_Monster_Data o = monster[i].GetComponent<S6_Monster_Data> ();
		S6_Enemy_Data oo = enemy[j].GetComponent<S6_Enemy_Data> ();
		if (oo.atk - o.def > 0) {
			o.currenthp -= (oo.atk - o.def);
			if (o.currenthp <= 0) {
				monster [i].SetActive (false);
				monster [i].GetComponent<S6_Monster_Data> ().hpbar_white.SetActive (false);
				monster [i].GetComponent<S6_Monster_Data> ().died = true;
				mon_died++;
			} else {
				o.currenthp -= 10;
			}
		}
		o.hpbar.fillAmount = o.currenthp / o.hp;
	}

	public void Victory(){
		offMonsterBoxCollider2D ();
		back_button.SetActive (false);
		victory.SetActive (true);
		bg_for_v_d.SetActive (true);
	}

	public void Defeat(){
		//Debug.Log ("defeat3");
		back_button.SetActive (false);
		//Debug.Log ("defeat4");
		defeat.SetActive (true);
		//Debug.Log ("defeat5");
		bg_for_v_d.SetActive (true);
	}

	//delay initial battle section
	public void offInitial(){
		for (int i = 0; i < 3; i++) {
			monster [i].GetComponent<S6_Monster_Data> ().hpbar_white.SetActive (false);
			monster [i].SetActive (false);
		}
		for (int i = 0; i < 2; i++) {
			enemy [i].GetComponent<S6_Enemy_Data> ().hpbar_white.SetActive (false);
			enemy [i].SetActive (false);
		}
	}

	public void onInitial(){
		for (int i = 0; i < 3; i++) {
			monster [i].GetComponent<S6_Monster_Data> ().hpbar_white.SetActive (true);
			monster [i].SetActive (true);
		}
		for (int i = 0; i < 2; i++) {
			enemy [i].GetComponent<S6_Enemy_Data> ().hpbar_white.SetActive (true);
			enemy [i].SetActive (true);
		}
	}
	void openFlowchart(){
		flowchart [battle_level - 1].SetActive (true);
	}
}
