using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class OptionsMenuScripts : MonoBehaviour {


  public AudioClip touchClip;

  public AudioSource audioSource; 


	[SerializeField]
  private Button easyBtn;

	[SerializeField]
  private Button mediumBtn;

    [SerializeField]
  private Button hardBtn;
    [SerializeField]
  private Image sign;
	// Use this for initialization
	void Awake () 
	{
	  CheckDifficulty ();
	}
	
	// Update is called once per frame
		public void BackButton() 
		{
		SceneManager.LoadScene("MainMenu");
	  }

	 public void EasyButton() {


		
	
		GamePreferences.SetEasyDifficultyState(1);
		GamePreferences.SetMediumDifficultyState(0);
		GamePreferences.SetHardDifficultyState(0);

		float positionY = easyBtn.transform.localPosition.y;
		Vector3 temp = sign.rectTransform.localPosition;
		temp.y = positionY;
		sign.rectTransform.localPosition = temp;
	}

	public void MediumButton() {




		GamePreferences.SetEasyDifficultyState(0);
		GamePreferences.SetMediumDifficultyState(1);
		GamePreferences.SetHardDifficultyState(0);

		float positionY = mediumBtn.transform.localPosition.y;
		Vector3 temp = sign.rectTransform.localPosition;
		temp.y = positionY;
		sign.rectTransform.localPosition = temp;
	}

	public void HardButton() {

		


		GamePreferences.SetEasyDifficultyState(0);
		GamePreferences.SetMediumDifficultyState(0);
		GamePreferences.SetHardDifficultyState(1);

		float positionY = hardBtn.transform.localPosition.y;
		Vector3 temp = sign.rectTransform.localPosition;
		temp.y = positionY;
		sign.rectTransform.localPosition = temp;
	}

	public void playSound ()
	{
		AudioSource.PlayClipAtPoint(touchClip, this.transform.position);
	}


	void CheckDifficulty() {
		
		int easyDifficulty = GamePreferences.GetEasyDifficultyState ();
		int mediumDifficulty = GamePreferences.GetMediumDifficultyState ();
		int hardDifficulty = GamePreferences.GetHardDifficultyState ();
		
		if(easyDifficulty == 1) {

			float positionY = easyBtn.transform.localPosition.y;
			Vector3 temp = sign.rectTransform.localPosition;
			temp.y = positionY;
			sign.rectTransform.localPosition = temp;
		}
		
		if (mediumDifficulty == 1) {
			float positionY = mediumBtn.transform.localPosition.y;
			Vector3 temp = sign.rectTransform.localPosition;
			temp.y = positionY;
			sign.rectTransform.localPosition = temp;
		}
		
		if (hardDifficulty == 1) {
			float positionY = hardBtn.transform.localPosition.y;
			Vector3 temp = sign.rectTransform.localPosition;
			temp.y = positionY;
			sign.rectTransform.localPosition = temp;
		}
		
	} // check difficulty

}
