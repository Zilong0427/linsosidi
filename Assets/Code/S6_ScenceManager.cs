using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S6_ScenceManager : MonoBehaviour {

	public GameObject battlecode;

	void OnEnable(){
		if (battlecode.GetComponent<S6_Battle>().loadscence2) {
			SceneManager.LoadScene ("Scence2_Main");
		} else {
			SceneManager.LoadScene ("Scence2_Main");
		}
	}
}
