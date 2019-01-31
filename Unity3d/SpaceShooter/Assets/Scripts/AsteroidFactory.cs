using UnityEngine;
using System.Collections;

public class AsteroidFactory : MonoBehaviour 
{
	public float fAsteroidRate = 0.1F;
	public string strAsteroid;

	private float fAsteroidTime;

	// Use this for initialization
	void Start () 
	{
		fAsteroidTime = 1 / fAsteroidRate;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fAsteroidTime += Time.deltaTime;
		if(fAsteroidTime >= 1/fAsteroidRate)
		{
			fAsteroidTime = 0;
			GameObject asteroid = PoolManager.Spawn(strAsteroid);
			Asteroid asteroidScript = (Asteroid)asteroid.GetComponent("Asteroid");
			asteroidScript.Reset();
			asteroid.SetActive(true);
		}
	}
}
