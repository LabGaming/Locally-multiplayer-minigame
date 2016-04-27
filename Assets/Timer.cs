using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	[SerializeField]
	private Text timeText;
	private float startTime;
	private float actualTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		actualTime = Time.time - startTime;
		timeText.text = actualTime.ToString("F0");
	}

	public float getActualTime(){
		return actualTime;
	}
}
