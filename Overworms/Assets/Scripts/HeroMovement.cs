using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
    public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))//left
        {
            this.transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))//right
        {
            this.transform.Translate(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))//jump
        {
            this.transform.Translate(0, speed, 0);
        }
    }
}
