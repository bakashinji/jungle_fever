using UnityEngine;
using System.Collections;

public abstract class LivingObject : MonoBehaviour
{
	private int _hp = 1000;
	private int _xp = 0;

	private Weapon _weapon = null;

	public int health
	{
		get { return _hp; }
		set { _hp = value; }
	}
	public int experience
	{
		get { return _xp; }
		set { _xp = value; }
	}
	public Weapon weapon
	{
		get {return _weapon; }
		set {_weapon = value; }
	}

	public static float distance(LivingObject a, LivingObject b)
	{
        if (a && b)
            return Vector3.Distance(a.transform.position, b.transform.position);
        else
        {
            Debug.Log("Try to compare two objects, that are no Objects");
            return -1;
        }
	}

	
	public abstract void OnHit(LivingObject attacker);
}
