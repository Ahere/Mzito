using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialUIElementsScripts : MonoBehaviour 
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
		lifeText.text = TutorialPlayerScript.lifeCount.ToString();
		coinText.text = TutorialPlayerScript.coinCount.ToString();
		scoreText.text = TutorialPlayerScript.scoreCount.ToString();
	}

}