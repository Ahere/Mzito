using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScoreScript : MonoBehaviour {

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text coinText;


	// Use this for initialization
	void Awake () {
		CheckDifficultyAndSetScore ();
		CheckDifficultyAndSetCoinScore ();
	}
	
	public void BackButton() {
		SceneManager.LoadScene("MainMenu");
	}

	void CheckDifficultyAndSetCoinScore() {
		
		int easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		int mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		int hardDifficulty = GamePreferences.GetHardDifficultyState ();
		
		if (easyDifficulty == 1) {
			coinText.text = GamePreferences.GetEasyDifficultyCoinScore().ToString();	
		}
		
		if (mediumDifficulty == 1) {
			coinText.text = GamePreferences.GetMediumDifficultyCoinScore().ToString();	
		}
		
		if (hardDifficulty == 1) {
			coinText.text = GamePreferences.GetHardDifficultyCoinScore().ToString();
		}
		
	}

	void CheckDifficultyAndSetScore() {
		
		int easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		int mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		int hardDifficulty = GamePreferences.GetHardDifficultyState ();
		
		if (easyDifficulty == 1) {
			scoreText.text = GamePreferences.GetEasyDifficultyHighscore().ToString();	
		}
		
		if (mediumDifficulty == 1) {
			scoreText.text = GamePreferences.GetMediumDifficultyHighscore().ToString();
		}
		
		if (hardDifficulty == 1) {
			scoreText.text = GamePreferences.GetHardDifficultyHighscore().ToString();
		}
		
	}
}
