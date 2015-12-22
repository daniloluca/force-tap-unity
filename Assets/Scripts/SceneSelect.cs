using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Menu(){
        SceneManager.LoadScene("Menu");
    }

	public void Levels(){
        SceneManager.LoadScene("Levels");
    }

	public void Level1(){
        SceneManager.LoadScene("Level 1");
    }

	public void Level2(){
        SceneManager.LoadScene("Level 2");
    }

	public void Level3(){
        SceneManager.LoadScene("Level 3");
    }

    public void Level4() {
        SceneManager.LoadScene("Level 4");
    }

    public void Level5() {
        SceneManager.LoadScene("Level 5");
    }

    public void Level6() {
        SceneManager.LoadScene("Level 6");
    }
}
