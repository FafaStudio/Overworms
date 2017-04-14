using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    
	HeroManager hero;
	float heroSpeed;
	Rigidbody2D body;
	BoxCollider2D collider;
	SpriteRenderer sprite;

	public PhysicsMaterial2D movementMaterial;
	public PhysicsMaterial2D passiveMaterial;


	

	bool isMoving=false;
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
		collider = GetComponent<BoxCollider2D> ();
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
		groundTouch =checkFalling ();
		checkGliding ();
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
			if (groundTouch && canJump && (timerSaut <= 0 || timerSaut == cooldownSaut) && (Input.GetKeyDown (KeyCode.Space))) {
				body.velocity = new Vector3 ();
				body.AddForce (new Vector2 (0f, heroSpeed * coefficientSaut), ForceMode2D.Impulse);
				canJump = false;
				groundTouch = false;
				hero.gainLoseEndurance ((int)-coutEnduranceSaut);
			}
		}
	}

	bool checkFalling(){
		RaycastHit2D hit;
		for (int i = -1; i < 1; i++) {
			hit = Physics2D.Linecast(transform.position, new Vector2(transform.position.x+((float)i/3), transform.position.y-1f));
			Debug.DrawLine (transform.position, new Vector2 ((transform.position.x+(float)i/3), transform.position.y - 1f));
			if ((hit.collider != null) && (hit.collider.gameObject != this.gameObject)) {
				if (hit.collider.gameObject.tag == "Ground") {
					return true;
				}
			} 
		}
		return false;
	}

	void checkGliding(){
		if ((groundTouch) && (!isMoving)) {
		}
	}

	/*bool checkFalling(){
		RaycastHit2D hit = Physics2D.Linecast(new Vector2(transform.position.x-0.5f, transform.position.y-0.75f), new Vector2(transform.position.x+0.5f, transform.position.y-0.75f));
		Debug.DrawLine (new Vector2 (transform.position.x-0.5f, transform.position.y-0.75f), new Vector2(transform.position.x+0.5f, transform.position.y-0.75f));
			if ((hit.collider != null) && (hit.collider.gameObject != this.gameObject)) {
				if (hit.collider.gameObject.tag == "Ground") {
					return true;
				}
		}
		return false;
	}*/

	private void movement(){
		if (Input.GetKey (KeyCode.Q)) {
			if(!isMoving){
				swapMaterial(movementMaterial);
			}
			sprite.flipX = true;
			isMoving = true;
			body.velocity = new Vector2 (-heroSpeed * 0.05f, body.velocity.y);
			if (groundTouch)
				hero.gainLoseEndurance ((int)-coutEnduranceMovement);
		} else if (Input.GetKey (KeyCode.D)) {
			if(!isMoving){
				swapMaterial(movementMaterial);
			}
			sprite.flipX = false;
			isMoving = true;
			body.velocity = new Vector2 (heroSpeed * 0.05f, body.velocity.y);
			if (groundTouch)
				hero.gainLoseEndurance ((int)-coutEnduranceMovement);
		}
		else {
			if(isMoving){
				swapMaterial(passiveMaterial);
			}

			isMoving = false;
			body.velocity = new Vector2 (0f, body.velocity.y);
		}
	}

	private void swapMaterial(PhysicsMaterial2D changeMaterial){
		gameObject.GetComponent<BoxCollider2D>().sharedMaterial = changeMaterial;
		gameObject.GetComponent<Rigidbody2D>().sharedMaterial = changeMaterial;			
			
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void setGroundTouch(bool val){
		groundTouch = val;
	}

	public bool getGroundTouch(){
		return groundTouch;
	}

}
