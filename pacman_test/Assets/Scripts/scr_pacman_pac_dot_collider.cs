using UnityEngine;
using System.Collections;

public class scr_pacman_pac_dot_collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var pos = GameObject.Find("pacman").transform.position;
		transform.position = pos;
		//Physics2D.IgnoreCollision(pos.GetComponent<Collider2D>(),GetComponent<Collider2D>(),true);
	}
}
