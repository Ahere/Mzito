using UnityEngine;
using System.Collections;

public class CollectablesScript : MonoBehaviour {

	// Use this for initialization
	//void OnEnable () {
	//	Invoke ("DestroyCollectable", 7.5f);
	//}

	void DestroyCollectable() {
		gameObject.SetActive (false);
	}

}
