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
		transform.Translate(projectileSpeed * Time.deltaTime, 0, 0);
		PoolManager.CheckOutOfbounds (gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Projrctile Trigger");
	}
}
