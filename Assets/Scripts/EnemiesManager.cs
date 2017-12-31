using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesManager : MonoBehaviour {

	public List<GameObject> EnemiesContainers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (AllEnemiesAreDead ()) {
			SceneManager.LoadScene("WinningScene");
		}
	}

	bool AllEnemiesAreDead () {
		bool allDead = true;

		foreach (GameObject enemiesContainer in EnemiesContainers) {
			if (enemiesContainer.transform.childCount == 0) {
				allDead = allDead && true;
			} else {
				allDead = false;
			}
		}

		return allDead;
	}
}
