using UnityEngine;
using System.Collections;

public class MenuBallController : MonoBehaviour {

	public float force = 100f;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, force), ForceMode2D.Force);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
