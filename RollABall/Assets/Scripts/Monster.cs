using UnityEngine;
using System.Collections;

public class Monster : LivingObject
{
	public LivingObject player;
	private bool enable = true;
	
	public int hp = 100;
	public int xp = 50;
	
	public float detectRange;
	
	public bool ShowRollover;
	private Rect objRect;
	private Vector2 MousePos;
	public Vector3 offset = new Vector3 (16, 16, 0);
	
	void Awake()
	{
		if (!player)
			enabled = false;
		else
		{
			weapon = new PlantWeapon (player.tag, this);
			health = hp;
			experience = xp;
		}
		
		ShowRollover = false;
		objRect = new Rect(0, 0, 200, 35);
		MousePos = new Vector2(0, 0);
	}
	
	public override void OnHit(LivingObject attacker)
	{
		health -= attacker.weapon.damage;
		Debug.Log(name + " remaining health: " + health);
		
		if (health <= 0)
		{
			Debug.Log(attacker.name + " killed " + name);
			gameObject.SetActive(false);
			((PlayerController)attacker).character.Exp += 4;
		}
	}
	
	void OnMouseEnter()
	{
		ShowRollover = true;
	}
	void OnMouseExit()
	{
		ShowRollover = false;
	}
	void OnGUI()
	{
		if (ShowRollover)
		{
			MousePos = Input.mousePosition + offset;
			objRect.x = MousePos.x;
			
			objRect.y = Mathf.Abs(MousePos.y - Camera.main.pixelHeight);
			GUI.Label(objRect, name + " health: " + health);
		}
	}
	
	void Update()
	{
		if (enable)
		{
			float playerDistance = LivingObject.distance (this, player);
			
			if (playerDistance < detectRange)
			{
				//Debug.Log(name + " detected player");
				
				if (playerDistance < weapon.range && health > 0)
				{
					var direction = (player.transform.position - transform.position).normalized;
					weapon.attack (transform.position, direction);
				}
			}
		}
	}
}
