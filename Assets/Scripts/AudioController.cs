using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	void Start () {
        GameObject music = GameObject.Find("Music");
        GameObject audio = GameObject.Find("AudioEffects");
        if (music == this.gameObject || audio == this.gameObject) {
            DontDestroyOnLoad(this.gameObject);
        } else {
            DestroyObject(this.gameObject);
        }
	}
	
	void Update () {
        
	}
}
