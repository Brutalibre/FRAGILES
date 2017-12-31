using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using AssemblyCSharp;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeManager : MonoBehaviour {

	private int _time;
	public Text TimeText;

	public Canvas GameOverScreen;
	public Text SkipText, ScoreText;
	private bool _canSkip = false;

	public int TimeLimitInSeconds = 60;
	public Color EmergencyTextColor;
	private AudioSource _emergencySound;

	// Use this for initialization
	void Start () {
		_time = TimeLimitInSeconds;
		TimeText.text = "Time : " + _time.ToString ();
		StartCoroutine (Timer ());

		_emergencySound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (_time == 0) {
			_time = -1;

			StopAllCoroutines ();

			// Disable player controls
			GetComponent<RigidbodyFirstPersonController> ().enabled = false;
			GetComponentInChildren<Punch> ().enabled = false;

			// Disable score and time canvas
			TimeText.GetComponentInParent<Canvas> ().enabled = false;

			// Enable dark overlay with score and time
			GameOverScreen.GetComponent<Animator> ().SetTrigger ("FadeIn");
			ScoreText.text = PlayerStats.Score.ToString ();

			// After x seconds, the player can go back to menu.
			StartCoroutine (WaitForSecs(1.0f));
		}

		if (_canSkip && Input.anyKeyDown) {
			SceneManager.LoadScene ("MenuScene");
		}
	}

	IEnumerator Timer () {
		yield return new WaitForSeconds (1);

		_time --;
		TimeText.text = "Time : " + _time.ToString ();
		PlayerStats.Time = _time;

		if (_time == 10) {
			TimeText.color = EmergencyTextColor;
		}

		if (_time <= 10) {
			_emergencySound.Play ();
		}

		StartCoroutine (Timer ());
	}

	IEnumerator WaitForSecs(float seconds) {
		yield return new WaitForSeconds (seconds);
		_canSkip = true;
		SkipText.gameObject.SetActive(true);
	}
}
