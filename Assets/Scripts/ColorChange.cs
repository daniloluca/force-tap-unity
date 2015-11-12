using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void white(){
		ball.GetComponent<SpriteRenderer>().color = new Vector4(1, 1, 1, 1);
	}

	public void red(){
		ball.GetComponent<SpriteRenderer>().color = new Vector4(1, 0, 0, 1);
	}

	public void blue(){
		ball.GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 1, 1);
	}

	public void green(){
		ball.GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1);
	}
}
