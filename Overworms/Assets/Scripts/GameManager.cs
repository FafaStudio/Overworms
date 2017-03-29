using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	List<GameObject> characters;
	int indiceCharacter = 0;

	CharacterUI characterUI;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);  
		characters = new List<GameObject> ();
	}

	void Start () {
		characterUI = GameObject.Find ("CharacterUI").GetComponent<CharacterUI>();
		initTurn ();
	}

	public void addCharacter(GameObject charac){
		characters.Add (charac);
	}
	public void removeCharacter(GameObject charac){
		characters.Remove (charac);
	}

	public void initTurn(){
		characterUI.initTurn ();
		characterUI.setCurrentCharacter(characters[indiceCharacter]);
	}


}
