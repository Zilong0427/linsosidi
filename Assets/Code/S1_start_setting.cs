using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class S1_start_setting : MonoBehaviour {
//	public Slider vol;
	public GameObject bg_start;
	public GameObject bg_setting;
	public GameObject pa_choice_start;
	public GameObject pa_setting;
	//public GameObject pa_choice_env;
	public GameObject flowchart;
	public GameObject pa_story;
	public GameObject bg_story;
	public GameObject word_story;
	public GameObject black;
	public GameObject black2;
	public GameObject[] pa_env;
	public GameObject png_env;
	public GameObject[] bg_env;
	public GameObject[] eggs;
	bool egg1,egg2,egg3;
	public bool ifnew=true;
	public int what_env;
	public static int what_egg;
	public GameObject[] Three_eggs;
	public static int choice_egg;
	public static bool ifsetegg=false;
	public bool isstory=false;
	public int show_chegg;
	public int show_egg;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();//先刪除所有的存檔
		int getnew = PlayerPrefs.GetInt ("ifnew");
		//getnew = 0;
		if (getnew == 0) {
			egg1 = false;
			egg2 = false;
			egg3 = false;
			ifnew = true;
			ifsetegg = false;
		}
		else
			ifnew = false;
	}

	// Update is called once per frame
	void Update () {
		//if(isstory==true)
		//	word_story.transform.Translate (new Vector3 (0, 3 * Time.deltaTime, 0));
		
		show_chegg = choice_egg;
		show_egg = what_egg;
		if (what_egg == 1) {
			if (what_env == 1 || what_env == 3)
				pa_env [0].SetActive (true);
			if (what_env == 2)
				pa_env [1].SetActive (true);
			setCollider (false);
		}
		if (what_egg == 2) {
			if (what_env == 2 || what_env == 3)
				pa_env [0].SetActive (true);
			if (what_env == 1)
				pa_env [1].SetActive (true);
			setCollider (false);
		}
		if (what_egg == 3) {
			if (what_env == 1 || what_env == 2)
				pa_env [0].SetActive (true);
			if (what_env == 3)
				pa_env [1].SetActive (true);
			setCollider (false);
		}
	}
	void setCollider(bool b){
		if(!egg1)
			eggs[0].GetComponent<CircleCollider2D> ().enabled = b;
		else 
			eggs[0].GetComponent<CircleCollider2D> ().enabled = false;
		if(!egg2)
			eggs[1].GetComponent<CircleCollider2D> ().enabled = b;
		else 
			eggs[1].GetComponent<CircleCollider2D> ().enabled = false;
		if(!egg3)
			eggs[2].GetComponent<CircleCollider2D> ().enabled = b;
		else 
			eggs[2].GetComponent<CircleCollider2D> ().enabled = false;
	}

	public void Button_reset(){
		ifnew = true;
		ifsetegg = false;
		PlayerPrefs.DeleteAll ();
	}
	public void Button_Start(){

		if (ifnew == true) {
			bg_start.transform.position= new Vector3(0,-22,0);
			what_env = 1;
			//StartCoroutine (Do_story ());
			StartCoroutine(New_Dostory());
		} 
		else {
			
			StartCoroutine (wait1sec ());
		}
	}
	IEnumerator wait1sec(){
		pa_choice_start.SetActive (false);
		black2.SetActive (true);
		black2.GetComponent<S0_fadeinout> ().set_isin (false);
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Scence2_Main");

	}

	IEnumerator New_Dostory(){
		pa_story.SetActive(true);
		pa_choice_start.SetActive (false);
		bg_story.transform.position = new Vector3 (0, 0, 0);
		black.SetActive (true);
		black.GetComponent<S0_fadeinout> ().set_isin (true);
		yield return new WaitForSeconds (1);
		black.SetActive (false);

	}

	IEnumerator Do_story(){
		//Debug.Log ("story");
		pa_choice_start.SetActive (false);
		bg_story.transform.position = new Vector3 (0, 0, 0);
		black.SetActive (true);
		black.GetComponent<S0_fadeinout> ().set_isin (true);
		yield return new WaitForSeconds (1);
		black.SetActive (false);
		isstory = true;
		word_story.transform.Translate (new Vector3 (0, 10 * Time.deltaTime, 0));
		yield return new WaitForSeconds (25);
		black.GetComponent<S0_fadeinout> ().set_isin (false);
		isstory = false;
		word_story.transform.position = new Vector3 (0, -37, 0);
		bg_story.transform.position = new Vector3 (0, -22, 0);
		bg_env [0].transform.position = new Vector3 (0, 0, 0);
		png_env.transform.position = new Vector3 (0, 0, 0);
		flowchart.SetActive (true);
	}
	public void Button_Setting(){
		pa_setting.SetActive (true);
	}
	public void Button_setting_back(){
		pa_setting.SetActive (false);
	}	
	public void Button_OK(){
		if (what_env == 3) {
			if(what_egg!=0){
				choice_egg += what_egg ;
				PlayerPrefs.SetInt ("choice_egg", choice_egg);
				//PlayerPrefs.SetInt ("ifnew", 1);
				bg_env [2].transform.position = new Vector3 (45, 0, 0);
				pa_env [0].SetActive (false);
				png_env.transform.position = new Vector3 (-15, 0, 0);
				ifsetegg = true;
				//SceneManager.LoadScene ("Scence2_Main");
			}
		}
		else if(what_env==1){
			if (what_egg != 0) {
				
				choice_egg = what_egg * 100;
				bg_env [0].transform.position = new Vector3 (15, 0, 0);
				bg_env [1].transform.position = new Vector3 (0, 0, 0);
				what_env = 2;
				//Three_eggs [what_egg - 1].SetActive (false);
				pa_env [0].SetActive (false);
			}
		}
		else if (what_env == 2) {
			if (what_egg != 0) {
				choice_egg += what_egg * 10;
				bg_env [1].transform.position = new Vector3 (30, 0, 0);
				bg_env [2].transform.position = new Vector3 (0, 0, 0);
				what_env = 3;
				//Three_eggs [what_egg - 1].SetActive (false);
				pa_env [0].SetActive (false);
			}
		}
		if (what_egg == 1) {
			egg1 = true;
			eggs [0].GetComponent<SpriteRenderer> ().color = Color.black ;
		} else if (what_egg == 2) {
			egg2 = true;
			eggs [1].GetComponent<SpriteRenderer> ().color = Color.black ;
		} else if (what_egg == 3) {
			egg3 = true;
			eggs [2].GetComponent<SpriteRenderer> ().color = Color.black ;
		}
		setCollider (true);
		what_egg = 0;

	}
	public void Button_NO(){
		what_egg = 0;
		pa_env [0].SetActive (false);
		pa_env [1].SetActive (false);
		setCollider (true);
	}
	public void Button_next(){
		bg_env [0].SetActive (false);
		png_env.SetActive (false);
		pa_story.SetActive (false);
		black.GetComponent<S0_fadeinout> ().set_isin (false);
		word_story.transform.position = new Vector3 (0, -37, 0);
		bg_story.transform.position = new Vector3 (0, -22, 0);
		bg_env [0].transform.position = new Vector3 (0, 0, 0);
		png_env.transform.position = new Vector3 (0, 0, 0);
		flowchart.SetActive (true);
	}
}
