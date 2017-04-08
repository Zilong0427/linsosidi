using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S0_musicControll : MonoBehaviour {
	private AudioSource audioSource;
	//private bool muteState;
	public Slider vol;
	private float Volume;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		if (!PlayerPrefs.HasKey("issetvol")) {
			audioSource.volume = 1;
			if(vol !=null)
				vol.value = 1;
		} else {
			audioSource.volume = PlayerPrefs.GetFloat ("preVolume");
			if(vol !=null)
				vol.value = PlayerPrefs.GetFloat ("preVolume");
		}
	}
	public void VolumeChanged(float newVolume) {
		audioSource.volume = newVolume;
		//muteState = false;
	}
	// Update is called once per frame
	void Update () {
		if(vol !=null)
			audioSource.volume = vol.value;
	}
	public void button_setting(){
		if (!PlayerPrefs.HasKey("issetvol")) 
			PlayerPrefs.SetFloat ("preVolume", 1);
		vol.value = PlayerPrefs.GetFloat ("preVolume");
		//Debug.Log ("" + PlayerPrefs.GetFloat ("preVolume"));
	}
	public void button_back(){
		//float temp= GameObject.Find ("BGM").GetComponent<S0_musicControll> ().Get_volume ();
		PlayerPrefs.SetFloat ("preVolume", audioSource.volume);
		if (!PlayerPrefs.HasKey("issetvol")) {
			PlayerPrefs.SetInt ("issetvol", 1);
			Debug.Log ("set issetvol");
		} 
		//Debug.Log ("Save volume");
		PlayerPrefs.Save ();
	}
}
