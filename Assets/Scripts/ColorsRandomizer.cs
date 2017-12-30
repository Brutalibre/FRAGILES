using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsRandomizer : MonoBehaviour {

	public string MaterialToColor = "Skin";
	public Color ForcedColor = new Color (1, 0, 1, 0);
	public Color[] RangeOfColors;

	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, RangeOfColors.Length);
		Color randomColor = RangeOfColors[rand];

		Renderer[] meshRs = GetComponentsInChildren<Renderer> ();

		foreach (Renderer meshR in meshRs) {
			Material[] mats = meshR.materials;

			foreach (Material mat in mats) {
				if (mat.name.Contains(MaterialToColor)) {
					if (ForcedColor.Equals (new Color(1, 0, 1, 0))) {
						mat.color = randomColor;
					} else { 
						mat.color = ForcedColor;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
