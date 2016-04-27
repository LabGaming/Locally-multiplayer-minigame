using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	public BoxCollider2D boundsCollider;
	public GameObject goToInstantiate;
	public GameObject cowToInstantiate;
	private Vector3 boundMin;
	private Vector3 boundMax;
	int i = 0;

	public float timePerRound;
	public Timer gameTimer;

	// Use this for initialization
	void Start () {
		boundMin = 	boundsCollider.bounds.min;
		boundMax = boundsCollider.bounds.max;
		Time.timeScale = 0f;
		placeGems ();
	}

	void Update () {

		if (gameTimer.getActualTime () >= timePerRound) {
			Time.timeScale = 0f;
		}

	}

	public void placeGems(){
		
		Vector3 position = RandomVector ();
		//Vector3 position = new Vector3 (x, y, z);

		GameObject.Instantiate (cowToInstantiate, position, transform.rotation);
		var numberofObjects = 50;
		var radius = 1f;
		for (int i = 0; i < numberofObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberofObjects;
			Vector3 pos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * radius + position + VectorDisplacement();
			GameObject.Instantiate (goToInstantiate, pos, Quaternion.identity);
		}
		/*while(i<9){
			i++;
			var x = Random.Range (position.x, boundMax.x);
			var y = Random.Range (boundMin.y, boundMax.y);
			var z = Random.Range (boundMin.z, boundMax.z);
			Vector3 position = new Vector3 (x, y, z);
			GameObject.Instantiate (goToInstantiate, position, transform.rotation);
		}		*/
	}

	private Vector3 RandomVector(){
		var x = Random.Range (boundMin.x, boundMax.x);
		var y = Random.Range (boundMin.y, boundMax.y);
		var z = Random.Range (boundMin.z, boundMax.z);
		return new Vector3 (x, y, z);
	}

	private Vector3 VectorDisplacement(){
		var x = Random.Range (-1f, 5f);
		var y = Random.Range (-1f, 5f);
		return new Vector3 (x, y, 0);
	}


}
