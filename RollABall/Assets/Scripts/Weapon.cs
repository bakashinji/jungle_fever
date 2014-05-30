using UnityEngine;

public abstract class Weapon
{
	protected int _damage;
	protected int _range;
	protected double _alpha;

	private string _hittag;
	public string hitTag
	{
		get
		{
			return _hittag;
		}
	}


	public Weapon(string tag)
	{
		_hittag = tag;
	}


	public abstract bool attack (Vector3 src, Vector3 direction);
}
