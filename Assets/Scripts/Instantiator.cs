using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	public BoxCollider2D boundsCollider;
	public GameObject goToInstantiate;
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

		while(i<9){
			i++;
			var x = Random.Range (boundMin.x, boundMax.x);
			var y = Random.Range (boundMin.y, boundMax.y);
			var z = Random.Range (boundMin.z, boundMax.z);
			Vector3 position = new Vector3 (x, y, z);
			GameObject.Instantiate (goToInstantiate, position, transform.rotation);

		}
	}

	void Update () {

		if (gameTimer.getActualTime () >= timePerRound) {
			Time.timeScale = 0f;
		}

	}
	

}
