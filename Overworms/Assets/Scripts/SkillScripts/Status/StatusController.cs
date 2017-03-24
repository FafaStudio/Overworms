using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour {

	private HeroManager heroManager; 
	public List<StatsStatus> statusList; //A changer en status, plus tard avec le customInspector pour pouvoir add les fils qu'on veut
	// Use this for initialization
	void Start () {
		heroManager = GetComponent<HeroManager>();
		updateBonus();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void removeStatus(int i){
		statusList.RemoveAt(i);
		updateBonus();
	}

	public void updateBonus(){
		updatePvBonus();
		updateAttackBonus();
		updateDefenseBonus();
		updateInitBonus();
		updateFieldOfViewBonus();
		updateMoveSpeedBonus();
		updateEnduranceBonus();
	}


	public void updatePvBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.PV);
			}
		}
		heroManager.gainLosePv(stat);
	}
	public void updateAttackBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.ATTACK);
			}
		}
		heroManager.gainLoseAttack(stat);
	}
	public void updateDefenseBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.DEFENSE);
			}
		}
		heroManager.gainLoseDefense(stat);
	}
	public void updateInitBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.INIT);
			}
		}
		heroManager.gainLoseInit(stat);
	}
	public void updateFieldOfViewBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.FIELD_OF_VIEW);
			}
		}
		heroManager.gainLoseFieldOfView(stat);
	}
	public void updateMoveSpeedBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.MOVE_SPEED);
			}
		}
		heroManager.gainLoseMoveSpeed(stat);
	}
	public void updateEnduranceBonus(){
		int stat = 0;
		for(var i = 0; i < statusList.Count; i++){
			if(statusList[i] is StatsStatus){
				stat += statusList[i].getStatOfType(StatsStatus.listStatType.ENDURANCE);
			}
		}
		heroManager.gainLoseEndurance(stat);
	}
}
