using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	Population population;
	Character character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckLosingCond ();
	}

	void CheckLosingCond(){
		if (population.GetPopulation == 0 || character.Hp == 0) {
			// TODO: output you noob
			gameReset ();
		}
	}

	void gameReset() {
	}
}
