using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    
	HeroManager hero;
	float heroSpeed;
	Rigidbody2D body;
	SpriteRenderer sprite;

	bool groundTouch;
	bool canJump;
	float timerSaut;
	public float CooldownSaut;
	public float coefficientSaut;

	public float enduranceSaut;
	public float enduranceMovement;


	void Start () {
		hero = GetComponent<HeroManager> ();
		body = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		timerSaut = CooldownSaut;
		canJump=true;
	}

	void Update () {
		heroSpeed = hero.getCurMoveSpeed ();
		checkJump ();
		Jump ();
	}

	void FixedUpdate(){
		checkFalling ();
		if (hero.getCurEndurance () > 0) 
			movement ();
		else
			body.velocity = new Vector2 (0f, body.velocity.y);
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
		if (hero.getCurEndurance () - 5 > 0) {
			if (groundTouch && canJump && (timerSaut <= 0 || timerSaut == CooldownSaut) && (Input.GetKey (KeyCode.Space))) {
				body.velocity = new Vector3 ();
				body.AddForce (new Vector2 (0f, heroSpeed * coefficientSaut), ForceMode2D.Impulse);
				canJump = false;
				groundTouch = false;
				hero.gainLoseEndurance ((int)-enduranceSaut);
			}
		}
	}

	void checkFalling(){
		RaycastHit2D hit = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y-1f));
		Debug.DrawLine (transform.position, new Vector2(transform.position.x, transform.position.y-1f));
		if ((hit.collider != null)&&(hit.collider.gameObject!=this.gameObject)) {
			if (hit.collider.gameObject.tag == "Ground") {
				groundTouch = true;
			}
		} else {
			groundTouch = false;
		}
	}

	private void movement(){
		if (Input.GetKey (KeyCode.Q)) {
			sprite.flipX = true;
			body.velocity = new Vector2 (-heroSpeed * 0.05f, body.velocity.y);
			if (groundTouch)
				hero.gainLoseEndurance ((int)-enduranceMovement);
		} else if (Input.GetKey (KeyCode.D)) {
			sprite.flipX = false;
			body.velocity = new Vector2 (heroSpeed * 0.05f, body.velocity.y);
			if (groundTouch)
				hero.gainLoseEndurance ((int)-enduranceMovement);
		}
		else {
			body.velocity = new Vector2 (0f, body.velocity.y);
		}
	}

	public void setGroundTouch(bool val){
		groundTouch = val;
	}

	public bool getGroundTouch(){
		return groundTouch;
	}



}
