using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	private int _time = 0;
	public Text TimeText;

	// Use this for initialization
	void Start () {
		TimeText.text = "Time : " + _time.ToString ();
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator timer () {
		yield return new WaitForSeconds (1);
		_time ++;
		TimeText.text = "Time : " + _time.ToString ();
	}
}
