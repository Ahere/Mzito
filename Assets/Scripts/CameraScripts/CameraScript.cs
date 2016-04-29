using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


    [SerializeField]
	private float speed = 1.0f;
	[SerializeField]
	private float acceleration = 0.2f;

	private float maxSpeed = 2.0f;
	private float smooth = 0.1f;


    [SerializeField]
	private float easySpeed = 1.3f;
	[SerializeField]
	private float mediumSpeed = 1.5f;
	[SerializeField]
	private float hardSpeed = 1.8f;
    [SerializeField]
	public bool moveCamera;

	private int targetWidth = 480;
//	private int targetHeight = 800;
	
	private float pixelToUnits = 100.0f;

	void Awake() {

		ScaleByWidth ();
		
		Vector3 t = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
		
		CloudSpawnerScript.maxX = t.x - 0.5f;
		CloudSpawnerScript.minX = -t.x + 0.5f;
	}

	// Use this for initialization
	void Start () {

		moveCamera = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
	//	MoveCameraByLerp ();

		if (moveCamera) {
			MoveCamera ();	
		}

	}

    /// Difficuulty Setters.
	public void SetEasySpeed() 
	{
		this.maxSpeed = easySpeed;
	}

	public void SetMediumSpeed() 
	{
		this.maxSpeed = mediumSpeed;
	}

	public void SetHardSpeed() 
	{
		this.maxSpeed = hardSpeed;
	}

	//Smoth camera movement.
   
	void MoveCameraByLerp() {

		Vector3 temp = transform.position;

		temp.y = Mathf.Lerp (temp.y, temp.y - (speed * Time.deltaTime), smooth);

		transform.position = temp;
		
		speed += acceleration * Time.deltaTime;
		
		if (speed > maxSpeed)
			speed = maxSpeed;


	}

	void MoveCamera() {

		Vector3 temp = transform.position;

		float oldY = temp.y;

		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y, oldY, newY);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed)
				speed = maxSpeed;

	}

	void ScaleByWidth() {
		
		int height = Mathf.CeilToInt (targetWidth / (float)Screen.width * Screen.height);
		
		GetComponent<Camera>().orthographicSize = height / pixelToUnits / 2;

		if (GetComponent<Camera>().orthographicSize < 3.99)
						GetComponent<Camera>().orthographicSize = 3.99f;

	}

}
