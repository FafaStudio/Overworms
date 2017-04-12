using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour {

	//variables d'initialisations pour rendre public les variables statics
	public string initNOM;
	public int initPV, initATTACK, initDEFENSE, initINIT, initFIELDOFVIEW, initMOVESPEED, initENDURANCE;
	//____________________________________________________________________

	static string NOM;

	static int PV;
	int curPv;

	static int ATTACK;
	int curAttack;

	static int DEFENSE;
	int curDefense;

	static int INIT;
	int curInit;

	static int FIELD_OF_VIEW;
	int curFieldOfView;

	static int MOVE_SPEED;
	int curMoveSpeed;

	static int ENDURANCE;
	int curEndurance;

	bool myTurn = false;

	void initStats(){
	//initiation des variables static et courantes au start() 
		NOM = initNOM;
		PV = curPv = initPV;
		ATTACK = curAttack = initATTACK;
		DEFENSE = curDefense = initDEFENSE;
		INIT = curInit = initINIT;
		FIELD_OF_VIEW = curFieldOfView = initFIELDOFVIEW;
		MOVE_SPEED = curMoveSpeed = initMOVESPEED;
		ENDURANCE = curEndurance = initENDURANCE;
	}

	void Start () {
		GameManager.instance.addCharacter (this.gameObject);
		initStats ();
	}

	void Die(){
		gameObject.SetActive (false);
	}

	//SET-GET TOUR DE JEU
	public bool getIsMyTurn(){return myTurn;}
	public void setIsMyTurn(bool val){myTurn = val;}

	//ACCESSEURS VARIABLES STATIQUES
	public string getNOM(){return NOM;}
	public int getPV(){return PV;}
	public int getATTACK(){return ATTACK;}
	public int getDEFENSE(){return DEFENSE;}
	public int getINIT(){return INIT;}
	public int getFIELDOFVIEW(){return FIELD_OF_VIEW;}
	public int getMOVESPEED(){return MOVE_SPEED;}
	public int getENDURANCE(){return ENDURANCE;}

	//ACCESSEURS VARIABLES COURANTES
	public int getCurPV(){return curPv;}
	public int getCurAttack(){return curAttack;}
	public int getCurDefense(){return curDefense;}
	public int getCurInit(){return curInit;}
	public int getCurFieldOfView(){return curFieldOfView;}
	public int getCurMoveSpeed(){return curMoveSpeed;}
	public int getCurEndurance(){return curEndurance;}

	//MODIFCATEURS DES STATS
	public void gainLoseAttack(int val){curAttack = ATTACK + val;}
	public void gainLoseDefense(int val){curDefense = DEFENSE + val;}
	public void gainLoseInit(int val){curInit = INIT + val;}
	public void gainLoseFieldOfView(int val){curFieldOfView = FIELD_OF_VIEW + val;}
	public void gainLoseMoveSpeed(int val){curMoveSpeed = MOVE_SPEED + val;}
	//plus simple pour l'endurance, puisqu'elle est calculée pas par le système de statut mais dans l'update de MovementController
	public void gainLoseEndurance(int val){curEndurance += val;}
	public void gainLosePv(int val){
		curPv += val;
		if (curPv <= 0) 
			Die ();
	}

	public void resetEndurance(){
		curEndurance = ENDURANCE;
	}
}
