using UnityEngine;

public class Knife : Weapon
{
	public Knife (string tag)
		: base(tag)
	{
		_damage = 20;
		_range = 10;
	}

	public override bool attack(Vector3 src, Vector3 direction)
	{
		int layer = 0;
		layer = 1 << 8;
		

		RaycastHit hit;
		Ray r = new Ray(src, direction);
		if(Physics.Raycast(r, out hit, Mathf.Infinity, layer))
		{
			if(hit.collider.tag == base.hitTag)
			{
				Debug.Log("We hit some " + base.hitTag);
			}
		}
		return false;
	}
}


