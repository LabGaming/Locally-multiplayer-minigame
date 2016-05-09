using UnityEngine;
using System.Collections;

public class MysteriousItem : MonoBehaviour {

	[SerializeField]
	private GameObject content;

	// Use this for initialization
	void Start () {
		//generates a random powerUp from gameManager's list
		content = Instantiator.Instance.GenerateRandomItem ();	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {

			//setear el item al jugador de alguna forma
			//TODO
			GameObject contentGO = Instantiate(content);
			PowerUp contentPU = contentGO.GetComponent<PowerUp> ();
			contentPU.Effect(other.gameObject.GetComponent<PlayerActions>());
			//other.transform.GetComponent<PlayerActions>().CatchItem(contentPU);
			GameObject.Destroy (this.gameObject); //destruyo solo la caja, no el PU instanciado
		}
	}
}
