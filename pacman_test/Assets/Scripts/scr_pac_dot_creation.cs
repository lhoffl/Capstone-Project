using UnityEngine;
using System.Collections;

public class scr_pac_dot_creation : MonoBehaviour {

    public GameObject pac_dot;
    public GameObject[] dots;
    public Vector3 spawnSpot = new Vector3(2, 2, 0);
    private int x_pos = 0;
    private int y_pos = 0;
    private int i = 0;

    // Use this for initialization
    void Start () {
        //initialize array
        dots = new GameObject[1000];
        while(y_pos != 29)
        {
            //create dots
            dots[i] = (GameObject)Instantiate(pac_dot, new Vector3(x_pos + 2, y_pos + 2, 0), transform.rotation);
            i++;
            if(x_pos + 1 <= 25)
            {
                x_pos++;
            }else
            {
                x_pos = 0;
                y_pos++;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
