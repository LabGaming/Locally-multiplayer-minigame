using UnityEngine;
using UnityStandardAssets._2D;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public GameObject powerUp;

	public void CatchItem(GameObject content){
		powerUp = content;
	}

	IEnumerator BombRoutine(){
		//TODO
		//dejar la bomba en el piso
		//luego de 1 seg romper todo al rededor
		return null;
	}



	public void UsePowerUp(){

	}

}
