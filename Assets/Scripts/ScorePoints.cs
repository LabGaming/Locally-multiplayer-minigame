using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePoints : MonoBehaviour {

	//singleton instance
	private static ScorePoints instance = null;

	public int player1Score = 0;
	public Text player1UIScore;

	public int player2Score = 0;
	public Text player2UIScore;


	// This defines a static instance property that attempts to find the manager object in the scene and
	// returns it to the caller.
	public static ScorePoints Instance {
		get {
			if (instance == null) {
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				instance =  FindObjectOfType(typeof (ScorePoints)) as ScorePoints;
			}

			// If it is still null, create a new instance
			if (instance == null) {
				GameObject obj = new GameObject("ScorePoints");
				instance = obj.AddComponent(typeof (ScorePoints)) as ScorePoints;
				Debug.Log ("Could not locate an Instantiator object. ScorePoints was Generated Automaticly.");
			}
			return instance;
		}
	}

	//deprecated
	public void setplayer1Points(int points){
		player1Score += points;
		player1UIScore.text = player1Score.ToString();
	}

	public void CatchItem(int playerNumber, int points){
		if (playerNumber == 1) {
			player1Score += points;
			player1UIScore.text = player1Score.ToString();
		} else if (playerNumber == 2) {
			player2Score += points;
			player2UIScore.text = player2Score.ToString();
		}
	}
}
