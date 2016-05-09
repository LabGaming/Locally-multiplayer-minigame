using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	public GameObject proyectile;

	private float nextBulletTime;
	private int playerNumber;

	void Awake() {
		nextBulletTime = 0f;
		playerNumber = gameObject.transform.parent.GetComponent<Platformer2DUserControl>().getPlayerNumber();
	}

	// Update is called once per frame
	void Update () {

		if (playerNumber == 1 && Input.GetAxisRaw ("Fire1") > 0 && nextBulletTime < Time.time) {
			nextBulletTime = Time.time + timeBetweenBullets;

			Instantiator.Instance.PlayPUEffectPlayer1 ();
			//transform.GetComponentInParent<PlayerActions> ().UsePowerUp ();

			/*Vector2 rot = new Vector2 (0, 0);
			Object response = Instantiate(proyectile, gameObject.transform.position, Quaternion.Euler (rot));
			Rigidbody2D bulletRB = (response as GameObject).GetComponent<Rigidbody2D> ();
			float speed = (response as GameObject).GetComponentInChildren<ShootIceBall> ().getSpeed ();
			if (transform.parent.localScale.x > 0) {
				bulletRB.AddForce (Vector2.right * speed, ForceMode2D.Impulse);

			} else {
				bulletRB.AddForce (Vector2.right * -speed, ForceMode2D.Impulse);
			}*/
		}
		else if (playerNumber == 2 && Input.GetAxisRaw ("P2-Fire1") > 0 && nextBulletTime < Time.time) {

			//hacer como arriba (player1)
			nextBulletTime = Time.time + timeBetweenBullets;
			Instantiator.Instance.PlayPUEffectPlayer2 ();

			//deprecated
			/*
			Vector2 rot = new Vector2 (0, 0);
			Object response = Instantiate(proyectile, gameObject.transform.position, Quaternion.Euler (rot));
			Rigidbody2D bulletRB = (response as GameObject).GetComponent<Rigidbody2D> ();
			float speed = (response as GameObject).GetComponentInChildren<ShootIceBall> ().getSpeed ();
			if (transform.parent.localScale.x > 0) {
				bulletRB.AddForce (Vector2.right * speed, ForceMode2D.Impulse);

			} else {
				bulletRB.AddForce (Vector2.right * -speed, ForceMode2D.Impulse);
			}*/
		}
	}
}
