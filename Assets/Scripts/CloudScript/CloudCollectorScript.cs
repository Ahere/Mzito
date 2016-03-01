using UnityEngine;
using System.Collections;

public class CloudCollectorScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D target)

	{
        if((target.tag =="Clouds") || (target.tag == "Deadly")) 
        {
        	target.gameObject.SetActive(false);
        }

	}
	
}
