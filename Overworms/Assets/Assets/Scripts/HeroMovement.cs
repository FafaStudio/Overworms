using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Q))//left
        {
            this.transform.Translate(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))//right
        {
            this.transform.Translate(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))//jump
        {
            this.transform.Translate(0, 1, 0);
        }
    }


}
