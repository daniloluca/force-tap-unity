using UnityEngine;
using System.Collections;

public class MenuBallController : MonoBehaviour {

	public float force = 100f;
	private int colorIndex = 0;
	private Vector4[] colorList = new Vector4[3];

	// Use this for initialization
	void Start () {
		colorList[0] = new Vector4(0, 0, 1, 1);
		colorList[1] = new Vector4(1, 0, 0, 1);
		colorList[2] = new Vector4(0, 1, 0, 1);
		this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];

		this.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, force), ForceMode2D.Force);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void changeColor(){
		if(colorIndex<colorList.Length-1){
			colorIndex++;
		}else{
			colorIndex = 0;
		}
		this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];
	}
}