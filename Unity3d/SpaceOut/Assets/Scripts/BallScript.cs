using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour 
{
	public float fSpeed = 0;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = new Vector3 (GameParams.fBallSize, GameParams.fBallSize, GameParams.fBallSize);
	}	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (0, fSpeed, 0);
		Vector3 v3T = transform.position;
		v3T.z = 0;
		transform.position = v3T;
		//transform.position = new Vector3 (transform.position.x, transform.position.y + fSpeed * Time.deltaTime, transform.position.z);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Paddle") 
		{
			//fSpeed = (fSpeed  + 0.005f);
			Mathf.Clamp(fSpeed, -1 * GameParams.fMaxBallSpeed, GameParams.fMaxBallSpeed);
			float fCollisionPoint = other.transform.position.x - transform.position.x;
			float fRatio = fCollisionPoint / ((GameParams.fPaddleSize + GameParams.fBallSize)/2);
			transform.Rotate( 0, 0, 180f - 2*transform.rotation.eulerAngles.z + fRatio*85);
		}
		else if(other.gameObject.tag == "Top")
		{
			transform.Rotate(0, 0,180 - 2*(transform.rotation.eulerAngles.z ));
		}
		else if(other.gameObject.tag == "Side")
		{
			transform.Rotate(0, 0, -2*(transform.rotation.eulerAngles.z ));
		}
	}
}
