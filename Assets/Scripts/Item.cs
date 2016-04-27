using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int points=2; 

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("CatchItem", points);
			GameObject.Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("CatchItem", points);
			GameObject.Destroy (this.gameObject);
		}
	}

}
