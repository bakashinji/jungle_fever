using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats
{

    private static Dictionary<Recipe, int> diseases;

    public static Dictionary<Recipe, int> Dieseases
    {
        get
        {
            return diseases;
        }
    }

    static Stats()
    {
        diseases = new Dictionary<Recipe,int >();

		Disease d = GameObject.FindGameObjectWithTag ("disease").GetComponent<Disease>();
		diseases.Add(d.recipe, d.population.Infected);
    }
}


