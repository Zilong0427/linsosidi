using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S1_SettingEgg : MonoBehaviour {
	public GameObject[] pa_quest;
	public GameObject pa_env1_yes;
	public GameObject pa_env1_no;
	public GameObject pa_image;
	public GameObject[] bg_env;
	public GameObject black;
	public GameObject bg_qus;
	public int env1_egg;
	public int env2_egg;
	public int env3_egg;
	public int temp_egg;
	public int now_env;
	public int rand_i;
	public int rand_j;
	//private GameObject quest;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (S1_start_setting.ifsetegg == true) {
			bg_qus.SetActive (true);
			pa_image.SetActive (false);
			pa_env1_yes.SetActive (false);
			pa_env1_no.SetActive (false);
			rand_i = Random.Range (0, 2);
			if(rand_i==0)
				Set_quset (1);
			else if (rand_i == 1)
				Set_quset (5);
			else if(rand_i==2)
				Set_quset(9);
			Set_egg ();
			S1_start_setting.ifsetegg = false;
		}
		if (now_env == 1)
			bg_env [now_env - 1].transform.position = new Vector3 (0, 0, 0);
		if (now_env == 2) {
			bg_env [now_env - 2].transform.position = new Vector3 (15, 0, 0);
			bg_env [now_env - 1].transform.position = new Vector3 (0, 0, 0);
		}
		if (now_env == 3) {
			bg_env [now_env - 2].transform.position = new Vector3 (30, 0, 0);
			bg_env [now_env - 1].transform.position = new Vector3 (0, 0, 0);
		}
	}
	void show_egg(){
		Debug.Log ("env1_egg" + env1_egg);
		Debug.Log ("env2_egg" + env2_egg);
		Debug.Log ("env3_egg" + env3_egg);

	}
	void Set_egg(){
		temp_egg = S1_start_setting.choice_egg;
		int h = temp_egg / 100;
		temp_egg -= h * 100;
		int t = temp_egg / 10;
		temp_egg -= t * 10;
		env1_egg = h * 1000;
		env2_egg = t * 1000;
		env3_egg = temp_egg * 1000;
	}

	void Set_quset(int i){
		pa_quest [i - 1].SetActive (true);
		Debug.Log ("set" + i);
	}
	void Out_quest(int i){
		pa_quest [i - 1].SetActive (false);
		Debug.Log ("out" + i);
	}
	public void Q1_A1(){
		if (rand_i == 0) {
			Out_quest (1);
			env1_egg += 1 * 100;
			env2_egg += 1 * 100;
			env3_egg += 1 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 1) {
			Out_quest (5);
			env1_egg += 4 * 100;
			env2_egg += 4 * 100;
			env3_egg += 4 * 100;
			rand_j= Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 2) {
			Out_quest (9);
			env1_egg += 7 * 100;
			env2_egg += 7 * 100;
			env3_egg += 7 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
	}
	public void Q1_A2(){
		if (rand_i == 0) {
			Out_quest (1);
			env1_egg += 2 * 100;
			env2_egg += 2 * 100;
			env3_egg += 2 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 1) {
			Out_quest (5);
			env1_egg += 5 * 100;
			env2_egg += 5 * 100;
			env3_egg += 5 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 2) {
			Out_quest (9);
			env1_egg += 8 * 100;
			env2_egg += 8 * 100;
			env3_egg += 8 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
	}
	public void Q1_A3(){
		if (rand_i == 0) {
			Out_quest (1);
			env1_egg += 3 * 100;
			env2_egg += 3 * 100;
			env3_egg += 3 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 1) {
			Out_quest (5);
			env1_egg += 6 * 100;
			env2_egg += 6 * 100;
			env3_egg += 6 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
		else if (rand_i == 2) {
			Out_quest (9);
			env1_egg += 9 * 100;
			env2_egg += 9 * 100;
			env3_egg += 9 * 100;
			rand_j = Random.Range (0, 2);
			if (rand_j == 0)
				Set_quset (2);
			else if (rand_j == 1)
				Set_quset (6);
			else if(rand_j==2)
				Set_quset(10);
		}
	}
	public void Q2_A1(){
		now_env = 1;
		if (rand_j == 0) {
			Out_quest (2);
			env1_egg += 1 * 10;
			env2_egg += 1 * 10;
			env3_egg += 1 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}
		if (rand_j == 1) {
			Out_quest (6);
			env1_egg += 3 * 10;
			env2_egg += 3 * 10;
			env3_egg += 3 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}if (rand_j == 2) {
			Out_quest (10);
			env1_egg += 5 * 10;
			env2_egg += 5 * 10;
			env3_egg += 5 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}
	}
	public void Q2_A2(){
		now_env = 1;
		if (rand_j == 0) {
			Out_quest (2);
			env1_egg += 2 * 10;
			env2_egg += 2 * 10;
			env3_egg += 2 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}
		if (rand_j == 1) {
			Out_quest (6);
			env1_egg += 4 * 10;
			env2_egg += 4 * 10;
			env3_egg += 4 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}if (rand_j == 2) {
			Out_quest (10);
			env1_egg += 6 * 10;
			env2_egg += 6 * 10;
			env3_egg += 6 * 10;
			if (env1_egg / 1000 == 1)
				Set_quset (8);
			if (env1_egg / 1000 == 3)
				Set_quset (4);
		}
	}
	public void Q3_A1(){
		if (now_env == 2 && env2_egg / 1000 == 3) {
			env2_egg += 1;
			now_env = 3;
			Out_quest(3);
			if (env3_egg / 1000 == 1)
				Set_quset (7);
			if (env3_egg / 1000 == 2)
				Set_quset (11);
		}
		else if (now_env == 3 && env3_egg / 1000 == 1) {
			env3_egg += 1;
			Out_quest(7);
			PlayerPrefs.SetInt ("env1_egg", env1_egg);
			PlayerPrefs.SetInt ("env2_egg", env2_egg);
			PlayerPrefs.SetInt ("env3_egg", env3_egg);
			PlayerPrefs.Save ();
			setability(1,env1_egg);
			setability(2,env2_egg);
			setability(3,env3_egg);
			StartCoroutine (wait ());
		}
		else if (now_env == 3 && env3_egg / 1000 == 2) {
			env3_egg += 1;
			Out_quest (3);
			PlayerPrefs.SetInt ("env1_egg", env1_egg);
			PlayerPrefs.SetInt ("env2_egg", env2_egg);
			PlayerPrefs.SetInt ("env3_egg", env3_egg);
			PlayerPrefs.Save ();
			setability(1,env1_egg);
			setability(2,env2_egg);
			setability(3,env3_egg);
			StartCoroutine (wait ());
		}
	}
	public void Q3_A2(){
		if (now_env == 2 && env2_egg / 1000 == 3) {
			env2_egg += 2;
			now_env = 3;
			Out_quest(3);
			if (env3_egg / 1000 == 1)
				Set_quset (7);
			if (env3_egg / 1000 == 2)
				Set_quset (11);
		}
		else if (now_env == 3 && env3_egg / 1000 == 1) {
			env3_egg += 2;
			Out_quest(7);
			PlayerPrefs.SetInt ("env1_egg", env1_egg);
			PlayerPrefs.SetInt ("env2_egg", env2_egg);
			PlayerPrefs.SetInt ("env3_egg", env3_egg);
			PlayerPrefs.Save ();
			setability(1,env1_egg);
			setability(2,env2_egg);
			setability(3,env3_egg);
			StartCoroutine (wait ());
		}
		else if (now_env == 3 && env3_egg / 1000 == 2) {
			env3_egg += 2;
			Out_quest (11);
			PlayerPrefs.SetInt ("env1_egg", env1_egg);
			PlayerPrefs.SetInt ("env2_egg", env2_egg);
			PlayerPrefs.SetInt ("env3_egg", env3_egg);
			PlayerPrefs.Save ();
			setability(1,env1_egg);
			setability(2,env2_egg);
			setability(3,env3_egg);
			StartCoroutine (wait ());
		}
	}
	public void Q4_A1(){
		if (now_env == 1 && env1_egg / 1000 == 3) {
			env1_egg += 1;
			now_env = 2;
			Out_quest(4);
			if (env2_egg / 1000 == 2)
				Set_quset (12);
			if (env2_egg / 1000 == 3)
				Set_quset (3);
		}
		else if (now_env == 1 && env1_egg / 1000 == 1) {
			env1_egg += 1;
			now_env = 2;
			Out_quest(8);
			if (env2_egg / 1000 == 2)
				Set_quset (12);
			if (env2_egg / 1000 == 3)
				Set_quset (3);
		}
		else if (now_env == 2 && env2_egg / 1000 == 2) {
			env2_egg += 1;
			now_env = 3;
			Out_quest(12);
			if (env3_egg / 1000 == 1)
				Set_quset (7);
			if (env3_egg / 1000 == 2)
				Set_quset (11);
		}
	}
	public void Q4_A2(){
		if (now_env == 1 && env1_egg / 1000 == 3) {
			env1_egg += 2;
			now_env = 2;
			Out_quest(4);
			if (env2_egg / 1000 == 2)
				Set_quset (12);
			if (env2_egg / 1000 == 3)
				Set_quset (3);
		}
		else if (now_env == 1 && env1_egg / 1000 == 1) {
			env1_egg += 2;
			now_env = 2;
			Out_quest(8);
			if (env2_egg / 1000 == 2)
				Set_quset (12);
			if (env2_egg / 1000 == 3)
				Set_quset (3);
		}
		else if (now_env == 2 && env2_egg / 1000 == 2) {
			env2_egg += 2;
			now_env = 3;
			Out_quest(12);
			if (env3_egg / 1000 == 1)
				Set_quset (7);
			if (env3_egg / 1000 == 2)
				Set_quset (11);
		}
	}
	IEnumerator wait(){
		for (int i = 0; i < pa_quest.Length; ++i)
			pa_quest [i].SetActive (false);
		black.SetActive (true);
		black.GetComponent<S0_fadeinout> ().set_isin (false);
		for(int i=1;i<13;++i){
			PlayerPrefs.SetInt ("choosed" + i, 0);
		}
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Scence2_Main");
	}

	public void setability(int env,int ability){
		int egg = (int) ability / 1000;
		int select1 = (int) ability / 100 - ((int) ability / 1000)*10;
		int select2 = (int) ability / 10 - ((int) ability / 100)*10;
		int select3 = (int) ability % 10;

		int dexn = 0;//圖鑑編號
		int hp = 0;
		int atk = 0;
		int def = 0;
		int evostage = 1;//進化到第幾階段
		int bgenv = env;//背景屬性

		int addmountsmall = 10; //能力增加(少量)
		int addmountmedium = 20;//能力增加(中量)
		int addmountlarge = 30;//能力增加(大量)


		//問題一(你想要)
		if (select1 == 1) {//def
			def = def + addmountmedium;
		}
		else if (select1 == 2) {//atk
			atk = atk + addmountmedium;
		}
		else if (select1 == 3) {//hp
			hp = hp + addmountmedium;
		}
		else if (select1 == 4) {//hp
			hp = hp + addmountmedium;
		}
		else if (select1 == 5) {//atk
			atk = atk + addmountmedium;
		}
		else if (select1 == 6) {//def
			def = def + addmountmedium;
		}
		else if (select1 == 7) {//atk
			atk = atk + addmountmedium;
		}
		else if (select1 == 8) {//def
			def = def + addmountmedium;
		}
		else if (select1 == 9) {//hp
			hp = hp + addmountmedium;
		}


		//問題二(你喜歡)
		if (select2 == 1) {
			def = def + addmountmedium;
			hp = hp + addmountmedium;
		}
		else if (select2 == 2) {
			hp = hp + addmountlarge;
		}
		else if (select2 == 3) {
			atk = atk + addmountsmall;
			hp = hp + addmountsmall;
		}
		else if (select2 == 4) {
			atk = atk + addmountmedium;
		}
		else if (select2 == 5) {
			def = def + addmountmedium;
		}
		else if (select2 == 6) {
			atk = atk + addmountsmall;
			def = def + addmountsmall;
		}



		//問題三(你認為)
		if (select3 == 1) {
			if (egg == 1) {
				if (env == 1) {
					dexn = 10;
				} 
				else if (env == 3) {
					dexn = 4;
				}
			} 
			else if (egg == 2) {
				if (env == 2) {
					dexn = 16;
				} 
				else if (env == 3) {
					dexn = 19;
				}
			}
			else if (egg == 3) {
				if (env == 1) {
					dexn = 31;
				} 
				else if (env == 2) {
					dexn = 28;
				}
			}
		}
		else if (select3 == 2) {
			if (egg == 1) {
				if (env == 1) {
					dexn = 7;
				} 
				else if (env == 3) {
					dexn = 1;
				}
			} 
			else if (egg == 2) {
				if (env == 2) {
					dexn = 13;
				} 
				else if (env == 3) {
					dexn = 22;
				}
			}
			else if (egg == 3) {
				if (env == 1) {
					dexn = 25;
				} 
				else if (env == 2) {
					dexn = 34;
				}
			}
		}
		if (dexn == 1 || dexn == 4 || dexn == 7 || dexn == 10) {
			hp += 100;
			atk += 70;
			def += 40;
		}
		else if (dexn == 13 || dexn == 16 || dexn == 19 || dexn == 22) {
			hp += 90;
			atk += 50;
			def += 60;
		}
		else if (dexn == 25 || dexn == 28 || dexn == 31 || dexn == 34) {
			hp += 120;
			atk += 50;
			def += 50;
		}
		Debug.Log (" " + hp + " " + atk + " " + def);
		//存檔
		PlayerPrefs.SetString ("main"+env, dexn+","+bgenv+","+hp+","+atk+","+def+","+evostage);//evostage進化第幾階段
		PlayerPrefs.SetInt ("dexnumber"+dexn,10);//開dexn號圖鑑 非0就是打開
		PlayerPrefs.Save ();
		//
	}

}
