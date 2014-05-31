using UnityEngine;

public class PickUp : MonoBehaviour
{
	public void OnPickUp(LivingObject obj)
	{
		Debug.Log (obj.name + " picked up: " + name);
		gameObject.SetActive (false);
		var invent = Inventory.Items;

		if (invent.ContainsKey(name))
		{
			invent [name] += 1;
		} else
		{
			invent.Add(name, 1);
		}
	}
}

