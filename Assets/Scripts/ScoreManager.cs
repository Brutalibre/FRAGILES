using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int _score = 0;
	public Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText.text = "Score : " + _score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/* 
	 * Add 100 points if critical, 50 point else. 
	 * Also add 50 points if the enemy dies.
	 */
	public void addPoints (bool isCrit) {
		_score += (isCrit ? 100 : 0);

		ScoreText.text = "Score : " + _score.ToString ();
	}
}
