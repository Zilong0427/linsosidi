using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class S2_bgcontrol : MonoBehaviour {
	public GameObject monster;//放進化時的怪物
	public GameObject[] evothing;//進化時要關掉的東西
	public GameObject[] bg;
	public GameObject attr;
	public GameObject canvas;
	public S0_fadeinout white;
	public S2_btncontrol s2btncontrol;
	public S2_Monster_move s2monstermove;
	int maincharacher ;//主畫面當前顯示的靈獸
	int level;
	public string[] tempmain;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("ifnew", 1);
		if (PlayerPrefs.GetInt ("ifnew") == 0) {
			StartCoroutine (startset ());

		}else{	
			maincharacher = PlayerPrefs.GetInt("maincharacher");
			//順序都是火、草、冰
			bg[maincharacher%3].transform.position = new Vector3 (0, 0, 0);
			attr.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprite/attr/"+maincharacher%3);//左上角的屬性
			//attr[maincharacher%3].transform.position = new Vector3 (-4.9f, 9.25f, 0);//左上角的屬性
			//ResetAllcomponent ();
		}
		level = PlayerPrefs.GetInt ("now_level");
		string s = PlayerPrefs.GetString ("main1");
		tempmain = s.Split (',');
		if (level == 4 && int.Parse (tempmain [5])==1)
			StartCoroutine(DoEvo(1));
		else if(level == 9 && int.Parse (tempmain [5])==2)
			StartCoroutine(DoEvo(2));
		
	}
	IEnumerator startset(){
		s2monstermove.enabled = false;
		canvas.SetActive (false);
		int eggs = PlayerPrefs.GetInt ("choice_egg");
		int fire = eggs / 100;
		eggs = eggs % 100;
		int grass = eggs / 10;
		int ice = eggs % 10;
		bg[0].transform.position = new Vector3 (0, 0, 0);
		s2btncontrol.showmonster (fire + 36);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (true);
		white.set_isin (true);
		yield return new WaitForSeconds (1);
		string abilitystring = PlayerPrefs.GetString("main"+1);
		string[] ability = abilitystring.Split (',');
		s2btncontrol.showmonster (int.Parse (ability [0]));
		yield return new WaitForSeconds (2);
		white.set_isin (false);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (false);

		bg[0].transform.position = new Vector3 (15, 0, 0);
		bg [1].transform.position = new Vector3 (0, 0, 0);
		s2btncontrol.showmonster (grass + 36);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (true);
		white.reset ();
		yield return new WaitForSeconds (1);
		abilitystring = PlayerPrefs.GetString("main"+2);
		ability = abilitystring.Split (',');
		s2btncontrol.showmonster (int.Parse (ability [0]));
		yield return new WaitForSeconds (2);
		white.set_isin (false);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (false);

		bg[1].transform.position = new Vector3 (30, 0, 0);
		bg[2].transform.position = new Vector3 (0, 0, 0);
		s2btncontrol.showmonster (ice + 36);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (true);
		white.reset ();
		yield return new WaitForSeconds (1);
		abilitystring = PlayerPrefs.GetString("main"+3);
		ability = abilitystring.Split (',');
		s2btncontrol.showmonster (int.Parse (ability [0]));
		yield return new WaitForSeconds (2);
		white.set_isin (false);
		yield return new WaitForSeconds (2);
		white.gameObject.SetActive (false);

		bg[2].transform.position = new Vector3 (45, 0, 0);
		white.gameObject.SetActive(false);
		canvas.SetActive(true);
		PlayerPrefs.SetInt ("ifnew", 1);
		s2btncontrol.startsetting ();
		s2monstermove.enabled = true;
		PlayerPrefs.SetInt ("now_level", 0);
		PlayerPrefs.Save ();
	}


	void ResetAllcomponent () {
		for (int i = 0; i < bg.Length; i++) {
			bg[i].transform.position = new Vector3 (15*i+15, 0, 0);
			attr.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprite/attr/"+i);//左上角的屬性
		}
	}

	public void changebg(int i) {
		//Debug.Log ("changebg");
		ResetAllcomponent ();
		bg[i].transform.position = new Vector3 (0, 0, 0);
		attr.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprite/attr/"+i);//左上角的屬性
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//測試 使能力增加9999
	public void Be9999(){
		for (int i = 1; i < 4; ++i) {
			string s = PlayerPrefs.GetString ("main" + i);
			tempmain = s.Split (',');
			int evo = int.Parse (tempmain [5]) ;
			int dexn = int.Parse (tempmain [0]) ;
			int hp = int.Parse (tempmain [2]);
			int atk = int.Parse (tempmain [3]);
			int def = int.Parse (tempmain [4]);
			hp += 9999;
			atk += 9999;
			def += 9999;
			PlayerPrefs.SetString ("main" + i, dexn.ToString () + "," + tempmain [1] + "," + hp + "," + atk + "," + def + "," + evo);
			PlayerPrefs.SetInt ("dexnumber"+dexn,10);

		}
		PlayerPrefs.Save ();
	}

	IEnumerator DoEvo(int k){
		foreach (GameObject temp in evothing)
			temp.SetActive (false);
		//canvas.SetActive (false);
		for (int i = 1; i < 4; ++i) {
			changebg (i - 1);
			string s = PlayerPrefs.GetString ("main" + i);
			tempmain = s.Split (',');
			monster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprite/monster/monster"+tempmain[0]);
			yield return new WaitForSeconds (2);
			white.gameObject.SetActive (true);
			white.set_isin (true);
			yield return new WaitForSeconds (1);
			int evo = int.Parse (tempmain [5]) + 1;
			int dexn = int.Parse (tempmain [0]) + 1;
			int hp = int.Parse (tempmain [2]);
			int atk = int.Parse (tempmain [3]);
			int def = int.Parse (tempmain [4]);
			//第一次進化
			if (dexn < 13 && k == 1) {
				hp += 700;
				atk += 300;
				def += 200;
			} else if (dexn > 12 && dexn < 25 && k == 1) {
				hp += 580;
				atk += 240;
				def += 280;
			} else if (dexn > 24 && k == 1) {
				hp += 880;
				atk += 260;
				def += 260;
			}
			//第二次進化
			else if (dexn < 13 && k == 2) {
				hp += 1400;
				atk += 600;
				def += 100;
			} else if (dexn > 12 && dexn < 25 && k == 2) {
				hp += 1180;
				atk += 200;
				def += 500;
			} else if (dexn > 24 && k == 2) {
				hp += 2000;
				atk += 400;
				def += 330;
			}
			//第三次進化
			else if (dexn < 13 && k == 3) {
				hp += 4000;
				atk += 2800;
				def += 1500;
			} else if (dexn > 12 && dexn < 25 && k == 3) {
				hp += 3300;
				atk += 1700;
				def += 2500;
			} else if (dexn > 24 && k == 3) {
				hp += 6200;
				atk += 1500;
				def += 1500;
			}
			monster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprite/monster/monster"+dexn.ToString());
			yield return new WaitForSeconds (2);
			white.set_isin (false);
			PlayerPrefs.SetString ("main" + i, dexn.ToString () + "," + tempmain [1] + "," + hp + "," + atk + "," + def + "," + evo);
			PlayerPrefs.SetInt ("dexnumber"+dexn,10);
			PlayerPrefs.Save ();
			yield return new WaitForSeconds (2);
			white.gameObject.SetActive (false);
		}

		foreach (GameObject temp in evothing)
			temp.SetActive (true);
		changebg (maincharacher % 3);
		string abilitystring = PlayerPrefs.GetString("main"+(maincharacher%3+1));
		string[] ability = abilitystring.Split (',');
		s2btncontrol.showmonster (int.Parse(ability[0]));
		monster.GetComponent<SpriteRenderer> ().sprite = null;
	}

}
