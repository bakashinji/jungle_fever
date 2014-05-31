using UnityEngine;
using System;
using System.Collections.Generic;

public class Deliver : MonoBehaviour
{
	
	public String name;

	
	public void OnDeliver(LivingObject obj)
	{
		Debug.Log(obj.name + " picked up: " + name);
		var inv = Inventory.Items;

		GameObject[] gos = GameObject.FindGameObjectsWithTag ("disease");
		foreach (GameObject g in gos) {
			Disease d = g.GetComponent<Disease>();
			Recipe r = d.recipe;
			CheckInventory(r.Vaccination, inv, false);
			CheckInventory(r.Medicine, inv, true);
		}

		
		/*if (invent.ContainsKey(name))
		{
			invent [name] -= ;
		} else
		{
			invent.Add(name, 1);
		}*/
	}

	void CheckInventory(Dictionary<string, int> med, Dictionary<string, int> inv, bool vac)
	{

				string last_key = "";
				bool not_found = false;
				while (!not_found) {
						foreach (var obj in med.Keys) {
								if (inv.ContainsKey (obj) && (inv [obj] >= med [obj])) {
										inv [obj] -= med [obj];
										//TODO heal ppl + print sth
								} else {
										not_found = true;
										last_key = obj;
										break;
								}
						}
						if (not_found) {
								foreach (var obj in med.Keys) {
										if (!inv.ContainsKey (obj))
												continue;
					
										if (last_key.CompareTo (obj) == 0) {
												break;
										}
										inv [obj] += med [obj];
								}
						} else {
								GameLogic.won = true;
								Debug.Log ("you fucking won!!!!!!!!!!!");
						}
				
				}
		}

}
