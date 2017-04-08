using UnityEngine;
using System.Collections;

public class S0_fadeinout : MonoBehaviour {
	public float fadeSpeed = 1f;  
	public float alpha = 1.0f;  
	private float fadeDir = -1;
	public bool isin=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fade ();
	}
	public void fade(){
		if (isin == true)
			fadeDir = -1;
		else if (isin == false)
			fadeDir = 1;
		alpha += fadeDir * fadeSpeed * Time.deltaTime;  
		alpha = Mathf.Clamp01 (alpha);  
		//Debug.Log ("" + alpha);
		//this.GetComponent<SpriteRenderer> ().color.a = alpha;
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alpha);

	}
	public void set_isin(bool isis){
		isin = isis;
	}
	public void reset(){
		alpha = 1;
		isin = true;
	}

}
