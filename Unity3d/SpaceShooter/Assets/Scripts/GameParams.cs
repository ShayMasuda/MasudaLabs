using UnityEngine;
//Class used for storing parameters about the environment of the game  
public class GameParams : MonoBehaviour 
{
	public static float 	fXLimit;
	public static float 	fYLimit;
	public static float 	fBoundsMargin = 5F;

	// Use this for initialization
	void Start () 
	{
		float dist =(transform.position.y - Camera.main.transform.position.y);

		fXLimit = -1 * Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist) ).x - PlayerScript.fPlayerWidth/2;		
		fYLimit = (-1 * Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).z - PlayerScript.fPlayerHeight/2) / 2;
	}

	void Update () 
	{
		float dist =(transform.position.y - Camera.main.transform.position.y);
		
		fXLimit = -1 * Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist) ).x - PlayerScript.fPlayerWidth/2;		
		fYLimit = (-1 * Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).z - PlayerScript.fPlayerHeight/2) / 2;
	}
}
