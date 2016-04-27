using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public GameObject gameManager;

	public void CatchItem(int points){
		gameManager.GetComponent<ScorePoints> ().setplayer1Points (points);
	}

	public void PowerupSpeed() {
		StartCoroutine (SpeedRoutine());
	}

	public void PowerupIce() {
		StartCoroutine (IceRoutine());
	}

	IEnumerator SpeedRoutine(){
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (10f);
		print (Time.time);
		yield return new WaitForSeconds (4f);
		print (Time.time);
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (5f);
	}

	IEnumerator BombRoutine(){
		//TODO
		//dejar la bomba en el piso
		//luego de 1 seg romper todo al rededor
		return null;
	}

	IEnumerator IceRoutine(){
		//TODO
		//tirar objeto
		//cuando pega bajar velocidad a 0 del objetivo durante 2 segs
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (2f);
		print (Time.time);
		yield return new WaitForSeconds (3f);
		print (Time.time);
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (5f);
	}

}
