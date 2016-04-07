using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour 
{

	public Color platColor;
	public Color startColor;
	

	private SpriteRenderer temp;

	

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D target)
	{
      if (target.tag =="Player")
      {
 
       temp = this.GetComponent<SpriteRenderer>();
       platColor = Color.white;
       temp.color = platColor;
       PlayerScript.scoreCount += 25;

      }

	}

	 void OnBecameInvisible() 
	 {
        temp = temp = this.GetComponent<SpriteRenderer>();
        platColor = Color.blue;
        temp.color = platColor;
     }
}
