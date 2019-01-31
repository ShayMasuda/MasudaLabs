using UnityEngine;
using System.Collections;
using Weapons;

public class Player : MonoBehaviour 
{

	public ParticleSystem 	psThrust;
	public GameObject		goShield;

	public Weapon[]			Weapons;

	public static int 		iLife = 100;
	public static float		fShield = 0;

	private float 			fMovementSpeed = 10.0f;
	private float 			fRotationSpeed = 30.0f;
	private static bool		bShieldActive = false;
	private float			fToughness = 0;
	private bool 			bDone = false;

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(0, -1*GameParams.fScreenYLimit, 0);
		goShield.GetComponent<Renderer>().enabled = false;
		iLife = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rotate();
		Move();
		AdjustThrust();
		HandleFire();
		HandleInput();

		if(iLife <=0 && !bDone)
		{
			bDone = true;
			DestroyPlayer();
		}
	}

	void DestroyPlayer ()
	{
		iLife = 0;
		//spawn explosion
		GameObject explosion = PoolManager.Spawn("Small explosion");
		explosion.transform.position = transform.position;
		explosion.SetActive(true);
		gameObject.GetComponent<Renderer>().enabled = false;

		Destroy (gameObject);
	}


	void Move ()
	{
		if(iLife <= 0)
			return;

		float vSpeed = Input.GetAxis ("Vertical") * fMovementSpeed * Time.deltaTime;
		float hSpeed = Input.GetAxis ("Horizontal") * fMovementSpeed * Time.deltaTime;
		if(transform.rotation.y * hSpeed > 0 )
		{
			hSpeed = hSpeed/3;
		}
			transform.Translate (hSpeed, vSpeed, 0, Space.World);
			Vector3 v3T = transform.position;
			v3T.x = Mathf.Clamp(transform.position.x, -1 * GameParams.fScreenXLimit, GameParams.fScreenXLimit);
			v3T.y = Mathf.Clamp(transform.position.y, -1 * GameParams.fScreenYLimit, GameParams.fScreenYLimit);
			transform.position = v3T;
	}

	void Rotate ()
	{
		if(iLife <= 0)
			return;

		float hSpeed = Input.GetAxis ("Horizontal") * fMovementSpeed * Time.deltaTime;
		Quaternion q3R = transform.rotation;
		transform.Rotate(0, fRotationSpeed * Time.deltaTime * -100 * hSpeed, 0, Space.World );
		q3R.y = Mathf.Clamp(transform.rotation.y, -1 * GameParams.fShipRotationLimit, GameParams.fShipRotationLimit);
		transform.rotation = q3R;

		if(hSpeed == 0)
			transform.Rotate(0, (fRotationSpeed-20) * Time.deltaTime * -30 * transform.rotation.y, 0, Space.World );
	}

	void AdjustThrust ()
	{
		if(iLife <= 0)
		{
			psThrust.emissionRate = 0;
			return;
		}

		psThrust.emissionRate = 100 + Input.GetAxis ("Vertical") * Input.GetAxis ("Vertical") * 160 + Input.GetAxis ("Vertical") * 240;
	}

	void HandleFire ()
	{
		if(iLife <= 0)
			return;

		for(int i=0; i<Weapons.Length; i++)
			Weapons[i].Fire();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "asteroid" && !bShieldActive)
		{
			iLife -= (int)((1-fToughness)* Asteroid.iDamage );
		}
		else if(other.gameObject.tag == "Enemy" && !bShieldActive)
		{
			iLife -= (int)((1-fToughness)* Enemy.iDamage );
		}
	}	

	void HandleInput ()
	{
		if(Input.GetAxis ("Shield") > 0 && fShield == 100)
		{
			StartCoroutine( "ActivateShield");
		}
	}

	IEnumerator ActivateShield ()
	{
		bShieldActive = true;
		Color newColor = goShield.GetComponent<Renderer>().material.color;
		goShield.GetComponent<Renderer>().enabled = true;
		while(fShield > 0)
		{
			fShield = fShield - Time.deltaTime*GameParams.fShieldDrainRate;
			if(fShield < GameParams.fShieldDrainRate*2)
			{
				newColor.a = (Mathf.Cos(Time.time*30) + 1f)/4;
			}
			else
			{
				newColor.a = 0.5f;
			}
			goShield.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
		bShieldActive = false;
		goShield.GetComponent<Renderer>().enabled = false;
		fShield = 0;

		yield return null;
	}

	public static bool IsSheildActive()
	{
		return bShieldActive;
	}
	
}











	