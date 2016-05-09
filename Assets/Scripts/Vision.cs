using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

	private Collider2D vision;


	// Use this for initialization
	void Start () {
		vision = transform.GetComponent<BoxCollider2D> ();
	}
	
	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(Color.black, Color.white, 1f);
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(Color.white, Color.black, 1f);
		}
	}
}
