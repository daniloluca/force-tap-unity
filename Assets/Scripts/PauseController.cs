using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject pausePanel;

	public void pause(){
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}

	public void unPause(){
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}
}
