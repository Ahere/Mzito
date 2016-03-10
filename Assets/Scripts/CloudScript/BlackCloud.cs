using UnityEngine;
using System.Collections;

public class BlackCloud : MonoBehaviour {

	// Use this for initialization
void OnTriggerEnter2D (Collider2D target)
{
   if (target.tag == "Player")
   {
        
   	   Vector3 temp = target.transform.position;
   	   temp.x = 100;
   	   temp.y = 100;
   	   target.transform.position = temp;

   }


 }
}
