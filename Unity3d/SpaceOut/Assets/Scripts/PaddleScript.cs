using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour 
{
	public int iLife = 3;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = new Vector3 (GameParams.fPaddleSize, 0.2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void Move ()
	{
		if(iLife <= 0)
			return;

		float hSpeed = Input.GetAxis ("Horizontal") * GameParams.fPaddleSpeed * Time.deltaTime;

		if(transform.rotation.y * hSpeed > 0 )
		{
			hSpeed = hSpeed/3;
		}
		transform.Translate (hSpeed, 0, 0, Space.World);
		Vector3 v3T = transform.position;
		v3T.x = Mathf.Clamp(transform.position.x, -1 * GameParams.fScreenXLimit, GameParams.fScreenXLimit);
		transform.position = v3T;
	}
}
