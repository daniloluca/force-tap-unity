using UnityEngine;
using System.Collections;

public class TrailTransparency : MonoBehaviour {

	public float speed = 0.4f;
	private Color color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(this.transform.GetComponent<SpriteRenderer>().color.a <= 0){
			DestroyObject(gameObject);
		}

		color = this.transform.GetComponent<SpriteRenderer>().color;

		color.a-=Time.deltaTime/speed;

		this.transform.GetComponent<SpriteRenderer>().color = color;	

		//scale
			
	}
}
