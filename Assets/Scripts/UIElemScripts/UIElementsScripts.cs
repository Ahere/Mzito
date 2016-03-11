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
	void Awake ()
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
		lifeText.text = "LIVES = " + PlayerScript.lifeCount;
		coinText.text = "COINS = " + PlayerScript.coinCount;
		scoreText.text ="SCORE = " + PlayerScript.scoreCount;
	}

}