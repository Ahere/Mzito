﻿using UnityEngine;
using System.Collections;


public class SpinDeadlyScript : MonoBehaviour 
{



	public static float spinSpeed = 10 ;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);

	
	}
}
