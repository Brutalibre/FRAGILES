using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	protected Animator _animator;
	public string CharacterTag = "NPC";

	protected List<AudioSource> _sounds;

	public float RangeMin = 0.7f;
	public float RangeMax = 1.3f;

	public virtual void Start () {
		// Initialize Object tags : also mark every children.
		tag = CharacterTag;

		foreach (Transform t in GetComponentsInChildren<Transform> ()) {
			if (t.tag == "Untagged")
				t.gameObject.tag = CharacterTag;
		}


		// Initialize sounds, and randomize "voice" (pitch).
		float randomPitch = Random.Range (RangeMin, RangeMax);
		Transform soundsFolder = transform.Find ("Sounds");
		_sounds = new List<AudioSource> ();

		foreach (Transform soundObject in soundsFolder) {
			AudioSource soundSource = soundObject.GetComponent<AudioSource> ();
			soundSource.pitch = randomPitch;

			_sounds.Add (soundSource);
		}

		// Initialize animators.
		_animator = GetComponent<Animator> ();
	}

	void Update () {
		
	}

	public virtual void GetPunched (bool critical) {
		if (!critical) {
			_animator.SetTrigger ("Hit");
		}
	}
}