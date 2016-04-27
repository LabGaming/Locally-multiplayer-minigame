using UnityEngine;
using System.Collections;

public class ShootIceBall : MonoBehaviour {

	[SerializeField]
	private float damage;
	public float speed;
	private Rigidbody2D myRigidBody;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponentInParent<Rigidbody2D> ();

		/*if (transform.rotation.y > 0) {
			myRigidBody.AddForce (Vector2.right * speed, ForceMode2D.Impulse);

		} else {
			myRigidBody.AddForce (Vector2.right * -speed, ForceMode2D.Impulse);
		}*/
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("ontriggerenter ice");
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myRigidBody.velocity = Vector2.zero; //stop moving this GO
			Destroy(gameObject);
			if (other.gameObject.tag == "Player") {
				other.gameObject.SendMessage ("PowerupIce");
			}
		}
	}

	public float getSpeed(){
		return speed;
	}


}
