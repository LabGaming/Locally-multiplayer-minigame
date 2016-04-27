using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage ("PowerupSpeed");
			GameObject.Destroy (this.gameObject);
		}
	}
}
