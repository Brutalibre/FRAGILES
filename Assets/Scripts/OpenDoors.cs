using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

	public bool _entered;
	private Animator _anim;
	private AudioSource _sound;

	// Use this for initialization
	void Start () {
		_anim = GetComponentInChildren<Animator> ();
		_sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			_anim.SetBool ("Player_on_range", true);

			if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Closed"))
				_sound.Play ();
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Player") {
			_anim.SetBool ("Player_on_range", false);
		}
	}
}
