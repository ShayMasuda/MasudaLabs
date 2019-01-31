using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public int iMaxLife = 2;

	public static int iDamage = 30;

	private float fAsteroidSpeed = 10F;
	private float fAsteroidRotation = 0F;
	private int iLife = 0;

	// Use this for initialization
	void Start () 
	{
		Reset();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, fAsteroidSpeed, 0, Space.World);
		transform.Rotate(fAsteroidRotation, fAsteroidRotation, fAsteroidRotation, Space.World);
		
		if(transform.position.y <= -1* (GameParams.fScreenYLimit + 5))
		{
			PoolManager.Despawn(gameObject);
		}

		if(iLife <= 0)
		{
			ExplodeAsteroid();
		}
	}

	public void Reset()
	{
		iLife = iMaxLife;
		fAsteroidSpeed = Random.Range(-5, -10) * Time.deltaTime;
		fAsteroidRotation = Random.Range(-50, 50) * Time.deltaTime;
		Vector3 vT3;
		vT3.x = Random.Range(-1*GameParams.fScreenXLimit, GameParams.fScreenXLimit);
		vT3.y = Random.Range(GameParams.fScreenYLimit+5, GameParams.fScreenYLimit+2);
		vT3.z = 0;
		transform.position = vT3;
		vT3.x = Random.Range(50, 120);
		vT3.y = Random.Range(50, 120);
		vT3.z = Random.Range(50, 120);
		transform.localScale = vT3;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "projectile")
		{
			iLife--;
			PoolManager.Despawn(other.gameObject);
		}

		if(other.gameObject.tag == "Player")
		{
			iLife = 0;
		}
	}

	void ExplodeAsteroid()
	{
		//destroy asteroid
		PoolManager.Despawn(gameObject);

		//spawn explosion
		GameObject explosion = PoolManager.Spawn("Small explosion");
		explosion.transform.position = transform.position;
		explosion.SetActive(true);

		//spawn breakable
		GameObject breakable = PoolManager.Spawn ("prefab_Breakable");
		breakable.transform.position = transform.position;
		breakable.transform.rotation = transform.rotation;
		//reset breakable
		((Breakable)breakable.GetComponent("Breakable")).Reset(transform.position, transform.rotation);
		breakable.SetActive (true);

		//Increase score
		GameManager.s_Score++;

		//make a sound

		//HandleDrop
		DropPickUp();
	}

	void DropPickUp ()
	{
		if (Random.Range(0f, 1f) < GameParams.fCreditDropRate)
		{
			GameObject pickUp = PoolManager.Spawn("prefab_Credit");
			pickUp.transform.position = transform.position;
			pickUp.SetActive(true);
			((Credit)pickUp.GetComponent("Credit")).Reset();
			return;
		}


	}
}
