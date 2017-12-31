using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CharacterBehaviour {

	public float TotalHP = 3.0f;
	private float CurrentHP;

	// Use this for initialization
	public override void Start () {
		base.Start ();

		CurrentHP = TotalHP;
	}

	public override void GetPunched (bool critical) {
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
		Destroy (transform.parent.gameObject);
	}

	public float getHealth () {
		return CurrentHP;
	}
}
