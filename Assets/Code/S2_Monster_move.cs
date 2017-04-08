using UnityEngine;
using System.Collections;

public class S2_Monster_move : MonoBehaviour {
	public float dotime, stoptime;
	public float vx, vy;
	public bool canmove = true;
	// Use this for initialization
	void Start () {
		change ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 3 || transform.position.x < -3)
			vx = -vx;
		if (transform.position.y > 3 || transform.position.y < -3)
			vy = -vy;
		transform.Translate (vx * Time.deltaTime, vy * Time.deltaTime, 0);
		if (canmove) {
			StartCoroutine (wait (dotime, stoptime));
		}
		if (vx > 0)
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = true;
		else
			this.gameObject.GetComponent<SpriteRenderer> ().flipX = false;

	}
	void change(){
		vx = (float)Random.Range (-1, 2);
		vy = (float)Random.Range (-1, 2);
		dotime = Random.Range (0, 4);
		stoptime = Random.Range (0, 3);
		canmove = true;
	}
	IEnumerator wait(float d,float s){
		//Debug.Log ("wait " + d);
		canmove = false;
		yield return new WaitForSeconds (d);

		vx = 0;
		vy = 0;
		yield return new WaitForSeconds (s);
		change ();
	}
}
