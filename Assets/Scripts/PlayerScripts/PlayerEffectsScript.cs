using UnityEngine;
using System.Collections;

public class PlayerEffectsScript : MonoBehaviour {

	public  Animator animator;

	// Use this for initialization
	void Start () 
	{

     animator = GetComponent<Animator>();	// getting the animator reference

	
	}
	
	// Update is called once per frame
	

	void OnTriggerEnter2D(Collider2D target)
	{


	 if (target.tag == "Coins") 
	    {  
	      
	      Debug.Log("Coins");
          StartCoroutine(CoinPickUpAnimation()); 
	   	  
			
		}
       
     if (target.tag == "Life") 
       {  

        Debug.Log("Life");  
       	StartCoroutine(HealthPickUPAnimation()); 
			
			
			
	  }
	
  }
   IEnumerator HealthPickUPAnimation() 
    
    {

    	animator.SetBool("Heal", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Heal", false);


    }


     IEnumerator CoinPickUpAnimation() 
    
    {


    	animator.SetBool("Coin", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Coin", false);
		
    	

    }
}
