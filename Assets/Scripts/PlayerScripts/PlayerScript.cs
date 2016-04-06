using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 8.0f;	// the speed by which the player moves
	public float maxVelocity = 3.0f;	// maximum velocity of the player
   
	private Animator animator;	    // players animator for animation controlce to the camera script

    public string reloadLevel;
	public AudioClip lifeSound;     // Sounds
	public AudioClip coinSound;


	public Vector3 boundaries;      // player boundaries

	public static int lifeCount;	// life counter
	public static int coinCount;	// coin counter
	public static int scoreCount;	// score counter
	[SerializeField]
	private float animScale = 1.0f ;	// scale for animator

	public bool countPoints;	// boolean value to control the point count, initialy it is set to true but when the player dies it will be
	// set to false to prevent score count while the player is dead
	// 
    public Vector3 lastPosition;  //Players Last position.

    private CameraScript cameraScript;

    private int easyDifficulty;		
	private int mediumDifficulty;
	private int hardDifficulty;

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

	// Use this for initialization
	void Awake () {
		Time.timeScale = 0.0f;
		endScoreBG.SetActive (false);
		animator = GetComponent<Animator> ();	// getting the animator reference
		 
		 scoreCount = 0;
		 lastPosition = transform.position;    // sets last position as start position.

		 boundaries = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 0)); // getting player boundaries

		easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		hardDifficulty = GamePreferences.GetHardDifficultyState ();

        fadeScript = fader.GetComponent<GamePlayFaderScript> (); // fader script reference
        fader.SetActive (false);
        isTheGameStartedFromBegining = true;
        //platColor =    GameObject.FindGameObjectWithTag("Clouds").GetComponent<SpriteRenderer>(); // cloud sprite renderer refrence
		cameraScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraScript> (); // camera script reference

		// check if the game was started from main manu to set initial values
		IsTheGameStartedFromMainMenu ();
		
		// check if the game was resumed after player died to continue the game
		IsTheGameResumedAfterPlayerDied ();
		DoorUI.SetActive(false);
    
	
	}

	void Update () {
				
			if (Time.timeScale == 1.0f) 
			{
			
			PlayerWalkKeyboard ();
			
			PlayerWalkMobile ();
			}
	
			//if(countTouches > 3) {
				SetScore ();
			//}

		}



	void LateUpdate()
	 {

		if (isTheGameStartedFromBegining) 
		{
			
			if (Input.GetMouseButtonDown (0)) 
			{
				
			//	if(adScript.bannerView != null) {
			//		adScript.bannerView.Hide();
			//		adScript.bannerView.Destroy();
			//		adScript.bannerView = null;
			//	}
				
				Time.timeScale = 1.0f;	
				
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

				scoreCount++;
			}
		lastPosition = transform.position;

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



//	void LateUpdate (){

		//Time.timeScale = 1.0f;	
//	}
	
	// Update is called once per frame
	

void PlayerWalkMobile() {

		// force by which we will push the player
		float force = 0.0f;
		// the players velocity
		//float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

		if (Input.touchCount > 0) {

				

				Touch h = Input.touches[0];
				
				Vector2 position = Camera.main.ScreenToViewportPoint(new Vector2(h.position.x, h.position.y));
				////Debug.Log(position);
				
				float velocity = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);

				if(position.x > 0.5) {
					
					// if the velocity of the player is less than the maxVelocity
					if(velocity < maxVelocity){
						force = speed;
					}
					
					// turn the player to face right
					Vector2 scale = transform.localScale;
					scale.x = animScale;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);
					
				} 


				else if(position.x < 0.5) 
				{
					
					// if the velocity of the player is less than the maxVelocity
					if(velocity < maxVelocity)
					{
						force = -speed;
					}
					
					// turn the player to face right
					Vector2 scale = transform.localScale;
					scale.x = -animScale;
					transform.localScale = scale;
					
					// animate the walk
					animator.SetInteger("Walk", 1);
					
				}
				// add force to rigid body to move the player
				GetComponent<Rigidbody2D>().AddForce(new Vector3(force, 0, 0));
				
				// set the idle animation
				if(h.phase == TouchPhase.Ended) 
					animator.SetInteger("Walk", 0);

			} // if Input.touchCount > 0

	} // player walk mobile

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
			animator.SetInteger("Walk", 1);
			
			// check if the player is moving left
		}  else if(h < 0) {
			
			// if the velocity of the player is less than the maxVelocity
			if(velocity < maxVelocity)
				force = -speed;
			
			// turn the player to face left
			Vector3 scale = transform.localScale;
			scale.x = -animScale;
			transform.localScale = scale;
			
			// animate the walk
			animator.SetInteger("Walk", 1);
			
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

	 if (target.tag == "Coins") 
	   {
			coinCount++;
			scoreCount += 200;
			AudioSource.PlayClipAtPoint(coinSound, target.transform.position);
			target.gameObject.SetActive (false);
		}
       
     if (target.tag == "Life") 
       {
			lifeCount++;
			scoreCount += 300;
			AudioSource.PlayClipAtPoint(lifeSound, target.transform.position);
			target.gameObject.SetActive (false);
			
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
		

		if (target.tag =="Door") 
		{
			
			cameraScript.moveCamera = false;
		    DoorUI.SetActive (true);
			 // Door open and stop the camera.
			
			
		}
	
       

    }

	 void OnTriggerExit2D(Collider2D target) 
    {

		if (target.tag =="Door") 
		{
			
		    DoorUI.SetActive (false);
		    cameraScript.moveCamera = true;
		    // Set door UI to false and continue camera
			 
			
			
	    }
	}

void CheckGameStatus() {
		
		// remove the player from scene by changing his x y position, and then decrement lifes
		Vector3 temp = transform.position;
		temp.x = 100;
		temp.y = 100;
		transform.position = temp;
		lifeCount--;
		
		// if lifes are less than 0 end the game, get the coins and score and check it with the highscore
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
			
			
		}
		
	}
	IEnumerator ReloadGame() {
		
		// set the fader to be active because we need it now
		fader.SetActive (true);
		
		// wait half a second before fading
		yield return new WaitForSeconds(0.5f);
		
		// fade
		float fadeTime = fadeScript.BeginFade (1);
		
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(reloadLevel);
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
		yield return new WaitForSeconds(3);
		
		// activate fader
		fader.SetActive (true);
		
		// set MainMenuOpenedFromGameplay to 1, so that the fader in MainMenuScene will fade smoothly
		PlayerPrefs.SetInt (GamePreferences.MainMenuOpenedFromGameplay, 1);
		
		// fade
		float fadeTime = fadeScript.BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		
	SceneManager.LoadScene("MainMenu");

}


}
