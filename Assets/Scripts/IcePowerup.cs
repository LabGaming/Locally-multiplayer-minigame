using UnityEngine;
using System.Collections;

public class IcePowerup : PowerUp {
	
	public GameObject proyectile;
	
	public override void Effect(PlayerActions affected){
		//Instantiator.Instance.PowerUpIceBall ();
		Instantiator.Instance.SetIceBallPUEvent (affected);
		affected.activePowerUp = this.gameObject;
	}
}
