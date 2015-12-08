using UnityEngine;
using System.Collections;

public class MotionBlur : MonoBehaviour {

	public GameObject trail;
	public float speed = 0.05f;

	// Use this for initialization
	void Start () {
		StartCoroutine("deadDelay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator deadDelay(){

		trail.GetComponent<SpriteRenderer>().sprite = this.transform.GetComponent<SpriteRenderer>().sprite;
		trail.GetComponent<SpriteRenderer>().color = this.transform.GetComponent<SpriteRenderer>().color;
		trail.GetComponent<SpriteRenderer>().material = this.transform.GetComponent<SpriteRenderer>().material;
		trail.GetComponent<SpriteRenderer>().enabled = this.transform.GetComponent<SpriteRenderer>().enabled;
		
		Instantiate(trail, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+1), Quaternion.identity);

		yield return new WaitForSeconds(speed);
		StartCoroutine("deadDelay");
	}
}