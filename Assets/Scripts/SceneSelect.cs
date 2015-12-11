using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Menu(){
		Application.LoadLevel("Menu");
	}

	public void Levels(){
		Application.LoadLevel("Levels");
	}

	public void Level1(){
		Application.LoadLevel("Level 1");
	}

	public void Level2(){
		Application.LoadLevel("Level 2");
	}

	public void Level3(){
		Application.LoadLevel("Level 3");
	}
}
