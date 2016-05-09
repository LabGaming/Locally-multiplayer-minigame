using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button : MonoBehaviour {

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
}
