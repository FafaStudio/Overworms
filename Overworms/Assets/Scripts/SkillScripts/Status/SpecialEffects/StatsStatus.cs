using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsStatus : Status {
	public enum listStatType
	{
		PV, ATTACK, DEFENSE, INIT, FIELD_OF_VIEW, MOVE_SPEED, ENDURANCE
	}

   [SerializeField]

	public listStatType statType;

   [SerializeField]
	public int value;

	public int getStatOfType(listStatType testedStatType){
		if(statType == testedStatType){
			return value;
		}	else	{
			return 0;
		}
	}



	public listStatType getStatType(){return statType;}
	public float getValue(){return value;}
}
