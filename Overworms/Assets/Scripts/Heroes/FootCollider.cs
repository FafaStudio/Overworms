using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour {

	MovementController heroController;

	void Awake () {
		heroController = GetComponentInParent<MovementController> ();
	}
	
	/*void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			heroController.setGroundTouch (true);
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			heroController.setGroundTouch (false);
		}
	}*/

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

	/*void OnTriggerExit2D(Collider2D col) {
		if(col.gameObject.tag == "Ground"){
			heroController.setGroundTouch (false);
		}
	}*/
}
