using UnityEngine;
using System.Collections;

public class DealdyMovementScript : MonoBehaviour {


 
    private Vector3 boundaries;
	private bool SpinRight;
	private bool SpinLeft;

	// Use this for initialization
	void Awake () 
	{
	   boundaries = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0));
	   SpinRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckBounds();

		if (SpinRight == true)
		{

			transform.Translate(Vector3.right * Time.deltaTime);

		}


		if (SpinLeft == true)
		{
           transform.Translate(Vector3.left * Time.deltaTime);

		}
	
	}



	void CheckBounds() {

		// check if the players x is greather than the x of the boundaries, if its true set the players x to be boundaries x
		if (transform.position.x > boundaries.x)
	    {
			SpinLeft = true;
			SpinRight = false;
		}

		// check if the players x is less than the x of the boundaries, if its true set the players x to be negative boundaries x
		if (transform.position.x < (-boundaries.x)) 
		{
			
           SpinRight = true;
           SpinLeft = false;

		}

	}
}
