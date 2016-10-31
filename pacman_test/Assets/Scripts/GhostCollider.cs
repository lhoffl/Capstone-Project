using UnityEngine;
using System.Collections;

public class GhostCollider : MonoBehaviour {

	public Vector3 spawnPoint;

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman") {
			co.transform.position = spawnPoint;
		}

		else if (co.name != "maze") 
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), co);
		//decrease pacman's lives, show game over screen at this point
	}
}