using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {

	MovementController heroController;

	void Awake () {
		heroController = GetComponentInParent<MovementController> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Ground"){
			heroController.setGroundTouch (true);
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.gameObject.tag == "Ground"){
			heroController.setGroundTouch (true);
		}
	}
}
