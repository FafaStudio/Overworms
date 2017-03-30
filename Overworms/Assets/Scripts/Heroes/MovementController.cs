﻿using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    
	HeroManager hero;
	float heroSpeed;
	Rigidbody2D body;
	SpriteRenderer sprite;

	bool groundTouch;
	bool canJump;
	float timerSaut;
	public float cooldownSaut;
	public float coefficientSaut;

	public float coutEnduranceSaut;
	public float coutEnduranceMovement;


	void Start () {
		hero = GetComponent<HeroManager> ();
		body = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		timerSaut = cooldownSaut;
		canJump=true;
	}

	void Update () {
		if (!hero.getIsMyTurn ())
			return;
		heroSpeed = hero.getCurMoveSpeed ();
		checkJump ();
		Jump ();
		checkEndTurn ();
	}

	void FixedUpdate(){
		if (!hero.getIsMyTurn ()) {
			body.velocity = new Vector2 (0f, body.velocity.y);
			return;
		}
		checkFalling ();
		if (hero.getCurEndurance () > 0) 
			movement ();
		else if(groundTouch)
			body.velocity = new Vector2 (0f, body.velocity.y);
		else
		//permet au joueur de controler son dernier saut si il na plus dendurance
			movement ();
	}

	void checkEndTurn(){
		if (Input.GetKeyDown (KeyCode.Y)&&groundTouch) {
			GameManager.instance.getCharacterUI ().launchEndTurn ();
		}
		if (Input.GetKeyUp (KeyCode.Y)&&groundTouch) {
			GameManager.instance.getCharacterUI ().interruptEndTurn ();
		}
	}

	private void checkJump(){
		if (!canJump) {
			timerSaut -= Time.deltaTime;
		}
		if (timerSaut <= 0f) {
			canJump = true;
			timerSaut = cooldownSaut;
		}
	}

	private void Jump(){
		if (hero.getCurEndurance () - 5 > 0) {
			if (groundTouch && canJump && (timerSaut <= 0 || timerSaut == cooldownSaut) && (Input.GetKey (KeyCode.Space))) {
				body.velocity = new Vector3 ();
				body.AddForce (new Vector2 (0f, heroSpeed * coefficientSaut), ForceMode2D.Impulse);
				canJump = false;
				groundTouch = false;
				hero.gainLoseEndurance ((int)-coutEnduranceSaut);
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
				hero.gainLoseEndurance ((int)-coutEnduranceMovement);
		} else if (Input.GetKey (KeyCode.D)) {
			sprite.flipX = false;
			body.velocity = new Vector2 (heroSpeed * 0.05f, body.velocity.y);
			if (groundTouch)
				hero.gainLoseEndurance ((int)-coutEnduranceMovement);
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
