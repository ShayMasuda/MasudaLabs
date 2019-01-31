using UnityEngine;
using System.Collections;
using Weapons;

public class PlayerScript : MonoBehaviour 
{
	public static int 		iLife = 100;
	public static float		fPlayerHeight;
	public static float		fPlayerWidth;

	public Weapon[]			Weapons;

	private float 			fMovementSpeed = 10.0f;
	private float 			fRotationSpeed = 10.0f;
	//private float 			fShipRotationLimit = 0.4f;

	// Use this for initialization
	void Start () 
	{
		fPlayerWidth = GetComponent<Renderer>().bounds.size.x;
		fPlayerHeight = GetComponent<Renderer>().bounds.size.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (iLife <= 0)
			Destroy (gameObject);

		Move();
		Rotate();
		HandleFire ();
	}

	void Rotate ()
	{
		if(iLife <= 0)
			return;

		float vSpeed = Input.GetAxis ("Vertical") * fMovementSpeed * Time.deltaTime;
		//transform.Rotate(fRotationSpeed * Time.deltaTime * 100 * vSpeed, 0, 0, Space.World );

		//TODO: Clamp rotation

		//if(vSpeed == 0)
		//	transform.Rotate((fRotationSpeed-20) * Time.deltaTime * -30 * transform.rotation.y, 0, 0, Space.World );
	}

	void Move ()
	{
		if(iLife <= 0)
			return;
		
		float vSpeed = Input.GetAxis ("Vertical") * fMovementSpeed * Time.deltaTime;
		float hSpeed = Input.GetAxis ("Horizontal") * fMovementSpeed * Time.deltaTime;
		transform.Translate (hSpeed, vSpeed, 0, Space.World);
		Vector3 v3T = transform.position;
		v3T.x = Mathf.Clamp(transform.position.x, -1 * GameParams.fXLimit, GameParams.fXLimit);
		v3T.y = Mathf.Clamp(transform.position.y, -1 * GameParams.fYLimit, GameParams.fYLimit);
		transform.position = v3T;
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
		if (other.gameObject.tag == "asteroid")
		{
			iLife -= 10;
			Debug.Log (iLife);
		}
	}

}
