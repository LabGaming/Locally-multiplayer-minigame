using UnityEngine;
using System.Collections;

public class Vision : MonoBehaviour {

	private Collider2D vision;
	private Color colorHide = new Color(0.1f, 0.1f, 0.1f, 0.15f);
	private Color colorShow = new Color(0.9f, 0.9f, 0.9f, 1f);

	// Use this for initialization
	void Start () {
		vision = transform.GetComponent<BoxCollider2D> ();
	}
	
	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(colorHide, colorShow, 1f);
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.tag == "Item") {
			other.transform.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(colorShow, colorHide, 1f);
		}
	}
}
