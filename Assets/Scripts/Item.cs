using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Item : MonoBehaviour {

	public int points=2;

	// Use this for initialization
	void Start () {
	}

	/*
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("CatchItem", points);
			GameObject.Destroy (this.gameObject);
		}
	}*/

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			var playerNumber = other.transform.GetComponent<Platformer2DUserControl> ().getPlayerNumber ();
			ScorePoints.Instance.CatchItem (playerNumber, points);
			//other.gameObject.SendMessage ("CatchItem", points);
			GameObject.Destroy (this.gameObject);
		}
	}

}
