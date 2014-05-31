using UnityEngine;
using System.Collections;

public class Monster : LivingObject
{
	public AnimationClip idleAnimation;
	public AnimationClip targetAnimation;
	public AnimationClip fireAnimation;
	private Animation _animation;
	enum MonsterState
	{
		IDLE,
		TARGETING,
		TARGETED,
		SHOOTING
	}
	private MonsterState monsterState;

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
		ShowRollover = false;
		objRect = new Rect(0, 0, 200, 35);
		MousePos = new Vector2(0, 0);

		_animation = GetComponent<Animation> ();
		if (!_animation)
			Debug.Log("The character you would like to be your enemy doesn't have animations. Moving her might look weird.");
		
		if (!idleAnimation)
		{
			_animation = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if (!targetAnimation)
		{
			_animation = null;
			Debug.Log("No aim animation found. Turning off animations.");
		}
		if (!fireAnimation)
		{
			_animation = null;
			Debug.Log("No fire animation found. Turning off animations.");
		}

		monsterState = MonsterState.IDLE;

		if (!player)
		{
			enabled = false;
			return;
		}

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
            gameObject.SetActive(false);
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
		if (enable && health > 0)
		{
			float playerDistance = LivingObject.distance (this, player);
		
			if (playerDistance < detectRange)
			{
				var target = player.transform.position;


				this.transform.LookAt(target);
				this.transform.Rotate(0, 60, 0);


				switch(monsterState)
				{
				case MonsterState.IDLE:
					monsterState = MonsterState.TARGETING;
					break;
				case MonsterState.TARGETING:
					if(!targetAnimation.isAnimatorMotion)
						monsterState = MonsterState.TARGETED;
					break;
				case MonsterState.TARGETED:
					if(playerDistance <= weapon.range)
						monsterState = MonsterState.SHOOTING;
					break;
				case MonsterState.SHOOTING:
					var src = transform.position;
					src.y += 1;

					var direction = (player.transform.position - src).normalized;
					weapon.attack (src, direction);
					break;
				}
			}
			else
				monsterState = MonsterState.IDLE;
		}

		if(_animation)
		{
			switch(monsterState)
			{
			case MonsterState.IDLE:
				_animation.wrapMode = WrapMode.Loop;
				_animation.CrossFade(idleAnimation.name);
				break;
			case MonsterState.TARGETING:
				_animation.CrossFade(targetAnimation.name);
				_animation.wrapMode = WrapMode.ClampForever;
				break;
			case MonsterState.TARGETED:
				break;
			case MonsterState.SHOOTING:
				_animation.CrossFadeQueued(fireAnimation.name);
				_animation.wrapMode = WrapMode.Once;
				break;
			}
		}
	}
}
