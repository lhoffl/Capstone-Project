using UnityEngine;
using System.Collections;

public class GhostCollider : MonoBehaviour {

	public Vector3 spawnPoint;

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "pacman") {
			other.transform.position = spawnPoint;
			print ("hit");
		}
	}
}