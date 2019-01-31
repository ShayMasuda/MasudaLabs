using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {

	public float fTimeToDie = 2f;
	private float fTime;

	private Vector3[] OriginalPosition;
	private int iSize;

	// Use this for initialization
	void Start () 
	{
		iSize = transform.childCount;
		OriginalPosition = new Vector3[iSize];

		for(int i=0; i<iSize; i++)
		{
			Transform child = transform.GetChild(i);
			OriginalPosition[i] = transform.position - child.transform.position;
		}

		fTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time - fTime >= fTimeToDie)
		{
			PoolManager.Despawn(gameObject);
			//Destroy (gameObject);
		}
	}

	public void Reset(Vector3 Vposition, Quaternion QRotation)
	{
		fTime = Time.time;

		for(int i=0; i<iSize; i++)
		{
			Transform child = transform.GetChild(i);
			child.transform.position = Vposition + OriginalPosition[i];
			child.transform.rotation = QRotation;
		}

	}
}
