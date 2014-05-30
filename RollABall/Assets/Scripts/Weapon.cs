using UnityEngine;

public abstract class Weapon
{
	protected int _damage;
	protected int _range;
	protected LivingObject _user;

	private string _hittag;

	private float _coolDown;
	private float _nextFire;

	public int damage
	{
		get { return _damage; }
	}
	public int range
	{
		get { return _range; }
	}
	public float coolDown
	{
		get { return _coolDown; }
		set { _coolDown = value; }
	}
	public string hitTag
	{
		get { return _hittag; }
	}


	public Weapon(string tag, LivingObject obj)
	{
		_hittag = tag;
		_user = obj;
	}
	
	public bool isReady()
	{
		return Time.time > _nextFire;
	}
	public void updateFire()
	{	
		_nextFire = Time.time + _coolDown;
	}


	public abstract bool attack (Vector3 src, Vector3 direction);
}
