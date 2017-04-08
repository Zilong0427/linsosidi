using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S4_gotobattle : MonoBehaviour {
	public GameObject[] levels,leves_lock;
	public GameObject black;
	public GameObject monster;
	public S0_fadeinout white;
	public GameObject canvas,click;
	int level;
	public string[] tempmain;
	// Use this for initialization
	void Start () {
		black.SetActive (true);
		black.GetComponent<S0_fadeinout> ().set_isin (true);
		level = PlayerPrefs.GetInt ("now_level");
		//level = 5;
		for (int i=0;i<=level;++i) {
			levels [i].SetActive (true);
			leves_lock [i].SetActive (false);
		}
		for (int i = 11; i > level; --i) {
			levels [i].SetActive (false);
			leves_lock [i].SetActive (true);
		}
		string s = PlayerPrefs.GetString ("main1");
		tempmain = s.Split (',');
		//if (level == 3 && int.Parse (tempmain [5])==1)
		//	StartCoroutine(DoEvo(1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator DoEvo(int k){
		click.SetActive (false);
		for (int i = 0; i < 6; ++i) {
			levels [i].GetComponent<CircleCollider2D> ().enabled = false;
		}
		canvas.SetActive (false);
		for (int i = 1; i < 4; ++i) {
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
			monster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprite/monster/monster"+dexn.ToString());
			yield return new WaitForSeconds (2);
			white.set_isin (false);
			PlayerPrefs.SetString ("main" + i, dexn.ToString () + "," + tempmain [1] + "," + hp + "," + atk + "," + def + "," + evo);
			PlayerPrefs.SetInt ("dexnumber"+dexn,10);
			PlayerPrefs.Save ();
			yield return new WaitForSeconds (2);
			white.gameObject.SetActive (false);
		}
		click.SetActive (true);
		for (int i = 0; i < 6; ++i) {
			levels [i].GetComponent<CircleCollider2D> ().enabled = true;
		}
		canvas.SetActive (true);
		monster.GetComponent<SpriteRenderer> ().sprite = null;
	}


}
