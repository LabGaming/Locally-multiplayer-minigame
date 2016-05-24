using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public GameObject activePowerUp;
	public int playerNumber;

	public PlayerInput inputConfig;

	void Start(){
		inputConfig = new PlayerInput (playerNumber);
	}

	//TODO
/*	public void CatchItem(PowerUp content){
		content.Effect ();

		powerUp = content;
		//PowerUpEvent = content.Effect();
	}

	public void UsePowerUp(){
		if (powerUp != null) {
			powerUp.Effect (this.gameObject);
			powerUp = null;
		}
	}*/

	public int getPlayerNumber(){
		return playerNumber;
	}

	public void setPlayerNumber(int number){
		playerNumber = number;
	}

	//Routines
	IEnumerator BombRoutine(){
		//TODO
		//dejar la bomba en el piso
		//luego de 1 seg romper todo al rededor
		return null;
	}

	public IEnumerator SpeedRoutine(){
		
		/*gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (10f);
		print ("PU-speed init"+ Time.time);
		yield return new WaitForSeconds (4f);
		print ("PU-speed init"+ Time.time);
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (5f);*/
		gameObject.GetComponentInParent<PlatformerMotor2D> ().groundSpeed = 16;
		print ("PU-speed init"+ Time.time);
		yield return new WaitForSeconds (4f);
		print ("PU-speed init"+ Time.time);
		gameObject.GetComponentInParent<PlatformerMotor2D> ().groundSpeed = 8;


		//empty powerups for this player, he already used it
		Destroy (activePowerUp);
	}

	public IEnumerator IceBallRoutine(){

		Vector2 rot = new Vector2 (0, 0);
		GameObject proyectil = activePowerUp.GetComponent<IcePowerup>().proyectile;
		Transform proyectilTransform = transform.FindChild ("Proyector").transform;
		Object response = Instantiate(proyectil, proyectilTransform.position, Quaternion.Euler (rot));
		(response as GameObject).GetComponent<SpriteRenderer> ().enabled = true;
		Rigidbody2D bulletRB = (response as GameObject).GetComponent<Rigidbody2D> ();
		float speed = (response as GameObject).GetComponent<IceBallPowerUp> ().getSpeed ();
		if (transform.localScale.x > 0) {
			bulletRB.AddForce (Vector2.right * speed, ForceMode2D.Impulse);

		} else {
			bulletRB.AddForce (Vector2.right * -speed, ForceMode2D.Impulse);
		}
		yield return null;
	}

	IEnumerator IceRoutine(){
		//TODO
		//tirar objeto
		//cuando pega bajar velocidad a 0 del objetivo durante 2 segs
		/*gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (2f);
		print (Time.time);
		yield return new WaitForSeconds (3f);
		print (Time.time);
		gameObject.GetComponentInParent<PlatformerCharacter2D> ().setMaxSpeed (5f);*/
		return null;
	}

}
