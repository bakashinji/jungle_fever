using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public Population population;
	public Character character;
	private Rect window = new Rect(0,0,1000,100);
	bool lost = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {
		if (lost)
			GUI.Window(1337, window, drawLosingWindow, "Noob");

	}
	
	// Update is called once per frame
	void Update () {
		CheckLosingCond ();
	}

	void CheckLosingCond(){
		if (population.GetPopulation == 0 || character.Hp == 0) {
			lost = true;
		}
	}

	void gameReset() {
	}

	void drawLosingWindow(int windowID)
	{
		float padding = 0.075f * window.width;
		Rect closeButton = new Rect(window.width * 0.925f, 0, padding, padding);
		
		if (GUI.Button(closeButton, "X"))
		{
			Application.LoadLevel(0);
			return;
		}

		GUI.Label (window, "You lost");
	}
}
