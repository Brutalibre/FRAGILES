using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	protected Animator _animator;
	public string CharacterTag = "NPC";

	public List<string> SoundPaths;
	protected List<AudioSource> _sounds;

	public float RangeMin = 0.7f;
	public float RangeMax = 1.3f;

	void Reset () {
		SoundPaths.Add("Sounds/HurtSound");
	}

	public void Start () {
		// Initialize Object tags : also mark every children.
		tag = CharacterTag;

		foreach (Transform t in GetComponentsInChildren<Transform> ()) {
			if (t.tag == "Untagged")
				t.gameObject.tag = CharacterTag;
		}


		// Initialize sounds, and randomize "voice" (pitch).
		float randomPitch = Random.Range (RangeMin, RangeMax);

		Transform soundsFolder = transform.Find ("Sounds");
		foreach (Transform soundObject in soundsFolder) {
			AudioSource soundSource = GetComponent<AudioSource> ();
			soundSource.pitch = randomPitch;

			_sounds.Add (soundSource);
		}

		/*SoundPaths.ForEach (path => {
			AudioSource sound = gameO
				//transform.Find(path).GetComponent<AudioSource> ();
			sound.pitch = randomPitch;

			_sounds.Add(sound);
		});*/

		/* for (int i = 0; i <= SoundPaths.Count; i++) {
			_sounds.Add (transform.Find (SoundPaths.).GetComponent<AudioSource> ());
			_sounds [i].pitch = randomPitch;
		}*/

		// Initialize animators.
		_animator = GetComponent<Animator> ();
	}

	public void GetPunched (bool critical) {
		if (!critical) {
			_animator.SetTrigger ("Hit");
		}
	}
}