using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour {

	public void Effect(){
		StartCoroutine (SpeedRoutine());
	}

	IEnumerator SpeedRoutine(){
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (10f);
		print (Time.time);
		yield return new WaitForSeconds (4f);
		print (Time.time);
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (5f);
	}

	/*
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("PowerupSpeed");
			GameObject.Destroy (this.gameObject);
		}
	}*
}
