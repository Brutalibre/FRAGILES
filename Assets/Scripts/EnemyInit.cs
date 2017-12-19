using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInit : MonoBehaviour {

	public float TotalHP = 3.0f;
	private float CurrentHP;

	private AudioSource _painSound;
	private AudioSource _critSound;
	private AudioSource _deathSound;

	private Animator _critAnim;

	public float RangeMin = 0.7f;
	public float RangeMax = 1.3f;

	// Use this for initialization
	void Start () {
		// Initialize Object tags : mark every children as "Enemy".
		tag = "Enemy";

		foreach (Transform t in GetComponentsInChildren<Transform> ()) {
			if (t.tag == "Untagged")
				t.gameObject.tag = "Enemy";
		}

		CurrentHP = TotalHP;

		// Initialize sounds, and randomize "voice" (pitch).
		_painSound = transform.Find("Sounds/HurtSound").GetComponent<AudioSource> ();
		_critSound = transform.Find("Sounds/CritSound").GetComponent<AudioSource> ();
		_deathSound = transform.Find("Sounds/DeathSound").GetComponent<AudioSource> ();

		float randomPitch = Random.Range (RangeMin, RangeMax);
		_painSound.pitch = randomPitch;
		_critSound.pitch = randomPitch;
		_deathSound.pitch = randomPitch;

		// Initialize animators.
		_critAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetPunched (bool critical) {

		if (CurrentHP > 0) {
			if (critical) {
				CurrentHP -= 2;
				_critAnim.SetTrigger ("Critical");

				if (CurrentHP > 0) {
					_critSound.Play ();
				}
			} else {
				CurrentHP--;

				if (CurrentHP > 0) {
					_painSound.Play ();
				}
			} 
		}

		if (CurrentHP <= 0) {
			StartCoroutine (Die ());
		}

	}

	IEnumerator Die () {
		_deathSound.Play ();

		foreach (Transform t in GetComponentsInChildren<Transform> ()) {
			if (t.tag == "Enemy" && t != transform) {
				t.gameObject.SetActive (false);
			}
		}

		yield return new WaitWhile (() => _deathSound.isPlaying);

		Destroy (gameObject);
	}

	public float getHealth () {
		return CurrentHP;
	}
}
