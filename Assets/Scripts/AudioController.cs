using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private bool destroy = true;

	void OnLevelWasLoaded(){
		if(destroy){
			DestroyObject(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		destroy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
