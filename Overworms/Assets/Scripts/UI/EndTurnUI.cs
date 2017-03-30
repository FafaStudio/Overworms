using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnUI : MonoBehaviour {

	Image slider;            //Drag the circular image i.e Slider in our case
	//public float progressAmount;     //In how much time the progress bar will fill/empty
	CharacterUI uiManager;

	bool isActive = false;

	void Start() {
		uiManager = GetComponentInParent<CharacterUI> ();
		slider = this.GetComponent<Image> ();
		slider.fillAmount = 0f;    
		this.gameObject.SetActive (false);
	}

	void Update () {
		if (isActive) {
			slider.fillAmount += Time.deltaTime;
			if (slider.fillAmount == 1f) {
				GameManager.instance.EndTurn ();
				stopEndTurnUI ();
			}
		}
	}

	public void launchEndTurnUI(){
		isActive = true;
	}

	public void stopEndTurnUI(){
		slider.fillAmount = 0f; 
		isActive = false;
	}

}
