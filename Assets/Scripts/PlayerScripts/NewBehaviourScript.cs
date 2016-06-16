using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// void PlayerWalkMobile() {

	// 	// force by which we will push the player
	// 	float force = 0.0f;
	// 	// the players velocity
	// 	//float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

	// 	if (Input.touchCount > 0) {

				

	// 			Touch h = Input.touches[0];
				
	// 			Vector2 position = Camera.main.ScreenToViewportPoint(new Vector2(h.position.x, h.position.y));
	// 			////Debug.Log(position);
				
	// 			float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

	// 			if(position.x > 0.5) {
					
	// 				// if the velocity of the player is less than the maxVelocity
	// 				if(velocity < maxVelocity){
	// 					//force = speed;
	// 				}
					
	// 				// turn the player to face right
	// 				Vector2 scale = transform.localScale;
	// 				scale.x = animScale;
	// 				transform.localScale = scale;
					
	// 				// animate the walk
	// 				animator.SetInteger("Walk", 1);
					
	// 			} 


	// 			else if(position.x < 0.5) 
	// 			{
					
	// 				// if the velocity of the player is less than the maxVelocity
	// 				if(velocity < maxVelocity)
	// 				{
	// 					//force = -speed;
	// 				}
					
	// 				// turn the player to face right
	// 				Vector2 scale = transform.localScale;
	// 				scale.x = -animScale;
	// 				transform.localScale = scale;
					
	// 				// animate the walk
	// 				animator.SetInteger("Walk", 1);
					
	// 			}
	// 			// add force to rigid body to move the player
	// 			GetComponent<Rigidbody2D>().AddForce(new Vector3(force, 0, 0));
				
	// 			// set the idle animation
	// 			if(h.phase == TouchPhase.Ended) 
	// 				animator.SetInteger("Walk", 0);

			 // if Input.touchCount > 0

	 // player walk mobile new
}
