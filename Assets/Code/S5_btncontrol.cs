using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class S5_btncontrol : MonoBehaviour {
	public GameObject btnfireice;
	public GameObject btngrassice;
	public GameObject btnfiregrass;
	public GameObject back;
	public GameObject[] dexdetailbg;

	public GameObject pnlegg_back;
	public GameObject pnlline;
	public GameObject pnldexdetail;
	public GameObject pnldexdetailbg;
	public GameObject pnldexdetailbtn;
	public GameObject mainmonster;

	public GameObject dexdetail;
	public GameObject[] dexdetailbtn;

	int monsterdex;
	int nowpos;
	// Use this for initialization
	void Start () {
		resetdexbg();
		resetdexdetail ();
		resetdexdetailbtn ();
		nowpos = 0;//check back button's function ,0 = three egg ,1 = button ,2 = detail
		//PlayerPrefs.SetInt ("dexnumber"+5,10);
		//PlayerPrefs.Save ();
		//showwhichdexbtn ();
	}

	public void clickfireice() { //bird
		resetdexbg();
		dexdetailbg [0].SetActive (true);
		showwhichdexbtn (0);
		dexdetailbtn [36].SetActive (true);
		todexbtn ();
		nowpos = 1;
	}

	public void clickgrassice() { // reptile
		resetdexbg();
		dexdetailbg [1].SetActive (true);
		showwhichdexbtn (1);
		dexdetailbtn [37].SetActive (true);
		todexbtn ();
		nowpos = 1;
	}

	public void clickfiregrass() { //mammals
		resetdexbg();
		dexdetailbg [2].SetActive (true);
		showwhichdexbtn (2);
		dexdetailbtn [38].SetActive (true);
		todexbtn ();
		nowpos = 1;
	}



	public void clickback() {
		if (nowpos == 0) {
			SceneManager.LoadScene ("Scence2_Main");
		}
		else if (nowpos == 1) {
			pnldexdetailbg.SetActive (false);
			pnldexdetailbtn.SetActive (false);
			pnlegg_back.SetActive (true);
			pnlline.SetActive (true);
			nowpos = 0;
		}
		else if (nowpos == 2) {
			resetdexdetail ();
			nowpos = 1;
		}
	}
		
	public void todexbtn() {
		pnlegg_back.SetActive (false);
		pnlline.SetActive (false);
		pnldexdetail.SetActive (true);
		pnldexdetailbg.SetActive (true);
	}

	public void resetdexbg () {
		for (int i = 0; i < dexdetailbg.Length; i++)
			dexdetailbg [i].SetActive (false);
		pnldexdetailbg.SetActive (false);
	}












	public void clickdexdetail() {
		resetdexdetail ();
		pnldexdetail.SetActive (true);
		int dexnumber = int.Parse(EventSystem.current.currentSelectedGameObject.name.Substring(6));
		Debug.Log (dexnumber + "");
		dexdetail.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprite/dex/dex"+dexnumber.ToString());
		Debug.Log (Resources.Load<Sprite>("Sprite/dex/dex"+dexnumber.ToString()));
		dexdetail.SetActive (true);
		nowpos = 2;
	}


	public void resetdexdetail() {
		dexdetail.SetActive (false);
		pnldexdetail.SetActive (false);
	}

	public void resetdexdetailbtn() {
		for (int i = 0; i < dexdetailbtn.Length; i++)
			dexdetailbtn [i].SetActive (false);
		pnldexdetailbtn.SetActive (false);
	}

	public void showwhichdexbtn(int c) {
		resetdexdetailbtn ();
		pnldexdetailbtn.SetActive (true);
		for (int i = 0+c*12; i < dexdetailbtn.Length-(2-c)*12; i++) {
			int iadd1 = i + 1;
			int isbtnshow = PlayerPrefs.GetInt ("dexnumber"+iadd1);
			if (isbtnshow!=0)
				dexdetailbtn [i].SetActive (true);
		}
	}













	public void clickbacktodexbtn() {
		resetdexdetail ();

		//resetdexdetailbtn ();
	}






	
	// Update is called once per frame
	void Update () {
		
	}
}
