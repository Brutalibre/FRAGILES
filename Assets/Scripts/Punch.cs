using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

	private Animator[] _anims;
	private AudioSource _wooshSound;

	public bool _punchWillCollide = false;

	public float PunchDelay = 0.5f;
	private float TimerShoot = 0.0f;

	private bool isPunching;

	// Use this for initialization
	void Start () {
		_anims = GetComponentsInChildren<Animator> ();
		_wooshSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		TimerShoot += Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && TimerShoot > PunchDelay) {
			TimerShoot = 0.0f;

			foreach (var anim in _anims) {
				anim.SetTrigger ("punching");
			}

			_wooshSound.Play ();
			_punchWillCollide = true;
			StartCoroutine(OnCompleteAttackAnimation(_anims[0]));
		}
	}

	IEnumerator OnCompleteAttackAnimation(Animator anim)
	{
		// yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
		yield return new WaitForSeconds(0.5f);
		_punchWillCollide = false;
	}
}
