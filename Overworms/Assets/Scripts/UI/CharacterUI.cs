using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

	HeroManager currentCharacter;

	List<GameObject> typeOfUI; // permet d'avoir une ref sur tous les UIs fils, pour le moment CircularSlider

	void Awake(){
		typeOfUI = new List<GameObject> ();
	}

	public HeroManager getCurrentCharacter(){
		if (currentCharacter != null)
			return currentCharacter;
		else
			return null;
	}

	public void setCurrentCharacter(GameObject charac){
		currentCharacter = charac.GetComponent<HeroManager>();
	}

	public void initTurn(){
		foreach (GameObject ui in typeOfUI) {
			ui.SetActive (true);
		}
	}

	public void addUI(GameObject ui){
		typeOfUI.Add (ui);
	}
}
