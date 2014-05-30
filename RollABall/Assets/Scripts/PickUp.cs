using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{

    public String name;

    public void OnPickUp(LivingObject obj)
    {
        Debug.Log(obj.name + " picked up: " + name);
        gameObject.SetActive(false);
        var invent = Inventory.Items;

        if (invent.ContainsKey(name))
        {
            invent [name]++;
        } else
        {
            invent.Add(name, 1);
        }
    }
}

