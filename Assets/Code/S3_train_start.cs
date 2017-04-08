using UnityEngine;
using System.Collections;

public class S3_train_start : MonoBehaviour {

	public GameObject[] bg;
	public GameObject[] bgbanner;//訓練的title


	int maincharacher ;
	// Use this for initialization
	void Start () {
		maincharacher = PlayerPrefs.GetInt("maincharacher");
		Debug.Log (maincharacher+"");
		bg[maincharacher%3].transform.position = new Vector3 (0, 0, 0);
		bgbanner[maincharacher%3].transform.position = new Vector3 (0, 8.2f, 0);
	}
	
	void ResetAllcomponent () {
		for (int i = 0; i < bg.Length; i++) {
			bg[maincharacher%3].transform.position = new Vector3 (15+i*15, 0, 0);
			bgbanner[maincharacher%3].transform.position = new Vector3 (15+i*15, 8.2f, 0);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		
		
		
	}
}
