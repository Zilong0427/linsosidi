using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S6_Battle_btncontrol : MonoBehaviour {
	public GameObject Battle;
	public GameObject give_up;
	public GameObject give_up_yes;
	public GameObject give_up_no;
	public GameObject FiveChoice;
	public GameObject[] five_choice;
	public GameObject ScenceManagement;

	private int editHp;
	private int editAtk;
	private int editDef;

	S6_Battle atk_code;
	private int battle_level;
	GameObject[] flowchart;
	// Use this for initialization
	void Start () {
		battle_level = PlayerPrefs.GetInt("battle_level");
		atk_code = Battle.GetComponent<S6_Battle>();
		flowchart = atk_code.flowchart;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void clickback () {
		showgiveup ();
		atk_code.bg_for_v_d.SetActive (true);
	}

	public void clickYes () {
		SceneManager.LoadScene ("Scence4_Advan");
	}

	public void clickNo () {
		give_up.SetActive (false);
		atk_code.bg_for_v_d.SetActive (false);
	}

	public void showgiveup () {
		give_up.SetActive (true);
	}



	public void BT1Choose(){
		for (int i = 0; i < 3; i++) {
			editAbility (0, i);
		}
		atk_code.editNowLevel ();
		offFiveChoice ();
		openFlowchart ();
		atk_code.offInitial ();
		FiveChoice.SetActive (false);
		//ScenceManagement.SetActive (true);
	}

	public void BT2Choose(){
		for (int i = 0; i < 3; i++) {
			editAbility (1, i);
		}
		atk_code.editNowLevel ();
		offFiveChoice ();
		openFlowchart ();
		atk_code.offInitial ();
		FiveChoice.SetActive (false);
		//ScenceManagement.SetActive (true);
	}

	public void BT3Choose(){
		for (int i = 0; i < 3; i++) {
			editAbility (2, i);
		}
		atk_code.editNowLevel ();
		offFiveChoice ();
		openFlowchart ();
		atk_code.offInitial ();
		FiveChoice.SetActive (false);
		//ScenceManagement.SetActive (true);
	}

	public void BT4Choose(){
		for (int i = 0; i < 3; i++) {
			editAbility (3, i);
		}
		atk_code.editNowLevel ();
		offFiveChoice ();
		openFlowchart ();
		atk_code.offInitial ();
		FiveChoice.SetActive (false);
		//ScenceManagement.SetActive (true);
	}

	public void BT5Choose(){
		for (int i = 0; i < 3; i++) {
			editAbility (4, i);
		}
		atk_code.editNowLevel ();
		offFiveChoice ();
		openFlowchart ();
		atk_code.offInitial ();
		FiveChoice.SetActive (false);
		//ScenceManagement.SetActive (true);
	}
	public void BT_BackMainScene(){
		ScenceManagement.SetActive (true);
	}

	private void editAbility(int num_choices,int i){
		S6_FiveChoices fivechoicecode = FiveChoice.GetComponent<S6_FiveChoices> ().Q_A [atk_code.battle_level-1].GetComponent<S6_FiveChoices> ();

		editHp = fivechoicecode.EditHp [num_choices];
		editAtk = fivechoicecode.EditAtk [num_choices];
		editDef = fivechoicecode.EditDef [num_choices];

		atk_code.monster [i].GetComponent<S6_Monster_Data> ().editHp (editHp);
		atk_code.monster [i].GetComponent<S6_Monster_Data> ().editAtk (editAtk);
		atk_code.monster [i].GetComponent<S6_Monster_Data> ().editDef (editDef);
	}

	private void offFiveChoice(){
		for(int i=0;i<5;i++){
			five_choice [i].GetComponent<Button> ().enabled = false;
		}
	}
	void openFlowchart(){
		flowchart [battle_level - 1].SetActive (true);
	}

}
