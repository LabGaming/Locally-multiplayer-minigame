using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>
///Basic Splash Screen, you need to extend it to implement background work.
/// This class cant reference scene 0.
///</summary>
public class SplashScreenDelayed : MonoBehaviour {

	public float delayTime = 5f;
	public int nextScene=0;
	public GameObject nextView;


	IEnumerator Start () {
		yield return new WaitForSeconds (delayTime);
		if (nextScene > 0) {
			LoadNextScene (nextScene);
		} else if (nextView != null) {
			DisplayView (nextView);
		} else {
			Debug.Log("fallo al cambiar de escena o vista");
		}
	}

	private void LoadNextScene(int nextScene){
		SceneManager.LoadScene (nextScene);
	}

	private void DisplayView(GameObject view){
		this.gameObject.SetActive (false);
		view.SetActive (true);
	}

}
