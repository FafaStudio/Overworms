using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    
	HeroManager hero;
	float heroSpeed;
	Rigidbody2D body;

	bool groundTouch;
	bool canJump;
	float timerSaut;
	public float CooldownSaut;
	public float coefficientSaut;


	void Start () {
		hero = GetComponent<HeroManager> ();
		body = GetComponent<Rigidbody2D> ();
		timerSaut = CooldownSaut;
		canJump=true;
	}

	void Update () {
		heroSpeed = hero.getCurMoveSpeed ();
		checkJump ();
		Jump ();
	}

	void FixedUpdate(){
		movement ();
	}

	private void checkJump(){
		if (!canJump) {
			timerSaut -= Time.deltaTime;
		}
		if (timerSaut <= 0f) {
			canJump = true;
			timerSaut = CooldownSaut;
		}
	}

	private void Jump(){
		if (groundTouch && canJump && (timerSaut <= 0 || timerSaut == CooldownSaut) && (Input.GetKey (KeyCode.Space))) {
			body.velocity = new Vector3 ();
			body.AddForce(new Vector2(0f, heroSpeed*coefficientSaut), ForceMode2D.Impulse);
			canJump = false;
			groundTouch = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			groundTouch = true;
		}
	}

	private void movement(){
		if (Input.GetKey (KeyCode.Q)) {
			body.velocity = new Vector2 (-heroSpeed*0.05f, body.velocity.y);
		} else if (Input.GetKey (KeyCode.D)) {
			body.velocity = new Vector2 (heroSpeed*0.05f, body.velocity.y);

		}
		else 
		{
			body.velocity = new Vector2 (0f, body.velocity.y);
		}
	}



}
