using UnityEngine;
using System.Collections;

public class TutorialCameraScript : MonoBehaviour {



	private int targetWidth = 480;
//	private int targetHeight = 800;
	
	private float pixelToUnits = 100.0f;

	void Awake() {

		ScaleByWidth ();
		
		
	}

	// Use this for initialization
	void Start () 
	{

		
	}
	
	// Update is called once per frame


	void ScaleByWidth() {
		
		int height = Mathf.CeilToInt (targetWidth / (float)Screen.width * Screen.height);
		
		GetComponent<Camera>().orthographicSize = height / pixelToUnits / 2;

		if (GetComponent<Camera>().orthographicSize < 3.70)
						GetComponent<Camera>().orthographicSize = 3.70f;

	}

}
