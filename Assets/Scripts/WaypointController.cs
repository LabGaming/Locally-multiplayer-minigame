using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;

public class WaypointController : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] waypoints;
	public ProCamera2D procamera;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < players.Length ; i++) {
			Transform transform = PlacePlayerInWaypoint (i, i);
			procamera.AddCameraTarget (transform);
		}	
	}
	
	Transform PlacePlayerInWaypoint(int playerNumber, int waypointNumber){
		Object go = Instantiate (players [playerNumber], 
			waypoints [waypointNumber].transform.position, 
			waypoints [waypointNumber].transform.rotation);
		return (go as GameObject).transform;
	}
}
