using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
	[Range(0, 3)] 
	private int _glovePosition = 0;

	public float[] Positions = new float[3];

	private float previousPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");

		if (h != previousPressed) {
			if (h > 0) {
				_glovePosition = (_glovePosition < 2) ? _glovePosition + 1 : 0;
			} else if (h < 0) {
				_glovePosition = (_glovePosition > 0) ? _glovePosition - 1 : 2;
			}

			SetGlovePosition ();
		}

		previousPressed = h;
	}

	void SetGlovePosition () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, Positions [_glovePosition]);
	}
}
