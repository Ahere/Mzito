using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	// Use this for initialization
	

	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag =="Background") {
			Debug.Log("shit went down");
			 //if the target is background , deactivate it
			target.gameObject.SetActive(false);
		}

	}

}
