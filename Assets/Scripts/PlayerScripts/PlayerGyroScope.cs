﻿using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
public class PlayerGyroScope : MonoBehaviour {
    public GameObject player; // First Person Controller parent node
  //  public GameObject head; // First Person Controller camera

    // The initials orientation
   // private float initialOrientationX;
   [SerializeField]
    private Animator animator;
    [SerializeField]
	private float animScale = 1.0f ;	// scale for animator
   // private int initialOrientationY;
   // private int initialOrientationZ;

    // Use this for initialization
    void Awake () 
    {
    	animator = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update ()
    { 
       
       
        float speed = Input.acceleration.x * 0.1f;

        if (speed > 0)
        {
        
        // Debug.Log("rightspeed"+ speed )
        Vector2 scale = transform.localScale;
	    scale.x = animScale;
		player.transform.localScale = scale;
					
		// animate the walk
		animator.SetInteger("Walk", 1);
		player.transform.Translate (speed, 0 , 0);

        }


         if (speed < 0)
        {
       
       
        //Debug.Log("leftspeed"+ speed);
        Vector2 scale = transform.localScale;
					scale.x = -animScale;
		player.transform.localScale = scale;
					
					// animate the walk
		 animator.SetInteger("Walk", 1);
		 player.transform.Translate (speed, 0 , 0);

        }
     
       //head.transform.Rotate (initialOrientationX -Input.gyro.rotationRateUnbiased.x, 0, initialOrientationZ + Input.gyro.rotationRateUnbiased.z);
    }
}

//-Input.gyro.rotationRateUnbiased.x