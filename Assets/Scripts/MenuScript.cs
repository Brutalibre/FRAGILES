﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	[Range(0, 3)] 
	private int _glovePosition = 0;

	public GameObject ImageFader;

	public float[] Positions = new float[3];

	private float previousPressed;

	public GameObject[] Characters = new GameObject[3];
	private Animator[] _animators = new Animator[3];

	private bool _canPunchAndMove = true;

	private AudioSource _whooshSound;

	// Use this for initialization
	void Start () {
		SetGlovePosition ();

		for (int i = 0; i < Characters.Length; i++) {
			_animators[i] = Characters[i].GetComponent<Animator> ();
		}

		AudioSource[] audios = GetComponents<AudioSource> ();
		foreach (AudioSource audio in audios) {
			if (audio.clip.name == "Announcement")
				audio.PlayDelayed (2.0f);
			else
				_whooshSound = audio;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");

		if (h != previousPressed && _canPunchAndMove) {
			if (h > 0) {
				_glovePosition = (_glovePosition < 2) ? _glovePosition + 1 : 0;
			} else if (h < 0) {
				_glovePosition = (_glovePosition > 0) ? _glovePosition - 1 : 2;
			}

			if (!_whooshSound.isPlaying) {
				_whooshSound.Play ();
			}

			SetGlovePosition ();
		}

		previousPressed = h;

		if (Input.GetButtonDown ("Fire1") && _canPunchAndMove) {
			_animators [_glovePosition].SetTrigger ("Hit");

			if (_glovePosition == 0 || _glovePosition == 2) {
				_canPunchAndMove = false;

				StartCoroutine (FadeAndChangeScene ());
				StartCoroutine (GetComponent<Punch> ().OnCompleteAttackAnimationInMenu ());
			}
		}
	}

	void SetGlovePosition () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, Positions [_glovePosition]);
	}

	IEnumerator FadeAndChangeScene () {
		Image img = ImageFader.GetComponent<Image> ();
		Color col = img.color;

		while (col.a < 1) {
			col.a += Time.deltaTime / 2;
			img.color = col;
			yield return null;
		}
			
		switch (_glovePosition) {
		case 0:
			AsyncOperation asyncLoad = SceneManager.LoadSceneAsync ("MainScene");
			while (!asyncLoad.isDone) {
				yield return null;
			}
			break;

		case 2:
			yield return null;
			Application.Quit ();
			break;

		default:
			break;
		}
	}
}
