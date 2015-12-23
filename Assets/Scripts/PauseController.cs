using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject modal;

	public void pause(){
		modal.SetActive(true);
        Time.timeScale = 0;
	}

	public void unPause(){
		modal.SetActive(false);
        Time.timeScale = 1;
    }
}
