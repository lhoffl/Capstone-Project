using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PacmanMove : NetworkBehaviour
{
    public float speed = 0.3f;
    Vector2 dest = Vector2.zero;
    string current_direction = "right";

    public Text countText;
    public Text winText;
    private int count;
    public readonly int SCORE_LIMIT = 100;

    void Start()
    {
        count = 0;
        dest = transform.position;
       // setCountText ();
       // winText.text = "";
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.CompareTag("pac_dot")){
			co.gameObject.SetActive(false);

            // This is the place to increment score if we wanted to
           // count++;
           // setCountText ();
        }
    }

//    void setCountText(){
//
//        countText.text = ("Points: " + count.ToString ());
//        if (count >= SCORE_LIMIT)
//            winText.text = "You Won!";
//    }

    void FixedUpdate()
    {   
		if (!isLocalPlayer)
			return;


        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // check first for new user input in any direction
        if (Input.GetKey (KeyCode.UpArrow) && valid (Vector2.up)) {
            dest = (Vector2)transform.position + Vector2.up;
            current_direction = "up";
        }
        else if (Input.GetKey (KeyCode.RightArrow) && valid (Vector2.right)) {
            dest = (Vector2)transform.position + Vector2.right;
            current_direction = "right";
        }
        else if (Input.GetKey (KeyCode.DownArrow) && valid (-Vector2.up)){
            dest = (Vector2)transform.position - Vector2.up;
            current_direction = "down";
        }
        else if (Input.GetKey (KeyCode.LeftArrow) && valid (-Vector2.right)) {
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
