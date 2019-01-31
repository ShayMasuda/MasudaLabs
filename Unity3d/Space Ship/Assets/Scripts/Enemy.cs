using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public int 			iMaxLife = 1;
	public static int 	iDamage = 30;
	public static int	iShieldGain = 10;

	private float 		fEnemySpeed = 3;
	private float 		m_fRotationSpeed = -200.0f;
	private float 		fPhase;
	private int 		iCurLife;

	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		float hSpeed = Mathf.Cos(Time.time*3 + fPhase);
		transform.Translate(new Vector3(GameParams.fScreenXLimit*hSpeed*Time.deltaTime, -1 * fEnemySpeed * Time.deltaTime, 0 ), Space.World);

		Quaternion q3R = transform.rotation;
		transform.Rotate(0, m_fRotationSpeed * Time.deltaTime * hSpeed, 0 );
		q3R.y = Mathf.Clamp(transform.rotation.y, -1 * GameParams.fShipRotationLimit, GameParams.fShipRotationLimit);
		q3R.x = 0;
		q3R.z = 0;
		transform.rotation = q3R;
		
		if(iCurLife <= 0 )
		{
			DestroyEnemy ();
		}

		if(transform.position.y <= -1* (GameParams.fScreenYLimit + 5))
		{
			PoolManager.Despawn(gameObject);
		}
	}

	void DestroyEnemy ()
	{
		//spawn explosion
		GameObject explosion = PoolManager.Spawn("Small explosion");
		explosion.transform.position = transform.position;
		explosion.SetActive(true);

		PoolManager.Despawn(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "projectile")
		{
			iCurLife--;
			PoolManager.Despawn(other.gameObject);

			//If shield is not active
			Player.fShield = Mathf.Min(Player.fShield+iShieldGain, 100);
		}

		if(other.gameObject.tag == "Player")
		{
			iCurLife = 0;

			//if(!Player.IsShieldActive() )  ??
				Player.fShield = Mathf.Min(Player.fShield+20, 100);
		}
	}

	public void Reset()
	{
		fPhase = Time.time;
		transform.rotation = new Quaternion(0,0,0,0);
		transform.position = new Vector3(Random.Range(-1*GameParams.fScreenXLimit/2, GameParams.fScreenXLimit/2), 
		                                 				GameParams.fScreenYLimit + 2, 0);
		iCurLife = iMaxLife;
	}
}
