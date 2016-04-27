using UnityEngine;
using System.Collections;

public class ScreenAdjustment : MonoBehaviour {

	private Camera camera;
	private GameObject button;
	private static bool stopupdate = false;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Camera").GetComponent<Camera>();	
	}
	
	// Update is called once per frame
	void Update () {
		//if (!stopupdate) {
		//	camera.orthographicSize += 0.05f;	

		//}
	}

	public void StopUpdate(){
		stopupdate = true;
	}

	public void CameraSize(bool more) {
		if (more) {
			camera.orthographicSize += 0.1f;
		} else {
			camera.orthographicSize -= 0.1f;
		}
	}

	public void AcceptSize(){
		transform.parent.gameObject.SetActive (false);
		Time.timeScale = 1f;
	}

}
