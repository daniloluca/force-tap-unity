using UnityEngine;
using System.Collections;

public class TrailTransparency : MonoBehaviour {

	public float speed = 1f;
	private Color color;

	// Use this for initialization
	void Start () {
		StartCoroutine("deadDelay");
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.GetComponent<SpriteRenderer>().color.a <= 0){
			DestroyObject(gameObject);
		}

		color = transform.GetComponent<SpriteRenderer>().color;

		color.a-=Time.deltaTime/speed;

		transform.GetComponent<SpriteRenderer>().color = color;
			
	}

	IEnumerator deadDelay(){

		

		yield return new WaitForSeconds(speed);
		StartCoroutine("deadDelay");
	}
}
