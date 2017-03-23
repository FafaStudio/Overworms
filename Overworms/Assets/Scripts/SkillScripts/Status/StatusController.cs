using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour {

	public List<StatsStatus> statusList; //A changer en status, plus tard avec le customInspector pour pouvoir add les fils qu'on veut
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}


	public int getPvBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.PV);
			}
		}
		return attack;
	}
	public int getAttackBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.ATTACK);
			}
		}
		return attack;
	}
	public int getDefenseBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.DEFENSE);
			}
		}
		return attack;
	}
	public int getInitBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.INIT);
			}
		}
		return attack;
	}
	public int getFieldOfViewBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.FIELD_OF_VIEW);
			}
		}
		return attack;
	}
	public int getMoveSpeedBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.MOVE_SPEED);
			}
		}
		return attack;
	}
	public int getEnduranceBonus(){
		int attack = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				attack += statusList[i].getStatOfType(StatsStatus.listStatType.ENDURANCE);
			}
		}
		return attack;
	}
}
