using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	public GameObject exitInControl;
	public GameObject exitOutControl;

	private Vector2 newPosition2DExit;
	private Vector3 newExitPosition;

	public float smooth = 10f;
	private Vector2 speed;
	private bool showOptions = false;

	void Start(){

		speed = new Vector2 (0.5f, 0.5f);

	}

	void Update () {
		if(showOptions){
			newPosition2DExit = Vector2.zero;
			newPosition2DExit.x = Mathf.SmoothDamp(this.transform.position.x, exitInControl.transform.position.x, ref speed.x, smooth, Mathf.Infinity, 1);
			newExitPosition = new Vector3(newPosition2DExit.x, this.transform.position.y, 0);
			this.transform.position = Vector3.Slerp(this.transform.position, newExitPosition, Time.unscaledTime);
		}else{
			newPosition2DExit = Vector2.zero;
			newPosition2DExit.x = Mathf.SmoothDamp(this.transform.position.x, exitOutControl.transform.position.x, ref speed.x, smooth, Mathf.Infinity, 1);
			newExitPosition = new Vector3(newPosition2DExit.x, this.transform.position.y, 0);
			this.transform.position = Vector3.Slerp(this.transform.position, newExitPosition, Time.unscaledTime);
		}
	}

	public void showExit(){
		showOptions = !showOptions;
	}
}
