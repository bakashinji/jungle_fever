using UnityEngine;

public class PickUp : MonoBehaviour
{
	public void OnPickUp(LivingObject obj)
	{
		Debug.Log (obj.name + " picked up: " + name);
		gameObject.SetActive (false);
	}
}

