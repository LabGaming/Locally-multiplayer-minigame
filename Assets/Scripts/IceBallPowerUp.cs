using UnityEngine;
using System.Collections;

public class IceBallPowerUp : MonoBehaviour {

	[SerializeField]
	private float damage;
	public float speed;
	private Rigidbody2D myRigidBody;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

	}


	//TODO
	/*
	public override void Effect(PlayerActions affected){
		//Instantiator.Instance.PowerUpIceBall ();
		Instantiator.Instance.SetIceBallPUEvent (affected);
		affected.activePowerUp = this.gameObject;
	}*/


	//para cuando ya es lanzado y choca algo
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("iceballPowerUp.proyectile.ontriggerenter ice: "+ other.gameObject.ToString());
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable") ||
			other.gameObject.layer == LayerMask.NameToLayer ("Scenario")) {
			myRigidBody.velocity = Vector2.zero; //stop moving this GO
			Destroy(gameObject);
			if (other.gameObject.tag == "Player") {
				Instantiator.Instance.Freeze (other.gameObject);
			}
		}
	}

	public float getSpeed(){
		return speed;
	}
}
