using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public bool rotate;
	public bool right;
	public bool left;
	public bool horizontalMove;
	public float moveSpeed = 50f;
	public float rotationSpeed = 50f;

	void OnCollisionEnter2D(Collision2D collider){
		moveSpeed *= -1;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(rotate){
			if(right){
				transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
			}else if(left){
				transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
			}
		}

		if(horizontalMove){
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		}
	}
}
