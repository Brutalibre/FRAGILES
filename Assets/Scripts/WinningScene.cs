using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using AssemblyCSharp;

public class WinningScene : MonoBehaviour {

	public Text PlayerScoreText, PlayerTimeText, TotalScoreText, SkipText;
	public int TimeMultiplier = 50;

	private int _totalScore;

	private bool _canSkip = false;

	// Use this for initialization
	void Start () {
		PlayerScoreText.text = PlayerStats.Score.ToString ();
		PlayerTimeText.text = PlayerStats.Time.ToString ();

		_totalScore = PlayerStats.Score + PlayerStats.Time * TimeMultiplier;

		TotalScoreText.text = _totalScore.ToString ();

		StartCoroutine(WaitForSecs(1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (_canSkip && Input.anyKeyDown) {
			SceneManager.LoadScene ("MenuScene");
		}
	}

	IEnumerator WaitForSecs(float seconds) {
		yield return new WaitForSeconds (seconds);
		_canSkip = true;
		SkipText.gameObject.SetActive(true);
	}
}
