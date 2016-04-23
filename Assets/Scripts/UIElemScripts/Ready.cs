using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		Invoke ("DestroyCollectable", 2.0f);
	}

	void DestroyCollectable() {
		gameObject.SetActive (false);
	}

}
