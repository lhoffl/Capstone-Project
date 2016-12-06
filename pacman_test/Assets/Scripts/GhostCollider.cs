using UnityEngine;
using System.Collections;

public class GhostCollider : MonoBehaviour {

	public Vector3 spawnPoint;
	public bool weak = false;
	public int timeLeft = 300;
	public AudioClip eatGhost;
	public AudioClip pacmanDie;
	public AudioClip pacmanBegin;
	private bool soundCheck = false;
	public BlinkyMove blinky;
	public PinkyMove pinky;
	public ClydeMove clyde;

	public void setWeak(bool w){
		weak = w;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "pacman") {
			int max_x = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().array_x_max;
			int max_y = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().array_y_max;
			bool point_check = false;
			while(point_check == false){
				int rand_x = Random.Range(0,max_x);
				int rand_y = Random.Range(0,max_y);
				if(!GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().obj[rand_x,rand_y].CompareTag("Block")){
					spawnPoint = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().obj[rand_x,rand_y].transform.position;
					point_check = true;
				}
			}

			
			if (weak) {
				transform.position = spawnPoint;
				this.GetComponent<AudioSource>().PlayOneShot(eatGhost,0.7F);
			}
			else {
				other.transform.position = spawnPoint;
				print ("hit");
				//GameObject.Find("blinky").GetComponent<BlinkyMove>().setBlinkyText();
				this.GetComponent<AudioSource>().PlayOneShot(pacmanDie,0.7F);

				if (gameObject.name == "blinky") {
					blinky.setBlinkyText (50);
				} else if (gameObject.name == "pinky") {
					pinky.setPinkyText (50);
				} else
					clyde.setClydeText (50);
			}
		}
	}

	private void Update(){
		//playing begining sound once
		if(soundCheck == false){
			this.GetComponent<AudioSource>().PlayOneShot(pacmanBegin,0.7F);
			soundCheck = true;
		}

		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		if (weak == true) {
			renderer.color = new Color(0, 1, 0);
			timeLeft -= 1;
		}

		if (weak == true && timeLeft < 0)
		{
			setWeak (false);
			timeLeft = 300;
		}

		if (weak != true) {
			renderer.color = new Color(1, 0, 0);
		}
	}
}