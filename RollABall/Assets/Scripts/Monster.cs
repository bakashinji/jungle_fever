using UnityEngine;
using System.Collections;

public class Monster : LivingObject
{
	public LivingObject player;

	public int hp = 100;
	public int xp = 50;

	public float detectRange;

	void Awake()
	{
		weapon = new Knife (player.tag, this);
		health = hp;
		experience = xp;
	}

	public override void OnHit(LivingObject attacker)
	{
		health -= attacker.weapon.damage;
		Debug.Log(name + " remaining health: " + health);

		if (health <= 0)
		{
			Debug.Log(attacker.name + " killed " + name);
			gameObject.SetActive (false);
		}
	}

	void Update()
	{
		float playerDistance = LivingObject.distance (this, player);
		if (playerDistance < detectRange)
		{
			//Debug.Log(name + " detected player");

			if(playerDistance < weapon.range)
			{
				var direction = (player.transform.position -transform.position).normalized;
				weapon.attack(transform.position, direction);
			}

		}
	}
}
