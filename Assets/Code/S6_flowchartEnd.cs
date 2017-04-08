using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6_flowchartEnd : MonoBehaviour {
	public S6_Battle m_s6_battle;
	void OnEnable(){
		m_s6_battle.onInitial ();
	}
}
