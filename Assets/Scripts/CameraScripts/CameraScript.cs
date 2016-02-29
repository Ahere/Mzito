using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float speed = 1.0f;
	public float acceleration = 0.2f;
	public float maxSpeed = 3.2f;
	public float smooth = 0.1f;



	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

	MoveCameraByLerp ();

		

	}



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

	
}

