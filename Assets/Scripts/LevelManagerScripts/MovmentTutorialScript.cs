using UnityEngine;
using System.Collections;
using MadLevelManager;

public class MovmentTutorialScript : MonoBehaviour 
{

	public GameObject TutorialUI;
	public GameObject TutorialEndUi;
	public GameObject NextLevelUi;

	// Use this for initialization
	void Start () 
	{

		TutorialEndUi.SetActive(false);
		NextLevelUi.SetActive(false);


	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (TutorialPlayerScript.coinCount == 6)
		{

			Time.timeScale = 0.0f;
			TutorialEndUi.SetActive(true);
			NextLevelUi.SetActive(true);
			MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);


		}
	
	}

	public void TutorialStart()
	{
	  TutorialPlayerScript.TutorialUI = true;
      TutorialUI.SetActive(false);
      



	}


}
