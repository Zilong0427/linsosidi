using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class S2_test_showegg : MonoBehaviour {
	public Text text1;
	public Text text2;
	public Text text3;
	int i,j,k;
	// Use this for initialization
	void Start () {
		 i = PlayerPrefs.GetInt ("env1_egg");
		 j = PlayerPrefs.GetInt ("env2_egg");
		 k = PlayerPrefs.GetInt ("env3_egg");

	}
	
	// Update is called once per frame
	void Update () {
		text1.text = ("" + i);
		text2.text = ("" + j);
		text3.text = ("" + k);

	}
}
