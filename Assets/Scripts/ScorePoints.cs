using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePoints : MonoBehaviour {

	public int player1Score = 0;
	public Text player1UIScore;

	public void setplayer1Points(int points){
		player1Score += points;
		player1UIScore.text = player1Score.ToString();
	}
}
