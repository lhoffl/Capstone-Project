using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PacmanMove : MonoBehaviour
{
    public bool isActive = false;
    public float speed = 0.2f;
    Vector2 dest = Vector2.zero;
    string current_direction = "right";
    public readonly int superCount = 3;
    public Text countText;
    public Text winText;
    private int count;
    private int supersEaten = 0;
    private float speedTime = 5f;
    public readonly int SCORE_LIMIT = 100;
    public readonly float fastSpeed = 1f;
    private readonly float slowSpeed = .25f;
    public int player = 0;
    public GameObject camera_p1;
    public GameObject camera_p2;
    public GameObject camera_p3;
    public GameObject camera_p4;

	public GhostCollider blinky, pinky, clyde;

    private bool point_check = false;
    private new Vector3 lastPos;
    private bool charMove;

    void Start()
    {  
        count = 0;
        dest = transform.position;
        setCountText (count);
        winText.text = "";
        lastPos = transform.position;
    }


    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.CompareTag("pac_dot")){
			co.gameObject.SetActive(false);

            // This is the place to increment score if we wanted to
            //count++;
            setCountText (1);
        }

		if (co.gameObject.CompareTag ("super_pac_dot")) {
			co.gameObject.SetActive(false);
			pinky.setWeak (true);
			blinky.setWeak (true);
			clyde.setWeak (true);


            supersEaten ++;
            if (supersEaten >= superCount){
                isActive = true;
                speed = fastSpeed;
                speedTime = 5f;
                supersEaten = 0;
            }
		}
    }

    public void setCountText(int x){
        count += x;
        countText.text = ("Pacman Points: " + count.ToString ());
    }

    void FixedUpdate()
    { 
        //starting at random position
        if(point_check == false){
            int max_x = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().array_x_max;
            int max_y = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().array_y_max;
            while(point_check == false){
                int rand_x = Random.Range(0,max_x);
                int rand_y = Random.Range(0,max_y);
                if(!GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().obj[rand_x,rand_y].CompareTag("Block")){
                    this.transform.position = GameObject.Find("maze_block_starter").GetComponent<scr_maze_creation>().obj[rand_x,rand_y].transform.position;
                    point_check = true;
                }
            }
        }

        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // check first for new user input in any direction
        if (Input.GetKey (KeyCode.Joystick1Button3) && valid (Vector2.up)) {
            dest = (Vector2)transform.position + Vector2.up;
            current_direction = "up";
        }
		else if (Input.GetKey (KeyCode.Joystick1Button1) && valid (Vector2.right)) {
            dest = (Vector2)transform.position + Vector2.right;
            current_direction = "right";
        }
		else if (Input.GetKey (KeyCode.Joystick1Button0) && valid (-Vector2.up)){
            dest = (Vector2)transform.position - Vector2.up;
            current_direction = "down";
        }
		else if (Input.GetKey (KeyCode.Joystick1Button2) && valid (-Vector2.right)) {
            dest = (Vector2)transform.position - Vector2.right;
            current_direction = "left";
        }

        // if no user input is found, continue moving in the last requested direction
        else {
            if (current_direction.Equals("up") && valid (Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (current_direction.Equals("right") && valid (Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (current_direction.Equals("down") && valid (-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (current_direction.Equals("left") && valid (-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

        //reset camera position
        if(player == 1){
            camera_p1.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-60);
        }else if(player == 2){
            camera_p2.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-60);
        }else if(player == 3){
            camera_p3.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-60);
        }else if(player == 4){
            camera_p4.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-60);
        }
        if (isActive){
            speedTime -= Time.deltaTime;
            if (speedTime <= 0){
                    speed = slowSpeed;
                    isActive = false;
            }
        }

        //sound effects
        if(this.transform.position == lastPos){            
            this.GetComponent<AudioSource>().enabled = false;
        }else{
            this.GetComponent<AudioSource>().enabled = true;
        }
        lastPos = transform.position;
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    public Vector2 position()
    {
        return transform.position;
    }

//	public override void OnStartLocalPlayer()
//	{
//		gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
//	}
}
