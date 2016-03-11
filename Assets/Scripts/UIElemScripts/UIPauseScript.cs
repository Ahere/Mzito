using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIPauseScript : MonoBehaviour
{

	private AudioSource audioSource;
	
	private bool audioSourceWasPlayingBefore;
	
	private float continueSong;

	//private PlayerScript Player;


	
	[SerializeField]
	private GameObject pauseUI;

	

	[SerializeField]
	private GameObject resumeBtn;



	[SerializeField]
	private GameObject quitBtn;

	


	[SerializeField]
	private GameObject ready;

	private float waitTime = 1.5f;


	// Use this for initialization
	void Awake ()
	 {

	//Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript> ();
	audioSource = GameObject.FindGameObjectWithTag ("BGMusic").GetComponent<AudioSource> ();
    pauseUI.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PauseButton()
	 {    


		if(audioSource != null) 
		{
			pauseUI.SetActive (true);

			if(audioSource.isPlaying) 
			{
				continueSong = audioSource.time;
				audioSource.Stop();
				audioSourceWasPlayingBefore = true;
			}
			
		}

		if (Time.timeScale != 0.0f) {

			
			Time.timeScale = 0.0f;		

		}
		

		
	} // start button
	
	public void ResumeButton() 
	{

		if (audioSource != null) 
		{
			
			if(audioSourceWasPlayingBefore) {
				audioSource.time = continueSong;
				audioSource.Play();
				audioSourceWasPlayingBefore = false;
			}
			
		}
	
				
	
	
				Time.timeScale = 1.0f;

        pauseUI.SetActive (false);
    	StartCoroutine (ResumeGame ());


	} // resume button

	public void QuitButton() 
	{
		
		if (audioSource != null) 
		{
			
			if(audioSourceWasPlayingBefore)
			 {
				audioSource.time = continueSong;
				audioSource.Play();
				audioSourceWasPlayingBefore = false;
			}
			
		}
		
		SceneManager.LoadScene("MainMenu");
		
	} // quit button

	IEnumerator ResumeGame() 
	{

		yield return new WaitForSeconds(2);

		Time.timeScale = 1.0f;

		//if (!ready.activeInHierarchy) {
	//		Debug.Log("In if statement");
	//		ready.SetActive(true);
	//		Player.isTheGameStartedFromBegining = true;
	//	}


	}

} // class