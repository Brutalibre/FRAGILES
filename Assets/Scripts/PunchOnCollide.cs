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


		if (_parentPunch._punchWillCollide && !_punchSound.isPlaying) {
			if (trig.tag == "Enemy" || trig.tag == "Critical") {
				EnemyBehaviour enemy = trig.GetComponentInParent<EnemyBehaviour> ();

				_punchSound.PlayOneShot (_punchSound.clip);

				bool isCrit = (trig.tag == "Critical");
				Debug.Log (isCrit);
				enemy.GetPunched (isCrit);
				FindObjectOfType<ScoreManager> ().UpdatePoints (true, isCrit);
			} else if (trig.tag == "NPC") {
				CharacterBehaviour npc = trig.GetComponentInParent<CharacterBehaviour> ();

				npc.GetPunched (false);
				FindObjectOfType<ScoreManager> ().UpdatePoints (false, false);
			}
		}
	}
}
