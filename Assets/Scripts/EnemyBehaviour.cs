using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour {

	public float TotalHP = 3.0f;
	private float CurrentHP;

	// When component is added for the first time.
	void Reset() {
		SoundPaths.Add("Sounds/HurtSound");
		SoundPaths.Add("Sounds/DeathSound");
		SoundPaths.Add("Sounds/CritSound");

		CharacterTag = "Enemy";
	}

	// Use this for initialization
	void Start () {
		base.Start ();

		CurrentHP = TotalHP;
	}

	public void GetPunched (bool critical) {
		base.GetPunched (critical);

		if (critical) {
			CurrentHP -= 2;
			_animator.SetTrigger ("Critical");

			if (CurrentHP <= 0 /* and crit animation is over */) {
				_animator.SetTrigger ("Death");
			}
		}
	}

	void Die () {
		Destroy (gameObject);
	}

	public float getHealth () {
		return CurrentHP;
	}
}
