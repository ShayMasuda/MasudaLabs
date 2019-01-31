using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	public float projectileSpeed = 15F;
	
	// Use this for initialization
	void Start () 
	{
		Vector3 vT3 = transform.position;
		vT3.z = 0;
		transform.position = vT3;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0, projectileSpeed * Time.deltaTime, 0);
		
		if(transform.position.y >= GameParams.fScreenYLimit + 5)
		{
			PoolManager.Despawn(gameObject);
		}
	}
}
