using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

	private Collider2D vision;
	public Material light;
	public Material dark;


	// Use this for initialization
	void Start () {
		vision = transform.GetComponent<BoxCollider2D> ();
	}
	
	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.white;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.black;
		}
	}
}
