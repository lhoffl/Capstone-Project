using UnityEngine;
using System.Collections;

public class eatFruit : MonoBehaviour {
    public GameObject cherry;
	// Use this for initialization
	void Start () {
        cherry = GameObject.Find("pm_cherry");
    }
	
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "pacman")
        {
            cherry.SetActive(false);
        }
    }
	
}
