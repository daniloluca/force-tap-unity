using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject modal;

	public void pause(){
		modal.SetActive(true);
	}

	public void unPause(){
		modal.SetActive(false);
	}
}
