using UnityEngine;
using System.Collections;

public class SpeedPowerup : PowerUp {

	public override void Effect(PlayerActions affected){
		//Set effect event for "affected" player
		Instantiator.Instance.SetSpeedPUEvent (affected);

		affected.activePowerUp = this.gameObject;
		//Destroy (this.gameObject);
	}

}
