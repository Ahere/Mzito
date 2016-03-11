using UnityEngine;
using System.Collections;

public class BGMuusic : MonoBehaviour {

	private static BGMuusic instance;

	void Awake () {
		if(instance)
			DestroyImmediate(gameObject);	// delete duplicate
		else {
			instance = this;	//Make this object the only instance
			DontDestroyOnLoad(gameObject);	// dont destoy it when scenes load
		}
	}
}
