using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


[System.Serializable]
public class Mainchar {
	public string name;
	public int hp;
	public int atk;
	public int def;
}

public class S2_btncontrol : MonoBehaviour {
	public GameObject btn_book;
	public GameObject btn_battle;
	public GameObject btn_practice;
	public GameObject btn_setting;
	public GameObject btn_left;
	public GameObject btn_right;
	public GameObject pnlbutton;
	public GameObject mainmonster;
	public GameObject pa_setting;
	public S2_bgcontrol bgchg;

	public GameObject train_img;
	public GameObject nametext;
	public GameObject hptext;
	public GameObject atktext;
	public GameObject deftext;

	public GameObject traintimetext;

	int maincharacher ;
	bool show_time_text;
	float prevtime;//計時開始當下時間
	float totaltime;//總共要計時時間
	float endtime;//計時結束時間
	public string[] monname = {"","吱吱","冰山巨喙鳥,","晶角翅鵬","嘰嘰","極霜隼","神羽冰鳳","嘟嘟","恐鳥","遠古凶喙","啾啾","班冠炎雀","爆炎神鳥",
		"沼澤龍蜥","地龍","沼地龍王","嘎吱","赤鬃藍龍","蒼藍羽龍","冰紋","霜紋","極地恐獸","寒蛇","化蛇天足","冰魄龍神",
		"努爾鼠","坎格魯","魔尾坎格魯","小狐狸","迷蹤狼","森林看守者","邦邦","魔吼獸","野格戰象","新月鹿","半月鹿","月角神鹿",
		"霜火之心","盤木之鏡","蕨熔果"};
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("ifnew") == 1)
			startsetting ();
	}

	public void checktraintime () {
		int k=maincharacher%3;
		if (PlayerPrefs.HasKey ("traintime"+k)) {
			String traintime = PlayerPrefs.GetString ("traintime"+k);
			String[] traintimearr = traintime.Split (',');//0=時間,1=哪隻怪物,2=訓練種類,3=訓練等級
			int now = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;

			if (now > int.Parse (traintimearr [0])) {
				//train finish
				show_time_text = false;
				traintimetext.SetActive (false);
				train_img.SetActive (false);
				//這裡加靈獸數值
				PlayerPrefs.DeleteKey ("traintime"+k);

			} else {
				//train continue
				StartCoroutine ("waittime",int.Parse (traintimearr [0]) - now);
				show_time_text = true;
				traintimetext.SetActive (true);
				train_img.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprite/train/"+traintimearr[2]);
				Debug.Log (traintimearr [2]);

			}
		} 
		else {
			show_time_text = false;
			traintimetext.SetActive (false);
			train_img.SetActive (false);
		}
	}
	public void startsetting(){
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		PlayerPrefs.SetInt ("maincharacher", maincharacher);
		PlayerPrefs.Save();
		string abilitystring = PlayerPrefs.GetString("main"+(maincharacher%3+1));
		string[] ability = abilitystring.Split (',');
		showmonster (int.Parse(ability[0]));
		bgchg.changebg (int.Parse(ability[1])-1);
		nametext.GetComponent<Text> ().text = monname[int.Parse(ability[0])];
		hptext.GetComponent<Text> ().text = ability[2];
		atktext.GetComponent<Text> ().text = ability[3];
		deftext.GetComponent<Text> ().text = ability[4];

		checktraintime ();
	}
		

	IEnumerator waittime(float i) {
		print (Time.time);
		prevtime = Time.time;
		endtime = Time.time + i;
		totaltime =  i;
		yield return new WaitForSeconds (i);
		print (Time.time);
	}

	public void ClickBook () {
		SceneManager.LoadScene ("Scence5_Dex");
	}

	public void ClickBattle () {
		SceneManager.LoadScene ("Scence4_Advan");
	}

	public void ClickPractice () {
		SceneManager.LoadScene ("Scence3_Train");
	}

	public void ClickSetting () {
		pa_setting.SetActive (true);
	}
		
	public void Button_setting_back(){
		pa_setting.SetActive (false);
	}	
	/*
	public void ClickLeft () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher = maincharacher - 1;
		PlayerPrefs.SetInt ("maincharacher", maincharacher);
		PlayerPrefs.Save();
		bgchg.changebg (maincharacher%3);
	}

	public void ClickRight () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher = maincharacher + 1;
		PlayerPrefs.SetInt ("maincharacher", maincharacher);
		PlayerPrefs.Save();
		bgchg.changebg (maincharacher%3);
	}
	*/


	public void ClickLeft () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher = maincharacher +2;
		PlayerPrefs.SetInt ("maincharacher", maincharacher);
		PlayerPrefs.Save();
		Debug.Log (maincharacher + "");
		string abilitystring = PlayerPrefs.GetString("main"+(maincharacher%3+1));
		string[] ability = abilitystring.Split (',');
		showmonster (int.Parse(ability[0]));
		bgchg.changebg (int.Parse(ability[1])-1);
		nametext.GetComponent<Text> ().text = monname[int.Parse(ability[0])];
		hptext.GetComponent<Text> ().text = ability[2];
		atktext.GetComponent<Text> ().text = ability[3];
		deftext.GetComponent<Text> ().text = ability[4];
		checktraintime ();
	}

	public void ClickRight () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher = maincharacher + 1;
		PlayerPrefs.SetInt ("maincharacher", maincharacher);
		PlayerPrefs.Save();
		Debug.Log (maincharacher + "");
		string abilitystring = PlayerPrefs.GetString("main"+(maincharacher%3+1));
		string[] ability = abilitystring.Split (',');
		showmonster (int.Parse(ability[0]));
		bgchg.changebg (int.Parse(ability[1])-1);
		nametext.GetComponent<Text> ().text = monname[int.Parse(ability[0])];
		hptext.GetComponent<Text> ().text = ability[2];
		atktext.GetComponent<Text> ().text = ability[3];
		deftext.GetComponent<Text> ().text = ability[4];
		checktraintime ();
	}


	/*
	public void showmonstertext(int i) {
		string jsonstr = Resources.Load<TextAsset> ("Json/monster/dex" + i.ToString ()).text;
		Debug.Log (jsonstr);
		Mainchar mainchar = JsonUtility.FromJson<Mainchar> (jsonstr);
		nametext.GetComponent<Text> ().text = mainchar.name;
		hptext.GetComponent<Text> ().text = mainchar.hp+"";
		atktext.GetComponent<Text> ().text = mainchar.atk+"";
		deftext.GetComponent<Text> ().text = mainchar.def+"";

	}
	*/

	public void showmonster(int i) {

		mainmonster.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprite/monster/monster"+i.ToString());
		//Debug.Log (Resources.Load<Sprite>("Sprite/monster/monster"+i.ToString()));
		//mainmonster.GetComponent<Image> ().SetNativeSize ();
	}


	
	// Update is called once per frame
	void Update () {
		if (show_time_text) {
			if (Time.time - prevtime < totaltime) {
				int t = (int)endtime - (int)Time.time;
				int sec = t % 60;
				int min = t / 60;
				traintimetext.GetComponent<Text> ().text = "" + min + " : " + sec;
				//traintimetext.GetComponent<Text> ().text = (int)endtime - (int)Time.time + "";
			} else {
				show_time_text = false;
				traintimetext.SetActive (false);
				train_img.SetActive (false);
				//這裡加靈獸數值
				int k=maincharacher%3;
				PlayerPrefs.DeleteKey ("traintime"+k);
			}
		} else {
			
		}
	}
}
