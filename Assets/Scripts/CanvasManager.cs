using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	private static CanvasManager instance;

	public GameObject mainMenuButton;

	public static CanvasManager Instance {
		get {
			if (instance == null) {
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				instance =  FindObjectOfType(typeof (CanvasManager)) as CanvasManager;
			}

			// If it is still null, create a new instance
			if (instance == null) {
				GameObject obj = new GameObject("Canvas");
				instance = obj.AddComponent(typeof (CanvasManager)) as CanvasManager;
				Debug.Log ("Could not locate an CanvasManager object. CanvasManager was Generated Automaticly.");
			}
			return instance;
		}
	}

	public void ShowMainMenuPanel(bool show){
		mainMenuButton.SetActive (show);
	}

}
