using UnityEngine;
using System.Collections;

public class spawnFruit : MonoBehaviour {
    public bool isActive = true;
    public float timeLeft =5f;
    public fruitMove moveScript;
    public GameObject cherry;
    GameObject fruit;
    public GameObject player;
    public AudioClip pacmanCherry;
    public PacmanMove pacman;

	// Use this for initialization
	void Start () {
        timeLeft = Random.Range(15f, 25f);
        cherry = (GameObject)Instantiate(cherry, new Vector3(29 , 13, 0), Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        cherry.SetActive(true);
        moveScript = cherry.GetComponent<fruitMove>();
    }
	
	// Update is called once per frame
	void Update () {
        float deltaX = 10;
        float deltaY = 10;
        timeLeft -= Time.deltaTime;

        deltaX = Mathf.Abs(cherry.transform.position.x - player.transform.position.x);
        deltaY = Mathf.Abs(cherry.transform.position.y - player.transform.position.y);
        

        if (deltaX < 2 && deltaY < 2 && isActive)
        {
            cherry.SetActive(false);
            isActive = false;
            pacman.setCountText(25);
            timeLeft = Random.Range(15f, 20f);
            cherry.transform.position = new Vector3(29, 13, 0);
            this.GetComponent<AudioSource>().PlayOneShot(pacmanCherry,0.7F);
            moveScript.reset();
        }


        if (timeLeft < 0)
        {
            if (isActive)
            {
                cherry.SetActive(false);
                isActive = false;
                timeLeft = Random.Range(5f, 10f);
            }
            else
            {
                cherry.SetActive(true);
                isActive = true;
                timeLeft = Random.Range(5f, 10f);
            }
        }
	}
}

