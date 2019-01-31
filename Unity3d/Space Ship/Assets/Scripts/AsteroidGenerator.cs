using UnityEngine;
using System.Collections;

public class AsteroidGenerator : MonoBehaviour 
{
	public float asteroidRate  = 2f; //Asteroids per second

	private float asteroidTime = 0f;

	// Use this for initialization
	void Start () 
	{
		asteroidTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		asteroidTime += Time.deltaTime;
		if(asteroidTime >= 1/asteroidRate)
		{
			asteroidTime = 0;
			GameObject asteroid = PoolManager.Spawn("Prefab_Asteroid");

			Asteroid asteroidScript = (Asteroid)asteroid.GetComponent("Asteroid");
			asteroidScript.Reset();
			asteroid.SetActive(true);
		}
	}
}
