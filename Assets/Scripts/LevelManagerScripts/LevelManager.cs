using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 

{

	// Use this for initialization
	public void Level2()
	{
      SceneManager.LoadScene("Gameplay 2");
	}

	

	public void Level1()
	{
     
      SceneManager.LoadScene("Gameplay");

	}

}
