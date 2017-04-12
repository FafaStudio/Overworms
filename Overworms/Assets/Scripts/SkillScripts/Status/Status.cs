using System;
using UnityEngine;

[System.Serializable]
public abstract class Status : ScriptableObject{
   [SerializeField]
   	public string statusName;

	[SerializeField]
	public int duration;

	public enum listTags
	{
		PV, ATTACK, DEFENSE, INIT, FIELD_OF_VIEW, MOVE_SPEED, ENDURANCE
	}
 

	public abstract Type doEffect();
    public abstract int getStatOfType(StatsStatus.listStatType statType);
}
