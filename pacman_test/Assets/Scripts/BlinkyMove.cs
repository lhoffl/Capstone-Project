using UnityEngine;
using System.Collections;

public class BlinkyMove : MonoBehaviour
{
	public float speed = 0.3f;
	Vector2 dest = Vector2.zero;
	string current_direction = "right";

	void Start()
	{
		dest = transform.position;
	}

	void FixedUpdate()
	{	
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
}

