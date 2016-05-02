using UnityEngine;
using System.Collections;

public class Gamepads : MonoBehaviour {

	[SerializeField]
	public GamepadConfig[] gamepads;
	public string[] joys;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		joys = Input.GetJoystickNames ();
	}


	public void SetButton(string key){
		gamepads [0].jumpKey = key;
	}

	public void ReadAndSetButton(){
		

		gamepads [0].jumpKey = Input.inputString;
	}
}
