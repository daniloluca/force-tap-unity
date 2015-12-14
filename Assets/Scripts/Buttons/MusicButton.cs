using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour {

	public Sprite musicImage;
	public Sprite musicMuteImage;

	// Use this for initialization
	void Start () {
		if(GameObject.Find("Music").GetComponent<AudioSource>().mute){
			this.GetComponent<Image>().sprite = musicMuteImage;
		}else{
			this.GetComponent<Image>().sprite = musicImage;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
