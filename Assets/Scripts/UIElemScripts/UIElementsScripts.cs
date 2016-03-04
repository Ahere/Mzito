using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIElementsScripts : MonoBehaviour 
{


	[SerializeField]
	private Text lifeText;

	[SerializeField]
	private Text coinText;

	[SerializeField]
	private Text scoreText;

	// Use this for initialization
	void Start ()
	{
		UpdateScore ();
	}



	// Update is called once per frame
	void Update () 
	{
		UpdateScore ();
	}
   


	void UpdateScore() 
	{
		lifeText.text = "x" + PlayerScript.lifeCount;
		coinText.text = "x" + PlayerScript.coinCount;
		scoreText.text = "" + PlayerScript.scoreCount;
	}

}