using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Disease : MonoBehaviour {

	public Texture icon;
	public string diseaseName;
	public int baseSpreadingRate = 1; // independent from amount of sick people
	public int infectionSpreadingRate = 1; // dependent from amout of sick people
	public int infectionSpreadingPerson = 5; // amount of person need for spreading
	public float spreadingChance; // chance that spreading is successful
	//public int incubationTime; // after that time, the disease can be lethal
	//public double baseDeathRate; // chance a person dies after incubation time
	//public double incDeathRate; // amount at which the death rate increases
	public float deathRate = 0.003f;
	public Population population;

	private float nextActionTime = 0.0f;
	public float period = 1.0f;

	private int amountTotalKilled = 0;
	private int amountTotalInfected = 0;

	public Recipe recipe;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DiseaseSimulator", 0.1f, 1.0f);
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(10, 600, 30, 30),icon);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.time > nextActionTime ) {
			nextActionTime += period;
			DiseaseSimulator();
		}*/
	}

	void DiseaseSimulator()
	{
		int newDead = 0;
		int newInfected = 0;

		// Sim Infection Start

		Random.seed = Time.time.GetHashCode();

		for (int i = 0; i < baseSpreadingRate; i++) {
			float rand = Random.Range(0.0f, 1.0f);
			if (rand < spreadingChance)
				newInfected++;
		}

		for (int i = 0; i < population.Infected; i+=infectionSpreadingPerson) {
			for (int j = 0; j < infectionSpreadingRate; j++){
				float rand = Random.Range(0.0f, 1.0f);
				if (rand < spreadingChance)
					newInfected++;
			}
		}

		// Sim Infection End

		// Sim Death Start

		for (int i = 0; i < population.Infected; i++) {
			float rand = Random.Range(0.0f, 1.0f);
			if (rand < deathRate)
				newDead++;
		}

		// Sim Death End

		amountTotalInfected += newInfected;
		population.InfectPeople (newInfected);
		amountTotalKilled += newDead;
		population.KillPeople (newDead);
	}
}
