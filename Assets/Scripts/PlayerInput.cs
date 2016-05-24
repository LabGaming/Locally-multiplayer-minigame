using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public int PLAYER_NUMBER = 1;
	public string HORIZONTAL;
	public string VERTICAL;
	public string JUMP;
	public string DASH;
	public string SPECIAL;

	public PlayerInput(int playerNumber){
		PLAYER_NUMBER = playerNumber;
		HORIZONTAL = "P"+PLAYER_NUMBER + "Horizontal";
		VERTICAL = "P" + PLAYER_NUMBER + "Vertical";
		JUMP = "P" + PLAYER_NUMBER + "Jump";
		DASH = "P" + PLAYER_NUMBER +"Fire1";
		SPECIAL = "P" + PLAYER_NUMBER + "Fire2";
	}
}
