using UnityEngine;
using System.Collections;

//this class controls the maze block sprite
public class scr_maze_block : MonoBehaviour {

	//creating vectors
	public Vector3 top;
	public Vector3 bot;
	public Vector3 right;
	public Vector3 left;
	public Vector3 top_right;
	public Vector3 top_left;
	public Vector3 bot_right;
	public Vector3 bot_left;

	//sprite detect array
	public int[] detect;
	
	//sprite renderer
	public SpriteRenderer sr;
	public Sprite parts_0;
	public Sprite parts_1;
	public Sprite parts_2;
	public Sprite parts_3;
	public Sprite parts_4;
	public Sprite parts_5;
	public Sprite parts_6;
	public Sprite parts_7;
	public Sprite parts_8;
	public Sprite parts_9;
	public Sprite parts_10;
	public Sprite parts_11;
	public Sprite parts_12;
	public Sprite parts_13;
	public Sprite parts_14;
	public Sprite parts_15;
	public Sprite parts_16;
	public Sprite parts_17;
	public Sprite parts_18;
	public Sprite parts_19;
	public Sprite parts_20;
	public Sprite parts_21;
	public Sprite parts_22;
	public Sprite parts_23;
	public Sprite parts_24;
	public Sprite parts_25;
	public Sprite parts_26;
	public Sprite parts_27;
	public Sprite parts_28;
	public Sprite parts_29;
	public Sprite parts_30;

	public float rad = 0;
	public Collider[] col;

	// Use this for initialization
	void Start () {

		//set vector 
		top = new Vector3 (transform.position.x + 1, transform.position.y + 3, 0);
		bot = new Vector3 (transform.position.x + 1, transform.position.y - 1, 0);
		right = new Vector3 (transform.position.x + 3, transform.position.y + 1, 0);
		left = new Vector3 (transform.position.x - 1, transform.position.y + 1, 0);
		top_right = new Vector3 (transform.position.x + 3, transform.position.y + 3, 0);
		top_left = new Vector3 (transform.position.x - 1, transform.position.y + 3, 0);
		bot_right = new Vector3 (transform.position.x + 3, transform.position.y - 1, 0);
		bot_left = new Vector3 (transform.position.x - 1, transform.position.y - 1, 0);

		//array
		detect = new int[8] {0,0,0,0,0,0,0,0};

		//sprite renderer
		sr = GetComponent<SpriteRenderer>();
		
		col = Physics.OverlapSphere (top, rad);

		//checking blocks adjacent to it
		foreach(Collider hit in col){
			if(hit.gameObject.transform != null){
				sr.sprite = parts_1;
			}
		}
		if (Physics.CheckSphere (bot, 1f)){
			detect[1] = 1;
		}
		if (Physics.CheckSphere (right, 1f)){
			detect[2] = 1;
		}
		if (Physics.CheckSphere (left, 1f)){
			detect[3] = 1;
		}
		if (Physics.CheckSphere (top_right, 1f)){
			detect[4] = 1;
		}
		if (Physics.CheckSphere (top_left, 1f)){
			detect[5] = 1;
		}
		if (Physics.CheckSphere (bot_right, 1f)){
			detect[6] = 1;
		}
		if (Physics.CheckSphere (bot_left, 1f)){
			detect[7] = 1;
		}

		/*
		//display new sprite
		if(detect[0] == 0 && detect[1] == 0 && detect[2] == 0 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_0;
		}else if(detect[0] == 1 && detect[1] == 0 && detect[2] == 0 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_3;
		}else if(detect[0] == 0 && detect[1] == 1 && detect[2] == 0 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_1;
		}else if(detect[0] == 0 && detect[1] == 0 && detect[2] == 1 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_4;
		}else if(detect[0] == 0 && detect[1] == 0 && detect[2] == 0 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_2;
		}else if(detect[0] == 0 && detect[1] == 0 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_5;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 0 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_6;
		}else if(detect[0] == 0 && detect[1] == 1 && detect[2] == 1 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_7;
		}else if(detect[0] == 0 && detect[1] == 1 && detect[2] == 0 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_8;
		}else if(detect[0] == 1 && detect[1] == 0 && detect[2] == 0 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_9;
		}else if(detect[0] == 1 && detect[1] == 0 && detect[2] == 1 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_10;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 0 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_11;
		}else if(detect[0] == 1 && detect[1] == 0 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_12;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 0 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_13;
		}else if(detect[0] == 0 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_14;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_15;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 0 && detect[6] == 1 && detect[7] == 0){
			sr.sprite = parts_16;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 1 && detect[7] == 1){
			sr.sprite = parts_17;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 1 && detect[6] == 0 && detect[7] == 1){
			sr.sprite = parts_18;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 1 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_19;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 0 && detect[6] == 1 && detect[7] == 1){
			sr.sprite = parts_20;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 1 && detect[6] == 1 && detect[7] == 1){
			sr.sprite = parts_21;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 1 && detect[6] == 1 && detect[7] == 0){
			sr.sprite = parts_22;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 1 && detect[6] == 0 && detect[7] == 1){
			sr.sprite = parts_23;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 0 && detect[6] == 0 && detect[7] == 1){
			sr.sprite = parts_24;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 1 && detect[6] == 1 && detect[7] == 0){
			sr.sprite = parts_25;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 1 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_26;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 0 && detect[6] == 0 && detect[7] == 0){
			sr.sprite = parts_27;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 1 && detect[7] == 0){
			sr.sprite = parts_28;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 0 && detect[5] == 0 && detect[6] == 0 && detect[7] == 1){
			sr.sprite = parts_29;
		}else if(detect[0] == 1 && detect[1] == 1 && detect[2] == 1 && detect[3] == 1 && detect[4] == 1 && detect[5] == 1 && detect[6] == 1 && detect[7] == 1){
			sr.sprite = parts_30;
		}
		*/
	}
	
	//testing gizmo
	void OnDrawGizmos(){
		top = new Vector3 (transform.position.x + 1, transform.position.y + 3, 0);
		bot = new Vector3 (transform.position.x + 1, transform.position.y - 1, 0);
		right = new Vector3 (transform.position.x + 3, transform.position.y + 1, 0);
		left = new Vector3 (transform.position.x - 1, transform.position.y + 1, 0);
		top_right = new Vector3 (transform.position.x + 3, transform.position.y + 3, 0);
		top_left = new Vector3 (transform.position.x - 1, transform.position.y + 3, 0);
		bot_right = new Vector3 (transform.position.x + 3, transform.position.y - 1, 0);
		bot_left = new Vector3 (transform.position.x - 1, transform.position.y - 1, 0);
		Gizmos.DrawWireSphere(top, rad);
		Gizmos.DrawWireSphere(bot, rad);
		Gizmos.DrawWireSphere(left, rad);
		Gizmos.DrawWireSphere(right, rad);
		Gizmos.DrawWireSphere(top_right, rad);
		Gizmos.DrawWireSphere(bot_right, rad);
		Gizmos.DrawWireSphere(top_left, rad);
		Gizmos.DrawWireSphere(bot_left, rad);
	}


	// Update is called once per frame
	void Update () {
		top = new Vector3 (transform.position.x + 1, transform.position.y + 3, 0);

		col = Physics.OverlapSphere (top, rad);

		sr = GetComponent<SpriteRenderer>();

		//checking blocks adjacent to it
		foreach(Collider hit in col){
			if(hit.gameObject.tag == "Block"){
				sr.sprite = parts_2;
			}
		}
	}
}
