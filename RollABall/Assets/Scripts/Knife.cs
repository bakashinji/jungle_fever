using UnityEngine;

public class Knife : Weapon
{
	public Knife (string tag, LivingObject obj)
		: base(tag, obj)
	{
		_damage = 20;
		_range = 3;
		coolDown = 1;
	}

	public override bool attack(Vector3 src, Vector3 direction)
	{
		if (!isReady ())
			return false;
		updateFire ();

		int layer = 1 << 8;

		RaycastHit hit;
		Ray r = new Ray(src, direction);
		if(Physics.Raycast(r, out hit, _range, layer))
		{
			if(hit.collider.tag == base.hitTag)
			{
				hit.collider.GetComponent<LivingObject>().OnHit(base._user);
				return true;
			}
		}
		return false;
	}
}


