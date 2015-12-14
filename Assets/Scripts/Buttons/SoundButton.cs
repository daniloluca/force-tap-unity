using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

	public Sprite soundImage;
	public Sprite soundMuteImage;

	// Use this for initialization
	void Start () {
		if(GameObject.Find("AudioEffects").GetComponent<AudioSource>().mute){
			this.GetComponent<Image>().sprite = soundMuteImage;
		}else{
			this.GetComponent<Image>().sprite = soundImage;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
