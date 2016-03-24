using UnityEngine;
using System.Collections;
//using UnityEngine.UI;



public class DoorScript : MonoBehaviour 
{  


	// Use this for initialization
	// 
	// 
	


	void OnEnable () 
	{
		Invoke ("DestroyCollectable", 13.0f);
	}


	void DestroyCollectable()
	{
		gameObject.SetActive (false);
	}


    


    


    

  
}
