using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class S4_clickLevel : MonoBehaviour {
	public bool isclick=false;
	public int levelnum;
	S4_clickLevel temp;
	public int now_level;
	// Use this for initialization
	void Start () {
		now_level = PlayerPrefs.GetInt ("now_level") + 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		if (isclick == false) {
			for (int i = 1; i <= now_level; ++i) {
				temp = GameObject.Find ("map_dot (" + i + ")").GetComponent<S4_clickLevel> ();
				temp.Set_isclick ();
			}
			isclick = true;
			GameObject tempobj =GameObject.Find("click_here");
			tempobj.transform.position=transform.position;
		}
		else if(isclick == true){
			PlayerPrefs.SetInt ("battle_level", levelnum);
			Debug.Log(""+levelnum);
			SceneManager.LoadScene ("Scence6_Battle");
		}
	}
	public void Set_isclick(){
		isclick = false;
	}
}
