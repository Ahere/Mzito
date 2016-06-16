using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using MadLevelManager;

public class PlayerScript : MonoBehaviour {
	public Text text1;
	public Text text2;
    public Vector3 fingerPos;
    public GameObject[] listener1;     // listerner to help count them.
    public GameObject[] listener2;     // listerner to help count them.
    public bool completeLevel;
	public float speed = 8.0f;	// the speed by which the player moves
	public float maxVelocity = 3.0f;	// maximum velocity of the player
	public bool grounded;
	
   
	private Animator animator;	    // players animator for animation controlce to the camera script
    public Animator effects;
    public Animator effects2;
	public Animator BoostCharge;
	public Material boostMat;
	public Material NormalMat; 
	public Material boostGuiMat;

    public string reloadLevel;
	public AudioClip lifeSound;     // Sounds
	public AudioClip coinSound;



	public Vector3 boundaries;      // player boundaries

	public static int lifeCount;	// life counter
	public static int coinCount;	// coin counter
	public static int scoreCount;	// score counter
	public static int musicBoostCount;  // Boost count.
	private int  mBoostChecker;
	[SerializeField]
	private float animScale = 2.0f ;	// scale for animator

	public bool countPoints;	// boolean value to control the point count, initialy it is set to true but when the player dies it will be
	// set to false to prevent score count while the player is dead
	// 
    public Vector3 lastPosition;  //Players Last position.

    private CameraScript cameraScript;

    public CloudSpawnerScript platformScript;

    private int easyDifficulty;		
	private int mediumDifficulty;
	private int hardDifficulty;
	public GameObject TutorialText;

//	public SpriteRenderer platColor;

    [SerializeField]
	private GameObject endScoreBG;

	[SerializeField]
	private Text endScoreText;

	[SerializeField]
	private Text endCoinText;

	[SerializeField]
	private GameObject ready;

	[SerializeField]
	private GameObject fader;	// fader game object reference

    private GamePlayFaderScript fadeScript; // main menu fade script

    public static bool isTheGameStartedFromBegining; // a boolean to control the touching in our LateUpdate so it will not interfere with our

    public GameObject DoorUI;

    public   int a = 0;
    public   int b = 0;
    

	// Use this for initialization
	void Awake () 

	{
		musicBoostCount = 0;
		mBoostChecker = 0;
	 		
        grounded = true;
		
		completeLevel = false; // initialize the level as looked.
		Time.timeScale = 0.0f;
		endScoreBG.SetActive (false);
		animator = GetComponent<Animator> ();	// getting the animator reference
		 
		 scoreCount = 0;
		 lastPosition = transform.position;    // sets last position as start position.

		 boundaries = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width , 0, 0)); // getting player boundaries

		easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		hardDifficulty = GamePreferences.GetHardDifficultyState ();

        fadeScript = fader.GetComponent<GamePlayFaderScript> (); // fader script reference
        fader.SetActive (false);
        isTheGameStartedFromBegining = true;
        //platColor =    GameObject.FindGameObjectWithTag("Clouds").GetComponent<SpriteRenderer>(); // cloud sprite renderer refrence
		cameraScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraScript> (); // camera script reference
        platformScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CloudSpawnerScript>(); // cloud spawner script refrence.


		// check if the game was started from main manu to set initial values
		IsTheGameStartedFromMainMenu ();
		
		// check if the game was resumed after player died to continue the game
		IsTheGameResumedAfterPlayerDied ();
		DoorUI.SetActive(false);



		

	
	}
	
	
		


	void Update () 
	{
				
		if (Time.timeScale == 1.0f) 
		{
			
			PlayerWalkKeyboard ();

		    Gyrowalk ();
			
		}
	
		
		SetScore ();
		CheckLevelCompleted();

			
		if (lifeCount > 2)  // max lives is now 2
		
		{
			lifeCount = 2;
		}


		if (Input.GetMouseButtonDown (0) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 


		{		
				
				Time.timeScale = 1.0f;
		       		
		} 
      CheckMusicBoostCount();
      CheckboostGui();
	  MusicBoost();
      
     


      text1.text = (mBoostChecker.ToString());
      text2.text = (musicBoostCount.ToString());

      
      

    
	}



	void LateUpdate()
	 {
	 	

		if (isTheGameStartedFromBegining) 
		{
			
			if (Input.GetMouseButtonDown (0) || Input.touchCount > 0 ) 
			{
				
			//	if(adScript.bannerView != null) {
			//		adScript.bannerView.Hide();
			//		adScript.bannerView.Destroy();
			//		adScript.bannerView = null;
			//	}
				
				
				
				countPoints = true; // score points is true initialy
				isTheGameStartedFromBegining = false;
				
			}

		}

		CheckBounds ();
	}


	void SetScore() 

	{ 
		if (countPoints) 
		{

			if (transform.position.y < lastPosition.y)
			{

				//scoreCount++;
			}
		lastPosition = transform.position;

		}



	}



	public void checkPlatforms() // check if the bluue platforms are linked to the checker
	{ 


    for(int i = 0; i <= 5 ; i++ )
	{


		if (platformScript.cloudsInGame[i].name == null )
		      {


		      	Debug.Log("Nothing here");


		      }



	   else
		      {
				  if(platformScript.cloudsInGame[i].name == "plat1")

				  {
				   
				    listener1[a] = platformScript.cloudsInGame[i];
				    a++;
				    Debug.Log(a + " a value");
				  }

				  if(platformScript.cloudsInGame[i].name == "plat2")
				  {
				    
				    listener2[b] = platformScript.cloudsInGame[i];
				    b++;
				    Debug.Log(b + " b value");
				  }
			  }

	    }      

	 }


	void CheckBounds() {

		// check if the players x is greather than the x of the boundaries, if its true set the players x to be boundaries x
		if (transform.position.x > boundaries.x)
	    {
			Vector3 temp = transform.position;
			temp.x = boundaries.x;
			transform.position = temp;
		}

		// check if the players x is less than the x of the boundaries, if its true set the players x to be negative boundaries x
		if (transform.position.x < (-boundaries.x)) 
		{
			Vector3 temp = transform.position;
			temp.x = -boundaries.x;
			transform.position = temp;
		}

	}

	public void CheckLevelCompleted()     // check if the level is completed.
	{
		if (scoreCount > 2000)  // check if the score is enough to mark the level completed.
		{
			completeLevel = true;

            if (completeLevel) 
	
            {

            MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);


           }

        }

	}
     
     void Gyrowalk ()
{
        float speed = Input.acceleration.x * 0.2f;
        Mathf.Clamp(speed ,-0.030f, 0.030f);

        if (speed > 0 &&  Time.timeScale == 1.0f)
        {
        
         //Debug.Log("rightspeed"+ speed );
        Vector2 scale = transform.localScale;
        scale.x = animScale;
        gameObject.transform.localScale = scale;
          
    // animate the walk
         animator.SetFloat( "WalkG", 1.0f );
          


        }


         if (speed < 0 && Time.timeScale == 1.0f)
      {
       
       
       // Debug.Log("leftspeed"+ speed);
        Vector2 scale = transform.localScale;
        scale.x = -animScale;
        gameObject.transform.localScale = scale;
          
          // animate the walk
        animator.SetFloat( "WalkG" , 1.0f);
    

      }

     gameObject.transform.Translate (speed, 0 , 0);


}

	void PlayerWalkKeyboard() 
	{

		// force by which we will push the player
		float force = 0.0f;
		// the players velocity
		float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		
		// getting the input from the player
		float h = Input.GetAxis ("Horizontal");
		
		// checking if the player is moving right
		if (h > 0) {
			
			// if the velocity of the player is less than the maxVelocity
			if(velocity < maxVelocity)
				force = speed;
			
			// turn the player to face right
			Vector3 scale = transform.localScale;
			scale.x = animScale;
			transform.localScale = scale;
			
			// animate the walk
			//animator.SetInteger("Walk", 1);
			
			// check if the player is moving left
		}  else if(h < 0) {
			
			// if the velocity of the player is less than the maxVelocity
			if(velocity < maxVelocity)
				force = -speed;
			
			// turn the player to face left
			Vector3 scale = transform.localScale;
			scale.x = -animScale;
			transform.localScale = scale;
			
			//animate the walk
			//animator.SetInteger("Walk", 1);
			
		}
		
		// if the{} player is not moving set the animation to idle
	  if(h == 0){
			animator.SetInteger("Walk", 0);
	  }
		
		// add force to rigid body to move the player
	GetComponent<Rigidbody2D>().AddForce(new Vector2 (force, 0));

	}

void IsTheGameStartedFromMainMenu() {
		
		int isTheGameStartedFromMainMenu = PlayerPrefs.GetInt (GamePreferences.GameStartedFromMainMenu);
		
		if (isTheGameStartedFromMainMenu == 1) {
			
			if(easyDifficulty == 1) 
			{
				cameraScript.SetEasySpeed();
			}
			
			if(mediumDifficulty == 1) {
				cameraScript.SetMediumSpeed();
			}
			
			if(hardDifficulty == 1) {
				cameraScript.SetHardSpeed();
			}
			
			scoreCount = 0;	// score is 0
			coinCount = 0;  // coin score is 0
			lifeCount = 2;
			
			PlayerPrefs.SetInt(GamePreferences.GameStartedFromMainMenu, 0);
			
		}
		
	}
	
	// check if the game is resumed after player died
	void IsTheGameResumedAfterPlayerDied() {
		
		int gameResumedAfterPlayerDied = PlayerPrefs.GetInt (GamePreferences.GameResumedAfterPlayerDied);
		
		if (gameResumedAfterPlayerDied == 1) {
			
			scoreCount = PlayerPrefs.GetInt(GamePreferences.CurrentScore);
			coinCount = PlayerPrefs.GetInt(GamePreferences.CurrentCoinScore);
			lifeCount = PlayerPrefs.GetInt(GamePreferences.CurrentLifes);
			
			
			PlayerPrefs.SetInt(GamePreferences.GameResumedAfterPlayerDied, 0);
		}
		
	}


	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag =="Door") 

    {
			
			cameraScript.moveCamera = false;
		    DoorUI.SetActive (true);
		    
			 // Door open and stop the camera.
	}
     
     if (target.tag == "plateffects")
     {

       effects2 = target.gameObject.GetComponent<Animator>();
       StartCoroutine(PlatformAnimation());
       Debug.Log ("animate");

     }
	

 
	 if (target.tag == "Coins") 
	   {    

	   	    
			coinCount++;
			scoreCount += 200;
			AudioSource.PlayClipAtPoint(coinSound, target.transform.position);
			target.gameObject.SetActive (false);
            StartCoroutine(CoinPickUpAnimation()); 
            Debug.Log("ïsss");
			
		}
       
     if (target.tag == "Life") 
       {    
       	    
			lifeCount++;
			scoreCount += 300;
			AudioSource.PlayClipAtPoint(lifeSound, target.transform.position);
			target.gameObject.SetActive (false);  
       	    StartCoroutine(HealthPickUPAnimation());
       	    Debug.Log("ïsss");
			
			
		}
		
	if (target.tag == "Boundary") 
		{   
			
			cameraScript.moveCamera = false;
			countPoints = false;
			
			CheckGameStatus();

			
		    
		}
		
	if (target.tag == "Deadly") 
		{   
			
			cameraScript.moveCamera = false;
			countPoints = false;

            
			CheckGameStatus();
				
		}
		

		


     for(int i = 0; i < listener1.Length; i++)
     {
        
		if (target.gameObject == listener1[i] )
		  { 
		  	
            musicBoostCount++;
		  	Debug.Log ("IT HAPPEND");
		  	
		   
           
            
			
		 } 

	}   


	for(int i = 0; i < listener2.Length; i++)
     {
        
		if (target.gameObject == listener2[i])
		  { 
		  	
            musicBoostCount++;
		  	Debug.Log ("IT HAPPEND2");	
		    
            
		    	
		 } 

	}


	if (target.tag == "Clouds")
  	{
     
  	 grounded = true;
    

  	}     

  }


  void OnTriggerStay2D (Collider2D target)
  {

  	

  	



  }

	 void OnTriggerExit2D(Collider2D target) 
    {


	    if (target.tag == "Clouds")
	    {
	    	grounded =  false;
	
	    	
	    }

	    if (target.tag =="Door") 

        {
			
			cameraScript.moveCamera = true;
		    DoorUI.SetActive (false);
		    
			 // Door open and stop the camera.
	    }

		
	}

void CheckMusicBoostCount ()
{
	if(musicBoostCount > 0)
	 {
	 		               
	 		mBoostChecker++;
	 		musicBoostCount = musicBoostCount -1;
	 		 
     }
	
	if (mBoostChecker == -1)
	{

		mBoostChecker = 0;
	}


	if (mBoostChecker == 0)
	{
		GetComponent<Renderer>().material = NormalMat;
	}


	if (mBoostChecker > 0)
	{
		GetComponent<Renderer>().material = boostMat;
	}


	if (mBoostChecker > 4)
	{
		mBoostChecker = 4;
	}




}

void CheckGameStatus() 
   {

   	  lifeCount--;
       
	  StartCoroutine( DeathAnimation());

	  if(lifeCount < 0) 
		{
			
			if(easyDifficulty == 1) 
			{
				
				int currentHighscore = GamePreferences.GetEasyDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetEasyDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetEasyDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) 
				{
					GamePreferences.SetEasyDifficultyCoinScore(coinCount);
				}
				
				
			}   // easy difficulty
			
			if(mediumDifficulty == 1) 
			{
				
				int currentHighscore = GamePreferences.GetMediumDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetMediumDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetMediumDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) 
			    {
					GamePreferences.SetMediumDifficultyCoinScore(coinCount);
			    }
				
			}   // mediumDifficulty
			
			if(hardDifficulty == 1) 
			{
				
				int currentHighscore = GamePreferences.GetHardDifficultyHighscore();
				int currentCoinHighscore = GamePreferences.GetHardDifficultyCoinScore();
				
				if(currentHighscore < scoreCount)
					GamePreferences.SetHardDifficultyHighscore(scoreCount);
				
				if(currentCoinHighscore < coinCount) 
				{
					GamePreferences.SetHardDifficultyCoinScore(coinCount);
			    }
				
			}   // hard difficulty
			
			// set the life count to be zero so that it wont display -1 on screen
			lifeCount = 0;
			
			Debug.Log("restart");

			StartCoroutine(ReloadMainMenuAfterPlayerHasNoMoreLifesLeft());
			
			
			// the player has still lifes left to continue the game
		}


		else 
		{ 
            
			
			PlayerPrefs.SetInt(GamePreferences.CurrentScore, scoreCount);
			PlayerPrefs.SetInt(GamePreferences.CurrentCoinScore, coinCount);
			PlayerPrefs.SetInt(GamePreferences.CurrentLifes, lifeCount);
			
			PlayerPrefs.SetInt(GamePreferences.GameResumedAfterPlayerDied, 1);
			
			StartCoroutine(ReloadGame());

			Debug.Log("relode");
			
			
		}
		
		
		
	}



	 void MusicBoost() 
	 {  
	     // checks if the music boostcount has reached 2 if it has it will ADD 1 to the checker and allow you to usic bost.

      
                StartCoroutine( DashAnimateStart()); 
             
                 

     }


     void CheckboostGui()
     {

     	if (mBoostChecker > 0)
     	{
     		TutorialText.SetActive(true);
     	}

     	if (mBoostChecker == 0  )
     	{

         BoostCharge.SetInteger("dash", 1);
         TutorialText.SetActive(false);

     	}
     
       
       if(mBoostChecker == 1  )
       {
       	 BoostCharge.SetInteger("dash", 2);
       }


        if(mBoostChecker == 2  )
       {
       	 BoostCharge.SetInteger("dash", 3);
       }


        if(mBoostChecker == 3  )
       {
       	
         BoostCharge.SetInteger("dash", 4);
       }



        if(mBoostChecker == 4  )
       {
       	 BoostCharge.SetInteger("dash", 5);

       }


     }

     /// ENUMARATORS.


      IEnumerator PlatformAnimation() 
    
    {

    	effects2.SetBool("Vibrate" , false);

        yield return new WaitForSeconds(0.4f);

        effects2.SetBool("Vibrate" , false);


    }
      IEnumerator HealthPickUPAnimation() 
    
    {

    	effects.SetBool("Heal", true);

        yield return new WaitForSeconds(0.4f);

        effects.SetBool("Heal", false);


    }


     IEnumerator CoinPickUpAnimation() 
    
    {


    	effects.SetBool("Coin", true);

        yield return new WaitForSeconds(0.4f);

        effects.SetBool("Coin", false);
		
    	

    }

   

    IEnumerator DeathAnimation() 
    
    {

    	animator.SetBool("Death", true);

        yield return new WaitForSeconds(0.8f);


        Vector3 temp = transform.position;   // transform character away.
		temp.x = 100;
		temp.y = 100;
		transform.position = temp;

		
    	

    }



     IEnumerator DashAnimateStart() 
    {   
    	
        
     if (Input.touchCount > 0 && mBoostChecker > 0 && grounded == false) 
         {
                // The screen has been touched so store the touch
            Touch touchMe = Input.GetTouch(0);

           

        if (touchMe.phase == TouchPhase.Began) 
             {
             	 animator.SetBool("Flash", true);

                 // If the finger is on the screen, move the object smoothly to the touch position
        
                 Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchMe.position.x, touchMe.position.y, 5));

                 transform.position = Vector2.MoveTowards(transform.position, touchPosition, 20.0f );
                 
                 mBoostChecker = mBoostChecker - 1; 

                 
            }

            

            yield return new WaitForSeconds(0.4f);

            animator.SetBool("Flash", false);

       }
        
    }
   
	 
	IEnumerator ReloadGame() 
	{
		
		// set the fader to be active because we need it now
		fader.SetActive (true);
		
		// wait half a second before fading
		yield return new WaitForSeconds(0.5f);
		
		// fade
		float fadeTime = fadeScript.BeginFade (1);
		
		yield return new WaitForSeconds(fadeTime);
		MadLevel.LoadLevelByName(reloadLevel);
	}
	
	// reload main menu after player has no more lifes left
	IEnumerator ReloadMainMenuAfterPlayerHasNoMoreLifesLeft() {
		
		// activate the end showing score gameobjects
		endScoreBG.SetActive (true);
		//endScoreText.rectTransform.localPosition = endScoreTextPosition;
		//endCoinText.rectTransform.localPosition = endCoinScorePosition;

		endScoreText.text = scoreCount.ToString();
		endCoinText.text = coinCount.ToString ();
				
		// wait 3 seconds for the player to see the score
		yield return new WaitForSeconds(5);
		
		// activate fader
		fader.SetActive (true);
		
		// set MainMenuOpenedFromGameplay to 1, so that the fader in MainMenuScene will fade smoothly
		PlayerPrefs.SetInt (GamePreferences.MainMenuOpenedFromGameplay, 1);
		
		// fade
		float fadeTime = fadeScript.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		
	MadLevel.LoadLevelByName("MainMenu");

}

  


}
