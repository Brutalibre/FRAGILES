using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchOnCollide : MonoBehaviour {

	private AudioSource _punchSound;
	private Punch _parentPunch;

	// Use this for initialization
	void Start () {
		_parentPunch = GetComponentInParent<Punch> ();
		_punchSound = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter (Collider col) {
		GameObject trig = col.gameObject;
		EnemyInit enemy = trig.GetComponentInParent<EnemyInit> ();


		if (_parentPunch._punchWillCollide 
			&& (trig.tag == "Enemy" || trig.tag == "Critical") 
			&& !_punchSound.isPlaying) {

			_punchSound.PlayOneShot (_punchSound.clip);

			bool isCrit = (trig.tag == "Critical");
			enemy.GetPunched (isCrit);
			FindObjectOfType<ScoreManager>().addPoints (isCrit);
		}
	}
}
