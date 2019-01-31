using UnityEngine;
using System.Collections.Generic;

public class script_ObjectPool : MonoBehaviour 
{

	public GameObject 	m_Object;
	public int			m_iInitPoolSize = 10;
	public int			m_iIncrementIntervals = 10;

	private List<GameObject> m_Pool = null;

	// Use this for initialization
	void Start () 
	{
		InitPool();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	void InitPool ()
	{
		m_Pool = new List<GameObject>();
		GameObject clone;
		for(int i=0; i< m_iInitPoolSize; i++)
		{
			clone = (GameObject)Instantiate(m_Object );
			clone.SetActive(false);
			m_Pool.Add(clone );
		}
	}

	public GameObject Spawn(Vector3 position, Quaternion rotation, bool bActive)
	{
		GameObject clone;
		if(m_Pool.Count == 0)
		{
			for(int i=0; i< m_iIncrementIntervals; i++)
			{
				clone = (GameObject)Instantiate(m_Object );
				clone.SetActive(false);
				m_Pool.Add(clone );
			}
		}

		clone = m_Pool[0];
		m_Pool.RemoveAt(0);

		clone.transform.position = position;
		clone.transform.rotation = rotation;
		clone.SetActive(bActive);

		return clone;
	}

	public void DeSpawn(GameObject go)
	{
		go.SetActive (false);
		m_Pool.Add(go);
	}
}
