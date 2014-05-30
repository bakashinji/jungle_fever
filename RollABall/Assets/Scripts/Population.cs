using UnityEngine;
using System.Collections;

public class Population : MonoBehaviour {

	public GUISkin skin;
	public double population = 1000000;
	
	public double GetPopulation {
		get {
			return population;
		}
	}

	private int infected = 0;

	public int Infected {
		get {
			return infected;
		}
	}


	private float nextActionTime = 0.0f;
	public float period = 1.0f;

	public double birthrate = 0.00008; // Per seconds

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncPopulation", 0.1f, 1.0f);
	}

	void OnGUI() {
		GUI.skin = skin;
		int intpop = (int)population;
		string text = intpop.ToString ();
		GUI.Label(new Rect(10, 10, 100, 30), text);
		GUI.Label(new Rect(10, 80, 100, 30), infected.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextActionTime ) {
			nextActionTime += period;
			//IncPopulation();
		}*/
	}

	void IncPopulation()
	{
		double newpeople = population * birthrate;
		population += newpeople;
	}

	public void InfectPeople(int newInfected)
	{
		if ((newInfected + infected) > ((int)population))
			infected = (int)population;
		else
			infected += newInfected;
	}

	public void KillPeople(int deadPeople)
	{
		if (deadPeople > ((int)population)) {
			population = 0;
			infected = 0;
			return;
		}
		population -= deadPeople;
		infected -= deadPeople;
		if (infected > population)
			infected = (int)population;
	}
}
