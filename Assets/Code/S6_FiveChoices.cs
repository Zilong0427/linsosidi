using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S6_FiveChoices : MonoBehaviour {
	public GameObject battle;
	public GameObject Btncontrol;
	private int battle_level;

	public GameObject Question;
	public GameObject[] Answer;
	//public GameObject Result;

	public GameObject[] Q_A;

	public string question;

	public string[] answer;
	public string[] result;

	public int[] EditHp;
	public int[] EditAtk;
	public int[] EditDef;

	void OnEnable(){
		battle_level=battle.GetComponent<S6_Battle>().battle_level-1;
		setQuestion ();
		setAnswers ();
	}

	private void setQuestion(){
		Question.GetComponent<Text> ().text = (string)Q_A [battle_level].GetComponent<S6_FiveChoices> ().question;
	}

	private void setAnswers(){
			for (int i = 0; i < 5; i++) {
				Answer [i].GetComponent<Text> ().text = Q_A [battle_level].GetComponent<S6_FiveChoices> ().answer [i];

				//Result.GetComponent<Text> ().text = Q_A [battle_level].GetComponent<S6_ThreeChoices> ().result [q [i]];
			}
	}
}
