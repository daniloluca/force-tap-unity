using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GameObject ball;
	public float forceTap = 100f;
	private Vector2 touchPosition;
    private GameObject ballChild;

	void OnMouseDown(){
		
		touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

		if(touchPosition.y<ballChild.transform.position.y){
			ball.GetComponent<Rigidbody2D>().isKinematic = true;
			ball.GetComponent<Rigidbody2D>().isKinematic = false;
			if(touchPosition.x<0){
				ball.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceTap, ForceMode2D.Force);
			}else if(touchPosition.x>0){
				ball.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceTap, ForceMode2D.Force);
			}
		}
	}

	// Use this for initialization
	void Start () {

        ballChild = ball.transform.GetChild(0).gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
