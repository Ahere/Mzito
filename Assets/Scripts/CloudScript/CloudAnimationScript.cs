using UnityEngine;
using System.Collections;

public class CloudAnimationScript : MonoBehaviour 
{
   public Animator effects;

	

	void OnTriggerEnter2D(Collider2D target)

	{
		if (target.tag =="Player") 

    {	

		effects.SetBool("Vibrate", true);	
		Debug.Log("animate");
	}


	}



	void OnTriggerExit2D(Collider2D target)

	{
		if (target.tag =="Player") 

    {	

		effects.SetBool("Vibrate", false);
		Debug.Log("Deanimate");
	}


	}



}
