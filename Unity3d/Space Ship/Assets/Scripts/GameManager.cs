using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static int s_Score=0;
	public Texture2D HealthBarEmpty;
	public Texture2D HealthBarFull;

	public Texture2D ShieldBarEmpty;
	public Texture2D ShieldBarFull;
	public Texture2D ShieldBarActive;

	private Vector2 HealthBarPos;
	private Vector2 ShieldBarPos;
	private Vector2 size;
	// Use this for initialization
	void Start () 
	{
		HealthBarPos = new Vector2(10, Screen.height - 50);
		ShieldBarPos = new Vector2(10, Screen.height - 30);
		size = new Vector2(150, 18);
		s_Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!GameObject.Find("Prefab_Player") )
		{
			StartCoroutine("GameOver");
		}
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel("GameOver");
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score: " + s_Score );
		if(GameData.current)
			GUI.Label(new Rect(Screen.width-100, 10, 100, 20), "Credits: " + GameData.current.credits );

		// draw the background:
		GUI.BeginGroup (new Rect (HealthBarPos.x, HealthBarPos.y, size.x, size.y));
			GUI.Box (new Rect (0,0, size.x, size.y), HealthBarEmpty);
		
			// draw the filled-in part:
		  	GUI.BeginGroup (new Rect (0, 0, size.x * Player.iLife/100, size.y));
				GUI.Box (new Rect (0,0, size.x, size.y), HealthBarFull);
			GUI.EndGroup ();
		GUI.EndGroup ();

		// draw the background:
		GUI.BeginGroup (new Rect (ShieldBarPos.x, ShieldBarPos.y, size.x, size.y));
			GUI.Box (new Rect (0,0, size.x, size.y), ShieldBarEmpty);
		
		// draw the filled-in part:
			GUI.BeginGroup (new Rect (0, 0, size.x * Player.fShield/100, size.y));
			if(Player.IsSheildActive() )
				GUI.Box (new Rect (0,0, size.x, size.y), ShieldBarActive);
			else
				GUI.Box (new Rect (0,0, size.x, size.y), ShieldBarFull);
			GUI.EndGroup ();
		GUI.EndGroup ();
	}
}
