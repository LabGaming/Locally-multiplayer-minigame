using UnityEngine;
using System.Collections;

[System.Serializable]
public class GamepadConfig {

	public string jumpKey;

	[SerializeField]
	private string fireKey { get; set; }

	public void SetJumpKey(string key){
		jumpKey = key;
	}


}
