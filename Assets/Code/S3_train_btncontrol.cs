using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S3_train_btncontrol : MonoBehaviour {

	public GameObject practice_buttom_think;
	public GameObject practice_buttom_hunt;
	public GameObject practice_buttom_patience;
	public GameObject back;
	public GameObject[] traindialog={};

	public GameObject pnlconfirm;
	public GameObject pnltrainselect;
	public GameObject pnltraindialog;
	public GameObject showtext;

	int monsterlev; //靈獸第幾階段 三隻一起存
	bool show_text; //是否顯示倒數計時
	int nowmonsterlevel;//現在這隻靈獸第幾階段
	int maincharacher;
	float prevtime;//計時開始當下時間
	float totaltime;//總共要計時時間
	float endtime;//計時結束時間
	int trainsel;//選擇了哪一種類的訓練
	// Use this for initialization
	void Start () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher = maincharacher%3;
		ResetAllcomponent ();
		pnltrainselect.SetActive (true);
		show_text = false;
		showtext.SetActive (false);
		checktraintime ();
	}

	void ResetAllcomponent () {
		pnlconfirm.SetActive (false);
		pnltrainselect.SetActive (false);
		pnltraindialog.SetActive (false);
	}




	public void checktraintime () {
		//key是traintime0 1 2
		if (PlayerPrefs.HasKey ("traintime"+maincharacher)) {
			String traintime = PlayerPrefs.GetString ("traintime"+maincharacher);
			String[] traintimearr = traintime.Split (',');//0=時間,1=哪隻怪物,2=訓練種類,3=訓練等級
			int now = (int)(DateTime.UtcNow.Subtract (new DateTime (1970, 1, 1))).TotalSeconds;

			if (now > int.Parse (traintimearr [0])) {
				//train finish
				//PlayerPrefs.DeleteKey ("traintime"+maincharacher);
			} else {
				//train continue
				pnlconfirm.SetActive (false);
				pnltraindialog.SetActive (false);
				show_text = true;
				showtext.SetActive (true);
				practice_buttom_think.GetComponent<Button> ().interactable = false;
				practice_buttom_hunt.GetComponent<Button> ().interactable = false;
				practice_buttom_patience.GetComponent<Button> ().interactable = false;
				Vector3 trainselbtn = new Vector3(1,2);
				if (trainsel==0)
					trainselbtn = practice_buttom_think.transform.position;
				else if (trainsel==1)
					trainselbtn = practice_buttom_hunt.transform.position;
				else if (trainsel==2)
					trainselbtn = practice_buttom_patience.transform.position;
				trainselbtn.Set (trainselbtn.x, trainselbtn.y-260, trainselbtn.z);
				showtext.transform.position = trainselbtn;
				StartCoroutine ("waittime",int.Parse (traintimearr [0]) - now);
			}
		} 
		else {
		
		}
	}

	


	public void clickthink () {
		Debug.Log("clickthink");
		int i = maincharacher + 1;
		string s = PlayerPrefs.GetString ("main" + i);
		string[] temps = s.Split (',');
		int hp = int.Parse (temps [2])+ (int)UnityEngine.Random.Range(30,50);
		int atk = int.Parse (temps [3]);
		int def = int.Parse (temps [4])- (int)UnityEngine.Random.Range(0,3);
		PlayerPrefs.SetString ("main" + i, temps[0] + "," + temps [1] + "," + hp + "," + atk + "," + def + "," + temps[5]);
		monsterlev = PlayerPrefs.GetInt ("monsterlev",111);
		showdialog ((int)monsterlev/100);
		nowmonsterlevel = (int)monsterlev / 100;
		showcfmbtn ();
		trainsel = 0;
	}

	public void clickhunt () {
		Debug.Log("clickhunt");
		int i = maincharacher + 1;
		string s = PlayerPrefs.GetString ("main" + i);
		string[] temps = s.Split (',');
		int hp = int.Parse (temps [2])- (int)UnityEngine.Random.Range(0,6);
		int atk = int.Parse (temps [3])+ (int)UnityEngine.Random.Range(30,50);
		int def = int.Parse (temps [4]);
		PlayerPrefs.SetString ("main" + i, temps[0] + "," + temps [1] + "," + hp + "," + atk + "," + def + "," + temps[5]);
		monsterlev = PlayerPrefs.GetInt ("monsterlev",111);
		showdialog (3+(int)(monsterlev%100)/10);
		nowmonsterlevel = (int)(monsterlev % 100) / 10;
		showcfmbtn ();
		trainsel = 1;
	}

	public void clickpat () {
		Debug.Log("clickpat");
		int i = maincharacher + 1;
		string s = PlayerPrefs.GetString ("main" + i);
		string[] temps = s.Split (',');
		int hp = int.Parse (temps [2]);
		int atk = int.Parse (temps [3])- (int)UnityEngine.Random.Range(0,3);
		int def = int.Parse (temps [4])+ (int)UnityEngine.Random.Range(30,50);
		PlayerPrefs.SetString ("main" + i, temps[0] + "," + temps [1] + "," + hp + "," + atk + "," + def + "," + temps[5]);
		monsterlev = PlayerPrefs.GetInt ("monsterlev",111);
		showdialog (6+monsterlev % 10);
		nowmonsterlevel =  monsterlev % 10;
		showcfmbtn ();
		trainsel = 2;
	}

	public void clickback () {
		Debug.Log("clickback");
		SceneManager.LoadScene ("Scence2_Main");
	}

	public void clickyes () {
		int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		int maincharacher = PlayerPrefs.GetInt("maincharacher");
		maincharacher=maincharacher%3;
		unixTimestamp = unixTimestamp + nowmonsterlevel * 60;//訓練時間
		PlayerPrefs.SetString ("traintime"+maincharacher, unixTimestamp+","+maincharacher+","+trainsel+","+nowmonsterlevel); //剩下多少時間要倒數 時間,幾號怪物,訓練種類,訓練等級
		PlayerPrefs.Save();
		Debug.Log("clickyes");
		Debug.Log(PlayerPrefs.GetString("traintime"+maincharacher));
		pnlconfirm.SetActive (false);
		pnltraindialog.SetActive (false);
		show_text = true;
		showtext.SetActive (true);
		practice_buttom_think.GetComponent<Button> ().interactable = false;
		practice_buttom_hunt.GetComponent<Button> ().interactable = false;
		practice_buttom_patience.GetComponent<Button> ().interactable = false;
		Vector3 trainselbtn = new Vector3(1,2);
		if (trainsel==0)
			trainselbtn = practice_buttom_think.transform.position;
		else if (trainsel==1)
			trainselbtn = practice_buttom_hunt.transform.position;
		else if (trainsel==2)
			trainselbtn = practice_buttom_patience.transform.position;
		trainselbtn.Set (trainselbtn.x, trainselbtn.y-260, trainselbtn.z);
		showtext.transform.position = trainselbtn;
		StartCoroutine ("waittime",nowmonsterlevel*60);//要訓練的時間

		//InvokeRepeating ("waittime", 1, 5);
		//waittime (10);
		//yield return new WaitForSeconds (10);
		//manipulate monster's ability
	}

	public void clickno () {
		Debug.Log("clickback");
		pnlconfirm.SetActive (false);
		pnltraindialog.SetActive (false);
	}


	/*
	public void waittime(int i) {
		print(Time.time);
	}
	*/
	IEnumerator waittime(float i) {
		print (Time.time);
		prevtime = Time.time;
		endtime = Time.time + i;
		totaltime =  i;
		yield return new WaitForSeconds (i);
		print (Time.time);
		practice_buttom_think.GetComponent<Button> ().interactable = true;
		practice_buttom_hunt.GetComponent<Button> ().interactable = true;
		practice_buttom_patience.GetComponent<Button> ().interactable = true;
		showtext.SetActive (false);
	}





	public void showmainbtn () {
		Debug.Log("showmainbtn");
		pnltrainselect.SetActive (true);
	}

	public void hidemainbtn () {
		Debug.Log("hidemainbtn");
		pnltrainselect.SetActive (false);
	}

	public void showcfmbtn () {
		Debug.Log("showcfmbtn");
		pnlconfirm.SetActive (true);
	}

	public void hidecfmbtn () {
		Debug.Log("hidecfmbtn");
		pnlconfirm.SetActive (false);
	}

	public void showdialog (int s) {
		Debug.Log("showdialog");
		pnltraindialog.SetActive (true);
		for (int i=0;i<9;i++) {
			traindialog [i].SetActive (false);
		}
		traindialog [s-1].SetActive (true);
	}


	// Update is called once per frame
	void Update () {
		if (show_text) {
			if (Time.time - prevtime < totaltime) {
				showtext.GetComponent<Text> ().text = (int)endtime - (int)Time.time + "";
			} else {
				PlayerPrefs.DeleteKey ("traintime"+maincharacher);
				//這裡加靈獸數值



			}
		} else {
			
		}
	}
}
