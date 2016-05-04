using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	//singleton instance
	private static Instantiator instance = null;

	public BoxCollider2D boundsCollider;
	public GameObject goToInstantiate;
	public GameObject cowToInstantiate;
	public GameObject[] powerups;
	private Bounds bounds;
	int i = 0;

	public float timePerRound;
	public Timer gameTimer;

	public GameObject player;
	public Camera cam;

	public GameObject mysteriousBox;



	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static Instantiator Instance {
		get {
			if (instance == null) {
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				instance =  FindObjectOfType(typeof (Instantiator)) as Instantiator;
			}

			// If it is still null, create a new instance
			if (instance == null) {
				GameObject obj = new GameObject("Instantiator");
				instance = obj.AddComponent(typeof (Instantiator)) as Instantiator;
				Debug.Log ("Could not locate an Instantiator object. Instantiator was Generated Automaticly.");
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		bounds.SetMinMax (boundsCollider.bounds.min, boundsCollider.bounds.max);
		Time.timeScale = 0f;
		placeGems ();
		InvokeRepeating ("GenerateMysteriousBox", 0f, 2f);
	}

	void Update () {

		if (gameTimer.getActualTime () >= timePerRound) {
			Time.timeScale = 0f;
		}
		//si no intersecta
		/*if (!bounds.Intersects (player.GetComponent<BoxCollider2D> ().bounds)) {
			Vector3 targetPos = player.transform.position + new Vector3 (0f, 0f, -1f); 
			cam.transform.position = Vector3.Lerp (cam.transform.position, targetPos, 0.5f);
			
		} else {
			//reset position
			cam.transform.position = new Vector3(12.5f, 5f, -0.5f);
		}*/
	}

	public void placeGems() {
		
		Vector3 position = RandomVector ();
		//Vector3 position = new Vector3 (x, y, z);

		GameObject.Instantiate (cowToInstantiate, position, transform.rotation);
		var numberofObjects = 10;
		var radius = 1f;
		for (int i = 0; i < numberofObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberofObjects;
			Vector3 pos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * radius + position + VectorDisplacement();
			GameObject.Instantiate (goToInstantiate, pos, Quaternion.identity);
			//checkear que no se instancie fuera de los bordes
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

	void GenerateMysteriousBox(){
		Vector3 position = RandomVector ();
		GameObject.Instantiate (mysteriousBox, position, transform.rotation);
	}

	private Vector3 RandomVector() {
				var x = Random.Range (bounds.min.x, bounds.max.x);
				var y = Random.Range (bounds.min.y, bounds.max.y);
				var z = Random.Range (bounds.min.z, bounds.max.z);
		return new Vector3 (x, y, z);
	}

	private Vector3 VectorDisplacement() {
		var x = Random.Range (-1f, 6f);
		var y = Random.Range (-1f, 6f);
		return new Vector3 (x, y, 0);
	}

	public GameObject GenerateRandomItem(){
		var powerUpIndex = (int) Random.Range (0f, powerups.Length);
		return powerups [powerUpIndex];
	}


}
