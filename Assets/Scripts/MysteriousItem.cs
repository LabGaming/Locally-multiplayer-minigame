using UnityEngine;
using System.Collections;

public class MysteriousItem : MonoBehaviour {

	[SerializeField]
	private GameObject content;

	// Use this for initialization
	void Start () {
		content = Instantiator.Instance.GenerateRandomItem ();	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {

			//setear el item al jugador de alguna forma
			other.transform.GetComponent<PlayerActions>().CatchItem(content);
			GameObject.Destroy (this.gameObject);
		}
	}
}
