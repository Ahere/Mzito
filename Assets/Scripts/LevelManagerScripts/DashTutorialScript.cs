using UnityEngine;
using System.Collections;
using MadLevelManager;

public class DashTutorialScript : MonoBehaviour 
{

	public GameObject TutorialUI;
	public GameObject TutorialUI2;
	public GameObject TutorialUI3;
	public GameObject TutorialEndUi;
	public GameObject NextLevelUi;

	// Use this for initialization
	void Start () 
	{

		TutorialEndUi.SetActive(false);
		TutorialUI2.SetActive(false);
        TutorialUI3.SetActive(false);
        NextLevelUi.SetActive(false);


	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (TutorialPlayerScript.coinCount == 6)
		{

			Time.timeScale = 0.0f;
			TutorialEndUi.SetActive(true);
			MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);


		}
	
	}

	public void Tutorial2Start()
	{
      TutorialUI.SetActive(false);
      TutorialUI2.SetActive(true);

	}

	public void Tutorial3Start()
	{
      TutorialUI2.SetActive(false);
      TutorialUI3.SetActive(true);
      NextLevelUi.SetActive(true);

	}
	public void Tutorial3End()
	{
	  TutorialUI3.SetActive(false);
	  TutorialPlayerScript.TutorialUI = true;

	} 


}
