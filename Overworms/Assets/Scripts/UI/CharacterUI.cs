using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour {

	HeroManager currentCharacter;

	public GameObject enduranceUI;
	public GameObject endTurnUI;

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
		enduranceUI.SetActive (true);
		endTurnUI.SetActive (true);
	}

	public void endTurn(){
		enduranceUI.SetActive (false);
		endTurnUI.SetActive (false);
	}

	public void launchEndTurn(){
		endTurnUI.SetActive (true);
		endTurnUI.GetComponent<EndTurnUI> ().launchEndTurnUI ();
	}

	public void interruptEndTurn(){
		endTurnUI.GetComponent<EndTurnUI> ().stopEndTurnUI ();
		endTurnUI.SetActive (false);
	}
}
