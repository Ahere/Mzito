using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using MadLevelManager;

public class LevelManager : MonoBehaviour
{
    public string reloadLevel;
	// Use this for initialization
	

	public void Level1()
	{
     
      MadLevel.LoadLevelByName("1_Mji_Ya_Ngoma");

	}
	public void Level2()
	{
      MadLevel.LoadLevelByName("2_Flamingo");
	}
    public void Level3()
	{
     
      MadLevel.LoadLevelByName("3_Buffalo_Miggration");

	}
	public void Level4()
	{
     
      MadLevel.LoadLevelByName("4_Mountain_Gorrilas");

	}
	public void Level5()
	{
     
      MadLevel.LoadLevelByName("5_Pyramids");

	}
	public void Level6()
	{
     
      MadLevel.LoadLevelByName("6_Zambezi");

	}
	public void ReloadLevel()
	{
		MadLevel.LoadLevelByName(reloadLevel);

	}

	public void LevelSelect()
    {

	 MadLevel.LoadLevelByName("LevelSelect");
    }
    public void Tutorial1()
	{
     
      MadLevel.LoadLevelByName("0_TutorialStage");

	}
	public void Tutorial2()
	{
     
      MadLevel.LoadLevelByName("0_TutorialStage2");

	}


}
