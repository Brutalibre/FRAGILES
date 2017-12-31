using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AssemblyCSharp;

public class ScoreManager : MonoBehaviour {

	private int _score = 0;
	public Text ScoreText;

	public int EnemyPoints = 100;
	public int NpcPoints = 50;

	// Use this for initialization
	void Start () {
		PlayerStats.Score = _score;
		ScoreText.text = "Score : " + _score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/* 
	 * Update the score : add points if enemy and crit, remove points if NPC.
	 * Do nothing in every other case (enemy not crit, etc).
	 */
	public void UpdatePoints (bool isEnemy, bool isCrit) {
		if (isEnemy && isCrit) {
			_score += EnemyPoints;
		} else if (!isEnemy) {
			_score -= NpcPoints;
		}

		ScoreText.text = "Score : " + _score.ToString ();
		PlayerStats.Score = _score;
	}
}
