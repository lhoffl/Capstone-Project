using UnityEngine;
using System.Collections;

public class scr_maze_creation : MonoBehaviour {

	//maze variables
	public string maze = "111111111111111111111111111111111111111111111:100000000000000000000000000000000000000000001:101111000000000000000000000000000000000111101:101000000000000000000000000000000000000000101:101000000000000000000000000000000000000000101:101000000000000000000000000000000000000000101:101000000000000000000000000000000000000000101:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:100000000000000000000000000000000000000000001:111111111111111111111111111111111111111111111:";
	public GameObject maze_block;
	public GameObject pac_dot;
	public GameObject[,] obj;
	private int x_pos = 0;
    private int y_pos = 0;
    private int i = 0;
    private int j = 0;
    private int array_x_max = 0;
    private int array_y_max = 0;
    public int[] b;

    //sprite variables
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
	public Sprite parts_31;
	public Sprite parts_32;
	public Sprite parts_33;
	public Sprite parts_34;
	public Sprite parts_35;
	public Sprite parts_36;
	public Sprite parts_37;
	public Sprite parts_38;
	public Sprite parts_39;
	public Sprite parts_40;
	public Sprite parts_41;
	public Sprite parts_42;
	public Sprite parts_43;
	public Sprite parts_44;
	public Sprite parts_45;
	public Sprite parts_46;

	// Use this for initialization
	void Start () {

		//getting array_x_max
		bool check = false;
		foreach(char c in maze){
			if(c != ':' && check == false){
				array_x_max++;
			}else{
				check = true;
			}
		}

		//getting array_y_max
		foreach(char c in maze){
			if(c == ':'){
				array_y_max++;
			}
		}

		obj = new GameObject[array_x_max,array_y_max];
		//read maze string and create maze
		foreach(char c in maze){
			//place block
			if(c == '1'){
				obj[i,j] = (GameObject)Instantiate(maze_block, new Vector3(x_pos, y_pos, 0), transform.rotation);
				i++;
				x_pos += 2;
			}else if(c == '0'){
				obj[i,j] = (GameObject)Instantiate(pac_dot, new Vector3(x_pos + 1, y_pos + 1, 0), transform.rotation);
				i++;
				x_pos += 2;
			}else if(c == ':'){
				i=0;
				j++;
				x_pos = 0;
				y_pos += 2;
			}
		}

		b = new int[8] {0,0,0,0,0,0,0,0};
		
		//update maze blocks
		for(int x = 0;x<array_x_max;x++){
			for(int y = 0;y<array_y_max;y++){
				if(obj[x,y].CompareTag("Block")){
					//checking surrounding blocks
					sr = obj[x,y].GetComponent<SpriteRenderer>();
					if(y+1<array_y_max){
						if(obj[x,y+1].CompareTag("Block")){
							b[0] = 1;
						}else{
							b[0] = 0;
						}
					}else{
						b[0] = 0;
					}
					if(y-1>=0){
						if(obj[x,y-1].CompareTag("Block")){
							b[1] = 1;
						}else{
							b[1] = 0;
						}
					}else{
						b[1] = 0;
					}
					if(x+1<array_x_max){
						if(obj[x+1,y].CompareTag("Block")){
							b[2] = 1;
						}else{
							b[2] = 0;
						}
					}else{
						b[2] = 0;
					}
					if(x-1>=0){
						if(obj[x-1,y].CompareTag("Block")){
							b[3] = 1;
						}else{
							b[3] = 0;
						}
					}else{
						b[3] = 0;
					}
					if(x+1<array_x_max && y+1<array_y_max){
						if(obj[x+1,y+1].CompareTag("Block")){
							b[4] = 1;
						}else{
							b[4] = 0;
						}
					}else{
						b[4] = 0;
					}
					if(x-1>=0 && y+1<array_y_max){
						if(obj[x-1,y+1].CompareTag("Block")){
							b[5] = 1;
						}else{
							b[5] = 0;
						}
					}else{
						b[5] = 0;
					}
					if(x+1<array_x_max && y-1>=0){
						if(obj[x+1,y-1].CompareTag("Block")){
							b[6] = 1;
						}else{
							b[6] = 0;
						}
					}else{
						b[6] = 0;
					}
					if(x-1>=0 && y-1>=0){
						if(obj[x-1,y-1].CompareTag("Block")){
							b[7] = 1;
						}else{
							b[7] = 0;
						}
					}else{
						b[7] = 0;
					}
					
					//display new sprite
					//single no blocks around
					if(b[0] == 0 && b[1] == 0 && b[2] == 0 && b[3] == 0 && b[4] == 0 && b[5] == 0 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_0;
					}
					//end pieces
					else if(b[0] == 0 && b[1] == 1 && b[2] == 0 && b[3] == 0){
						sr.sprite = parts_1;
					}else if(b[0] == 0 && b[1] == 0 && b[2] == 0 && b[3] == 1){
						sr.sprite = parts_2;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 0 && b[3] == 0){
						sr.sprite = parts_3;
					}else if(b[0] == 0 && b[1] == 0 && b[2] == 1 && b[3] == 0){
						sr.sprite = parts_4;
					}
					//long bar pieces
					else if(b[0] == 0 && b[1] == 0 && b[2] == 1 && b[3] == 1){
						sr.sprite = parts_5;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 0 && b[3] == 0){
						sr.sprite = parts_6;
					}
					//corner pieces
					else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[6] == 0){
						sr.sprite = parts_7;
					}else if(b[0] == 0 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[7] == 0){
						sr.sprite = parts_8;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 0 && b[3] == 1 && b[5] == 0){
						sr.sprite = parts_9;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 0 && b[4] == 0){
						sr.sprite = parts_10;
					}
					//T pieces
					else if(b[0] == 1 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[5] == 0 && b[7] == 0){
						sr.sprite = parts_11;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 0){
						sr.sprite = parts_12;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[4] == 0 && b[6] == 0){
						sr.sprite = parts_13;
					}else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_14;
					}
					//cross piece
					else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 0 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_15;
					}
					//other cross pieces
					else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 0 && b[6] == 1 && b[7] == 0){
						sr.sprite = parts_16;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 0 && b[6] == 1 && b[7] == 1){
						sr.sprite = parts_17;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 1 && b[6] == 0 && b[7] == 1){
						sr.sprite = parts_18;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_19;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 0 && b[6] == 1 && b[7] == 1){
						sr.sprite = parts_20;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 1 && b[6] == 1 && b[7] == 1){
						sr.sprite = parts_21;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1 && b[6] == 1 && b[7] == 0){
						sr.sprite = parts_22;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1 && b[6] == 0 && b[7] == 1){
						sr.sprite = parts_23;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 0 && b[6] == 0 && b[7] == 1){
						sr.sprite = parts_24;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 1 && b[6] == 1 && b[7] == 0){
						sr.sprite = parts_25;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 1 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_26;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 0 && b[6] == 0 && b[7] == 0){
						sr.sprite = parts_27;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 0 && b[6] == 1 && b[7] == 0){
						sr.sprite = parts_28;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 0 && b[6] == 0 && b[7] == 1){
						sr.sprite = parts_29;
					}
					//other T pieces
					else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[6] == 1 && b[7] == 0){
						sr.sprite = parts_30;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[4] == 1 && b[6] == 0){
						sr.sprite = parts_31;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 1 && b[4] == 0 && b[5] == 1){
						sr.sprite = parts_32;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[5] == 0 && b[7] == 1){
						sr.sprite = parts_33;
					}else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[6] == 0 && b[7] == 1){
						sr.sprite = parts_34;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[4] == 0 && b[6] == 1){
						sr.sprite = parts_35;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 0){
						sr.sprite = parts_36;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[5] == 1 && b[7] == 0){
						sr.sprite = parts_37;
					}
					//other corner pieces
					else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[6] == 1){
						sr.sprite = parts_38;
					}else if(b[0] == 0 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[7] == 1){
						sr.sprite = parts_39;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 0 && b[3] == 1 && b[5] == 1){
						sr.sprite = parts_40;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 0 && b[4] == 1){
						sr.sprite = parts_41;
					}
					//side bar pieces
					else if(b[0] == 0 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[6] == 1 && b[7] == 1){
						sr.sprite = parts_42;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 0 && b[4] == 1 && b[6] == 1){
						sr.sprite = parts_43;
					}else if(b[0] == 1 && b[1] == 0 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1){
						sr.sprite = parts_44;
					}else if(b[0] == 1 && b[1] == 1 && b[2] == 0 && b[3] == 1 && b[5] == 1 && b[7] == 1){
						sr.sprite = parts_45;
					}
					//blocks all around
					else if(b[0] == 1 && b[1] == 1 && b[2] == 1 && b[3] == 1 && b[4] == 1 && b[5] == 1 && b[6] == 1 && b[7] == 1){
						sr.sprite = parts_46;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
