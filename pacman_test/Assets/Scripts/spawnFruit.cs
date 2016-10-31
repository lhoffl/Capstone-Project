using UnityEngine;
using System.Collections;
public class spawnFruit : MonoBehaviour {
    public bool isActive = true;
    public float timeLeft =5f;
    public GameObject fruit;

	// Use this for initialization
	void Start () {
        timeLeft = Random.Range(5f, 10f);
        fruit = GameObject.Find("pm_cherry");
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (isActive)
            {
                fruit.SetActive(false);
                isActive = false;
                timeLeft = Random.Range(5f, 10f);
            }
            else
            {
                fruit.SetActive(true);
                isActive = true;
                timeLeft = Random.Range(5f, 10f);
            }
        }
	}
}
