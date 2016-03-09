using UnityEngine;
using System.Collections;

public class PlayerButtonMov : MonoBehaviour {


	public float speed = 2.0f;	// the speed by which the player moves
	public float maxVelocity = 3.0f;	// maximum velocity of the player
	private Animator animator;
	public float animScale = 1.0f;
	

	// Use this for initialization
	public void PlayerWalkMobileLeft() 
	{
		animator = GetComponent<Animator> ();

		// force by which we will push the player
		float force = 0.0f;

		// the players velocity
		float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
					
					 //if the velocity of the player is less than the maxVelocity
					if(velocity < maxVelocity)
					{
						force = speed;
						Debug.Log(velocity);
					}
					
					// turn the player to face right
					Vector3 scale = transform.localScale;
					scale.x = animScale;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);

					GetComponent<Rigidbody2D>().AddForce(new Vector3(force, 0, 0));

								
			      //animator.SetInteger("Walk", 0);
			   


}

         public void PlayerIdleAnimate()
       {

			      animator.SetInteger("Walk", 0);
			  

       }
					
					
	public void PlayerWalkMobileRight() 
	{

		animator = GetComponent<Animator> ();

		float force = 0.0f;


		float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
					
					if(velocity < maxVelocity)
					{
						force = speed;
						Debug.Log("I am walking");
					}
					
					// turn the player to face right
					
					Vector2 scale = transform.localScale;
					scale.x = -animScale;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);
					
				
				// add force to rigid body to move the player
				GetComponent<Rigidbody2D>().AddForce(new Vector3(-force, 0, 0));
				
				// set the idle animation
				
			     // if Input.touchCount > 0

	} // player walk mobile
}