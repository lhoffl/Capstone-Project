using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Camera pacmanCamera;
	public Camera blinkyCamera;

	public PacmanMove pacman;
	public BlinkyMove blinky;

	// Use this for initialization
	void Start () {
		pacmanCamera.enabled = true;
		blinkyCamera.enabled = false;

		blinky.enabled = false;
		pacman.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			pacmanCamera.enabled = true;
			blinkyCamera.enabled = false;

			blinky.enabled = false;
			pacman.enabled = true;
		}
		if (Input.GetKeyDown ("2")) {
			pacmanCamera.enabled = false;
			blinkyCamera.enabled = true;

			blinky.enabled = true;
			pacman.enabled = false;
		}
	}
}