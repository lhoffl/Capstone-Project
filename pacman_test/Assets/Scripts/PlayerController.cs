using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Camera pacmanCamera;
	public Camera blinkyCamera;
	public Camera pinkyCamera;

	public PacmanMove pacman;
	public BlinkyMove blinky;
	public BlinkyMove pinky;

	// Use this for initialization
	void Start () {
		pacmanCamera.enabled = true;
		blinkyCamera.enabled = false;
		pinkyCamera.enabled = false;

		blinky.enabled = false;
		pacman.enabled = true;
		pinky.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			enableSelect ("pacman");
		}
		if (Input.GetKeyDown ("2")) {
			enableSelect ("blinky");
		}

		if (Input.GetKeyDown ("3")) {
			enableSelect ("pinky");
		}
	}

	void enableSelect(string player){

		blinky.enabled = blinkyCamera.enabled = false;
		pinky.enabled = pinkyCamera.enabled = false;
		pacman.enabled = pacmanCamera.enabled = false;
	
		switch (player) {
		case "pacman":
			pacman.enabled = true;
			pacmanCamera.enabled = true;
			break;
		case "blinky":
			blinky.enabled = true;
			blinkyCamera.enabled = true;
			break;
		case "pinky":
			pinky.enabled = true;
			pinkyCamera.enabled = true;
			break;
		default:
			pacmanCamera.enabled = true;
			pacman.enabled = true;
			break;
		}
	}
}