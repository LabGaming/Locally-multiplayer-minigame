using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button : MonoBehaviour {

	#region public
	public GameObject settingsScreen;

	#endregion

	public void MainMenuScene(){
		SceneManager.LoadScene (0);
	}

	public void NextScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void CloseGame(){
		Application.Quit ();
	}

	public void AdjustSize(){
		//TODO
	}

	public void ShowScreen(GameObject screen){
		if (screen.activeSelf) {
			screen.SetActive (false);
		} else {
			screen.SetActive (true);
		}
	}

}
