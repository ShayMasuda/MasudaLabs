using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public int		iMaxLife = 3;
	public float 	fAsteroidSpeed = 30F;
	public float 	fAsteroidRotation = 0F;
	private int		iLife = 0;


	// Use this for initialization
	void Start () 
	{
		Reset();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(fAsteroidSpeed, 0, 0, Space.World);
		transform.Rotate(fAsteroidRotation, fAsteroidRotation, fAsteroidRotation, Space.World);

		if(iLife <= 0)
		{
			ExplodeAsteroid();
		}

		if(transform.position.x <= -1* GameParams.fXLimit - GameParams.fBoundsMargin)
		{
			PoolManager.Despawn(gameObject);
		}

		//PoolManager.CheckOutOfbounds (gameObject);
	}

	void ExplodeAsteroid()
	{
		//destroy asteroid
		PoolManager.Despawn(gameObject);
		/*
		GameObject brokenAsteroid = PoolManager.Spawn("BrokenAsteroid");
		brokenAsteroid.transform.position = transform.position;
		brokenAsteroid.transform.rotation = transform.rotation;
		//reset breakable
		((BrokenAsteroid)brokenAsteroid.GetComponent("BrokenAsteroid")).Reset(transform.position, transform.localScale, transform.rotation, fAsteroidSpeed);
		brokenAsteroid.SetActive (true);
		*/
	}


	public void Reset()
	{
		iLife = iMaxLife;
		fAsteroidSpeed = Random.Range(-5, -10) * Time.deltaTime;
		fAsteroidRotation = Random.Range(-10, 10) * Time.deltaTime;
		Vector3 vT3;
		vT3.x = Random.Range(GameParams.fXLimit+2, GameParams.fXLimit+4);
		vT3.y = Random.Range(-1* GameParams.fYLimit, GameParams.fYLimit);
		vT3.z = 0;
		transform.position = vT3;

		float fScale = Random.Range(0.3F, 0.6F);
		vT3.x = fScale;
		vT3.y = fScale;
		vT3.z = fScale;
		transform.localScale = vT3;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "projectile")
		{
			iLife--;
			PoolManager.Despawn(other.gameObject);
		}
		else if(other.gameObject.tag == "Player")
		{
			iLife = 0;
		}
	}

}
