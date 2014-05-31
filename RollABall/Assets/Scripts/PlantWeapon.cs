using UnityEngine;

public class PlantWeapon : Weapon
{
	float missChance = 0.5f;

	public PlantWeapon (string tag, LivingObject obj)
		: base(tag, obj)
	{
		_damage = 10;
		_range = 5;
		coolDown = 2;
	}
	
	public override bool attack(Vector3 src, Vector3 direction)
	{
		if (!isReady ())
			return false;
		updateFire ();

		Random.seed = Time.time.GetHashCode ();
		if (Random.Range (0.0f, 1.0f) < missChance)
			return false;

		RaycastHit hit;
		Ray r = new Ray(src, direction);
		if(Physics.Raycast(r, out hit, _range))
		{
			Debug.Log(hit.collider.name);
			
			if(hit.collider.tag == base.hitTag)
			{
				var obj = hit.collider.GetComponent<LivingObject>();
				if (obj)
				{
					obj.OnHit(base._user);
					return true;
				}
				else
					Debug.Log(hit.collider.name + " is not a LivingObject!");
			}
		}
		return false;
	}
}
