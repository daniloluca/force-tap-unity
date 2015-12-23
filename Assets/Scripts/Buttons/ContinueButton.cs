using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	public GameObject continueInControl;
	public GameObject continueOutControl;

	private Vector2 newPosition2DContinue;
	private Vector3 newContinuePosition;

	public float smooth = 10f;
	private Vector2 speed;
	private bool showOptions = false;

	void Start(){

		speed = new Vector2 (0.5f, 0.5f);

	}

	void Update () {
		if(showOptions){
			newPosition2DContinue = Vector2.zero;
			newPosition2DContinue.x = Mathf.SmoothDamp(this.transform.position.x, continueInControl.transform.position.x, ref speed.x, smooth, Mathf.Infinity, 1);
			newContinuePosition = new Vector3(newPosition2DContinue.x, this.transform.position.y, 0);
			this.transform.position = Vector3.Slerp(this.transform.position, newContinuePosition, Time.unscaledTime);
		}else{
			newPosition2DContinue = Vector2.zero;
			newPosition2DContinue.x = Mathf.SmoothDamp(this.transform.position.x, continueOutControl.transform.position.x, ref speed.x, smooth, Mathf.Infinity, 1);
			newContinuePosition = new Vector3(newPosition2DContinue.x, this.transform.position.y, 0);
			this.transform.position = Vector3.Slerp(this.transform.position, newContinuePosition, Time.unscaledTime);
		}
	}

	public void showContinue(){
		showOptions = !showOptions;
	}
}
