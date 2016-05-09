using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

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
		placeGems (10);
		InvokeRepeating ("GenerateMysteriousBox", 0f, 4f);
	}

	void Update () {

		if (gameTimer.getActualTime () >= timePerRound) {
			Time.timeScale = 0f;
			CanvasManager.Instance.ShowMainMenuPanel (true);
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

	public void placeGems(int numberofObjects) {
		
		Vector3 position = RandomVector ();
		//Vector3 position = new Vector3 (x, y, z);

		GameObject.Instantiate (cowToInstantiate, position, transform.rotation);
		var radius = 4f;
		Vector3 pos;
		for (int i = 0; i < numberofObjects; i++) {
			pos =bounds.max + new Vector3 (9f, 9f, 9f);
			float angle = i * Mathf.PI * 2 / numberofObjects;
			while (!bounds.Contains (pos)) {
				Debug.Log ("!");
				pos = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) 
					* radius + position + VectorDisplacement (radius);
			}
			GameObject.Instantiate (goToInstantiate, pos, Quaternion.identity);
		}
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

	private Vector3 VectorDisplacement(float radius) {
		var x = Random.Range (-(radius+1), radius+1);
		var y = Random.Range (-(radius+1), (radius+1));
		return new Vector3 (x, y, 0);
	}

	public GameObject GenerateRandomItem(){
		var powerUpIndex = (int) Random.Range (0f, powerups.Length);
		return powerups [powerUpIndex];
	}


	//--------------
	public delegate IEnumerator PowerUpEffect();
	public event PowerUpEffect PowerUpEvent;
	public event PowerUpEffect PowerUpEventP2;

	public void PlayPUEffectPlayer1(){
		if (PowerUpEvent != null) {
			StartCoroutine (PowerUpEvent ());
			PowerUpEvent = null;
		}
	}

	public void PlayPUEffectPlayer2(){
		if (PowerUpEventP2 != null) {
			StartCoroutine (PowerUpEventP2 ());
			PowerUpEventP2 = null;
		}
	}

	public void SetSpeedPUEvent(PlayerActions playerActions){
		//ver como solucionar que target es el correcto
		if (playerActions.gameObject.GetComponent<Platformer2DUserControl> ().getPlayerNumber () == 1) {
			PowerUpEvent = playerActions.SpeedRoutine;
		} else if (playerActions.gameObject.GetComponent<Platformer2DUserControl> ().getPlayerNumber () == 2) {
			PowerUpEventP2 = playerActions.SpeedRoutine;
		}
	}

	/*
	public IEnumerator SpeedRoutine(){
		PowerUpEvent -= SpeedRoutine;
		player.GetComponent<PlatformerCharacter2D> ().setMaxSpeed (10f);
		print ("PU-speed init"+ Time.time);
		yield return new WaitForSeconds (4f);
		print ("PU-speed init"+ Time.time);
		player.GetComponent<PlatformerCharacter2D> ().setMaxSpeed (5f);
	}*/

	public void SetIceBallPUEvent(PlayerActions playerActions){
		if (playerActions.gameObject.GetComponent<Platformer2DUserControl> ().getPlayerNumber () == 1) {
			PowerUpEvent = playerActions.IceBallRoutine;
		} else if (playerActions.gameObject.GetComponent<Platformer2DUserControl> ().getPlayerNumber () == 2) {
			PowerUpEventP2 = playerActions.IceBallRoutine;
		}
	}

	//deprecated
	public IEnumerator IceBallRoutine(){

		Vector2 rot = new Vector2 (0, 0);
		GameObject proyectil = powerups [1];
		Transform proyectilTransform = player.transform.FindChild ("Proyector").transform;
		Object response = Instantiate(proyectil, proyectilTransform.position, Quaternion.Euler (rot));
		(response as GameObject).GetComponent<SpriteRenderer> ().enabled = true;
		Rigidbody2D bulletRB = (response as GameObject).GetComponent<Rigidbody2D> ();
		float speed = (response as GameObject).GetComponent<IceBallPowerUp> ().getSpeed ();
		if (player.transform.localScale.x > 0) {
			bulletRB.AddForce (Vector2.right * speed, ForceMode2D.Impulse);

		} else {
			bulletRB.AddForce (Vector2.right * -speed, ForceMode2D.Impulse);
		}
		yield return null;
	}

	public void Freeze(GameObject player){
		StartCoroutine (FreezeRoutine(player));
	}

	IEnumerator FreezeRoutine(GameObject player){
		//TODO
		//tirar objeto
		//cuando pega bajar velocidad a 0 del objetivo durante 2 segs
		player.GetComponent<PlatformerCharacter2D> ().setMaxSpeed (2f);
		print ("PU-Ice"+Time.time);
		yield return new WaitForSeconds (3f);
		print ("PU-Ice"+Time.time);
		player.GetComponent<PlatformerCharacter2D> ().setMaxSpeed (5f);
	}

}
