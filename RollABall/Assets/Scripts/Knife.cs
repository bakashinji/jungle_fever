using UnityEngine;

public class Knife : Weapon
{
	public Knife (string tag, LivingObject obj)
		: base(tag, obj)
	{
		_damage = 20;
		_range = 10;
		coolDown = 1;
	}

	public override bool attack(Vector3 src, Vector3 direction)
	{
		if (!isReady ())
			return false;
		updateFire ();


	//	CharacterController controller = GetComponent<CharacterController>();
	//	collisionFlags = controller.Move (direction);


		var audioSource = this._user.GetComponent<AudioSource> ();
		if (audioSource)
		{
			audioSource.Play();
		}


			
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


