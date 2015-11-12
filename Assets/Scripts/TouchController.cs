using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GameObject ball;
	public float forceTap = 10f;
	private Vector2 touchPosition;

	void OnMouseDown(){
		ball.GetComponent<Rigidbody2D>().isKinematic = true;

		touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

		ball.GetComponent<Rigidbody2D>().isKinematic = false;

		if(touchPosition.x<0){
			ball.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceTap, ForceMode2D.Force);
		}else if(touchPosition.x>0){
			ball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceTap, ForceMode2D.Force);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
