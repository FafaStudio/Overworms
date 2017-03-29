using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularSlider : MonoBehaviour {

	Image circularSilder;            //Drag the circular image i.e Slider in our case
	//public float progressAmount;     //In how much time the progress bar will fill/empty
	CharacterUI uiManager;

	void Start() {
		uiManager = GetComponentInParent<CharacterUI> ();
		uiManager.addUI (this.gameObject);
		circularSilder = this.GetComponent<Image> ();
		circularSilder.fillAmount = 1f;    
		//this.gameObject.SetActive (false);
	}
	void Update () {
		if (uiManager.getCurrentCharacter () != null) {
			float ratio = (float)uiManager.getCurrentCharacter ().getCurEndurance () / (float)uiManager.getCurrentCharacter ().getENDURANCE ();
			circularSilder.fillAmount = ratio;  
		}
	}


}
