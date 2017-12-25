using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

	private Animator _anim;
	private AudioSource _wooshSound;

	public bool _punchWillCollide = false;

	public float PunchDelay = 0.5f;
	private float TimerShoot = 0.0f;

	private bool isPunching;
	private bool canPunch = true;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator> ();
		_wooshSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		TimerShoot += Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && TimerShoot > PunchDelay && canPunch) {
			TimerShoot = 0.0f;

			_anim.SetTrigger ("punching");

			_wooshSound.Play ();
			_punchWillCollide = true;
			StartCoroutine(OnCompleteAttackAnimation());
		}
	}

	IEnumerator OnCompleteAttackAnimation ()
	{
		yield return new WaitForSeconds(0.5f);
		_punchWillCollide = false;
	}

	public IEnumerator OnCompleteAttackAnimationInMenu () {
		yield return new WaitForSeconds(0.5f);
		canPunch = false;
	}
}
