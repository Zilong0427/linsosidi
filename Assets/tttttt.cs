using UnityEngine;
using System.Collections;

public class tttttt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (change ());
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprite/monster/monster"+i.ToString());
		//Debug.Log (Resources.Load<Sprite>("Sprite/monster/monster"+i.ToString()));

	}
	IEnumerator change(){
		for (int i = 1; i < 40; ++i) {
			yield return new WaitForSeconds (1);
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprite/monster/monster" + i.ToString ());
			Debug.Log ("now is " + i);
		}

	}
}
