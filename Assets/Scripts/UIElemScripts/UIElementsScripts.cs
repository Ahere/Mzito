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
		lifeText.text = PlayerScript.lifeCount.ToString();
		coinText.text = PlayerScript.coinCount.ToString();
		scoreText.text = PlayerScript.scoreCount.ToString();
	}

}