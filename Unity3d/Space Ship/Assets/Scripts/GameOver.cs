using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3(0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(0, 0, 5*Time.deltaTime) );
		if(transform.position.z >= -5)
		{
			transform.position = new Vector3(0, 0, -5);
			StartCoroutine("LoadMenu", 1);
		}
	}

	IEnumerator LoadMenu(int iDelay)
	{
		yield return new WaitForSeconds(iDelay);
		Application.LoadLevel("MainMenu");
	}
}
