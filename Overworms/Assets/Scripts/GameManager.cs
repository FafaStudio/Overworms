using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	List<GameObject> characters;
	int indiceCharacter = 0;

	CharacterUI characterUI;

	GameObject mainCamera;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);  
		characters = new List<GameObject> ();
	}

	void Start () {
		mainCamera = GameObject.Find ("CameraRoot");
		characterUI = GameObject.Find ("CharacterUI").GetComponent<CharacterUI>();
		RankHeroByInitiative ();
		initTurn ();
	}

	public void addCharacter(GameObject charac){
		characters.Add (charac);
	}

	public void removeCharacter(GameObject charac){
		characters.Remove (charac);
	}

	public void EndTurn(){
		HeroManager prevCharacter = characters [indiceCharacter].GetComponent<HeroManager> ();
		prevCharacter.setIsMyTurn (false);
		prevCharacter.resetEndurance ();
		if (indiceCharacter+1 == characters.Count)
			indiceCharacter = 0;
		else
			indiceCharacter++;
		initTurn ();
	}

	public void initTurn(){
		characterUI.endTurn ();
		characterUI.setCurrentCharacter(characters[indiceCharacter]);
		mainCamera.GetComponent<Destructible2D.D2dFollow> ().Target = characters [indiceCharacter].transform;
		StartCoroutine (launchTurn ());
	}

	public IEnumerator launchTurn(){
		yield return new WaitForSeconds (1f);
		characterUI.initTurn ();
		characters [indiceCharacter].GetComponent<HeroManager> ().setIsMyTurn (true);
	}

	void RankHeroByInitiative(){
		//les personnages aux initiatives hautes joueent avant les plus basse
		//rangé par ordre décroissant donc
		//algo pas opti' mais peu de donnée dans la liste de héro donc pas impactant
		GameObject curHero;
		for (int i = 0; i < characters.Count; i++) {
			for (int j = 0; j < characters.Count; j++) {
				if (characters [j].GetComponent<HeroManager> ().getCurInit () < characters [i].GetComponent<HeroManager> ().getCurInit ()) {
					curHero = characters [i];
					characters [i] = characters [j];
					characters [j] = curHero;
				}
			}
		}
	}

	void debugCharactersToString(){
		for (int i = 0; i < characters.Count; i++) {
			Debug.Log ("________________________________");
			Debug.Log (characters [i].gameObject);
			Debug.Log (characters [i].GetComponent<HeroManager> ().getCurInit ());
			Debug.Log ("________________________________");
		}
	}

	public CharacterUI getCharacterUI(){
		return characterUI;
	}
}
