using UnityEngine;
using System.Collections;

public class MotionBlur : MonoBehaviour {

	public GameObject trail;
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		StartCoroutine("deadDelay");
	}
	
	// Update is called once per frame
	void Update () {

			
	}

	IEnumerator deadDelay(){

		trail.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteRenderer>().sprite;
		trail.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
		trail.GetComponent<SpriteRenderer>().material = transform.GetComponent<SpriteRenderer>().material;
		trail.GetComponent<SpriteRenderer>().enabled = transform.GetComponent<SpriteRenderer>().enabled;
		
		Instantiate(trail, new Vector3(transform.position.x, transform.position.y, transform.position.z+1), Quaternion.identity);

		yield return new WaitForSeconds(speed);
		StartCoroutine("deadDelay");
	}
}