using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public Material startNormal;
	public Material startHover;
	public Material startClick;
	
	private RaycastHit hit;
	private Ray ray;

	// Update is called once per frame
	void Update () 
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 100f) )
		{
			if(hit.transform.tag == "startButton")
			{
				GameObject button =  GameObject.Find("StartButton");

				if (Input.GetMouseButtonDown(0) )
				{
					button.GetComponent<Renderer>().material = startClick;
					Application.LoadLevel("Level 1");
				}
				else
					button.GetComponent<Renderer>().material = startHover;
			}
		}
		else
		{
			ResetMaterials();
		}
	}

	void ResetMaterials ()
	{
		GameObject button =  GameObject.Find("StartButton");
		button.GetComponent<Renderer>().material = startNormal;
	}
}
