using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject configButton;
	public GameObject controlPosition;

	public float smooth = 0.5f;
	private Vector2 speed;
	private bool showOptions = false;

	private Vector2 newPosition2DOptionsMenu;
	private Vector3 newOptionsMenuPosition;

	public GameObject soundButton;
	public Sprite soundImage;
	public Sprite soundMuteImage;

	public GameObject musicButton;
	public Sprite musicImage;
	public Sprite musicMuteImage;

	// Use this for initialization
	void Start () {

		speed = new Vector2 (0.5f, 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
		if(showOptions){
			newPosition2DOptionsMenu = Vector2.zero;

			newPosition2DOptionsMenu.x = Mathf.SmoothDamp(optionsMenu.transform.position.x, configButton.transform.position.x, ref speed.x, smooth);

			newOptionsMenuPosition = new Vector3(newPosition2DOptionsMenu.x, optionsMenu.transform.position.y, 0);

			optionsMenu.transform.position = Vector3.Slerp(optionsMenu.transform.position, newOptionsMenuPosition, Time.time);
		}else{
			newPosition2DOptionsMenu = Vector2.zero;

			newPosition2DOptionsMenu.x = Mathf.SmoothDamp(optionsMenu.transform.position.x, controlPosition.transform.position.x, ref speed.x, smooth);

			newOptionsMenuPosition = new Vector3(newPosition2DOptionsMenu.x, optionsMenu.transform.position.y, 0);

			optionsMenu.transform.position = Vector3.Slerp(optionsMenu.transform.position, newOptionsMenuPosition, Time.time);
		}
	}

	public void configOptions(){
		showOptions = !showOptions;
	}

	public void audioControl(){
		GameObject audio;
		audio = GameObject.Find("AudioEffects");
		audio.GetComponent<AudioSource>().mute = !audio.GetComponent<AudioSource>().mute;
		
		Sprite image = soundButton.GetComponent<Image>().sprite;
		if(image == soundImage){
			soundButton.GetComponent<Image>().sprite = soundMuteImage;
		}else{
			soundButton.GetComponent<Image>().sprite = soundImage;
		}
	}

	public void musicControl(){
		GameObject music;
		music = GameObject.Find("Music");
		music.GetComponent<AudioSource>().mute = !music.GetComponent<AudioSource>().mute;
		
		Sprite image = musicButton.GetComponent<Image>().sprite;
		if(image == musicImage){
			musicButton.GetComponent<Image>().sprite = musicMuteImage;
		}else{
			musicButton.GetComponent<Image>().sprite = musicImage;
		}
	}
}
