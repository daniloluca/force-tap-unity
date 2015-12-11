using UnityEngine;
using System.Collections;

public class MenuFunctions : MonoBehaviour {
	public GameObject options;

	public void optionsShow(){
		options.gameObject.SetActive(true);
	}

	public void optionsHide(){
		options.gameObject.SetActive(false);
	}
}
