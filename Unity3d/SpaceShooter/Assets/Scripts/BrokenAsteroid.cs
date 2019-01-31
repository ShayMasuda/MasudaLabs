using UnityEngine;
using System.Collections;

public class BrokenAsteroid : MonoBehaviour {
	
	public float fTimeToDie = 2f;
	private float fTime;
	private float m_fSpeed = 0f;
	
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
		Debug.Log (m_fSpeed);

		for(int i=0; i<iSize; i++)
		{
			Transform child = transform.GetChild(i);
			child.transform.Translate(m_fSpeed, 0, 0, Space.World);
		}

		if(Time.time - fTime >= fTimeToDie)
		{
			PoolManager.Despawn(gameObject);
		}
	}
	
	public void Reset(Vector3 Vposition, Vector3 Vscale, Quaternion QRotation, float fSpeed)
	{
		fTime = Time.time;
		//m_fSpeed = fSpeed/2;

		for(int i=0; i<iSize; i++)
		{
			Transform child = transform.GetChild(i);
			child.transform.position = Vposition + OriginalPosition[i];
			child.transform.rotation = QRotation;
			child.transform.localScale = Vscale/2;
		}
	}
}