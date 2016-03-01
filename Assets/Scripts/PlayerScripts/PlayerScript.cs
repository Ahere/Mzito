using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 8.0f;	// the speed by which the player moves
	public float maxVelocity = 3.0f;	// maximum velocity of the player

	private Animator animator;	// players animator for animation controlce to the camera script




	// Use this for initialization
	void Start () {
		//Time.timeScale = 0.0f;
		animator = GetComponent<Animator> ();	// getting the animator reference
		//countTouches = 0;
	
	}



//	void LateUpdate (){

		//Time.timeScale = 1.0f;	
//	}
	
	// Update is called once per frame
	void Update () {
			
			
			PlayerWalkKeyboard ();
			
			PlayerWalkMobile ();

			
			//if(countTouches > 3) {
			//	SetScore ();
			//}

		}

void PlayerWalkMobile() {

		// force by which we will push the player
		float force = 0.0f;
		// the players velocity
		float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

		if (Input.touchCount > 0) {

				//countTouches++;

				Touch h = Input.touches[0];
				
				Vector2 position = Camera.main.ScreenToViewportPoint(new Vector2(h.position.x, h.position.y));
				Debug.Log(position);
				
				
				if(position.x > 0.5) {
					
					// if the velocity of the player is less than the maxVelocity
					if(velocity < maxVelocity){
						force = speed;
					}
					
					// turn the player to face right
					Vector3 scale = transform.localScale;
					scale.x = 1;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);
					
				} else if(position.x < 0.5) {
					
					// if the velocity of the player is less than the maxVelocity
					if(velocity < maxVelocity){
						force = -speed;
					}
					
					// turn the player to face right
					Vector2 scale = transform.localScale;
					scale.x = -1;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);
					
				}
				// add force to rigid body to move the player
				GetComponent<Rigidbody2D>().AddForce(new Vector3(force, 0, 0));
				
				// set the idle animation
				if(h.phase == TouchPhase.Ended) 
					animator.SetInteger("Walk", 0);

			} // if Input.touchCount > 0

	} // player walk mobile

	void PlayerWalkKeyboard() {

		// force by which we will push the player
		float force = 0.0f;
		// the players velocity
		float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		
		// getting the input from the player
		float h = Input.GetAxis ("Horizontal");
		
		// checking if the player is moving right
		if (h > 0) {
			
			// if the velocity of the player is less than the maxVelocity
			if(velocity < maxVelocity)
				force = speed;
			
			// turn the player to face right
			Vector3 scale = transform.localScale;
			scale.x = 0.5f;
			transform.localScale = scale;
			
			// animate the walk
			animator.SetInteger("Walk", 1);
			
			// check if the player is moving left
		}  else if(h < 0) {
			
			// if the velocity of the player is less than the maxVelocity
			if(velocity < maxVelocity)
				force = -speed;
			
			// turn the player to face left
			Vector3 scale = transform.localScale;
			scale.x = -0.5f;
			transform.localScale = scale;
			
			// animate the walk
			animator.SetInteger("Walk", 1);
			
		}
		
		// if the{} player is not moving set the animation to idle
	  if(h == 0){
			animator.SetInteger("Walk", 0);
	  }
		
		// add force to rigid body to move the player
	GetComponent<Rigidbody2D>().AddForce(new Vector2 (force, 0));

	}




}
