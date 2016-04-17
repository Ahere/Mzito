using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 

{
    public string reloadLevel;
	// Use this for initialization
	

	public void Level1()
	{
     
      SceneManager.LoadScene("1_Mji_Ya_Ngoma");

	}
	public void Level2()
	{
      SceneManager.LoadScene("2_Flamingo");
	}
    public void Level3()
	{
     
      SceneManager.LoadScene("3_Buffalo_Miggration");

	}
	public void Level4()
	{
     
      SceneManager.LoadScene("4_Mountain_Gorrilas");

	}
	public void Level5()
	{
     
      SceneManager.LoadScene("5_Pyramids");

	}
	public void Level6()
	{
     
      SceneManager.LoadScene("6_Zambezi");

	}
	public void ReloadLevel()
	{
		SceneManager.LoadScene(reloadLevel);
	}
}
