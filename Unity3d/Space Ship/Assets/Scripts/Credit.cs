using UnityEngine;
using System.Collections;
using PickUps;

public class Credit : PickUp 
{
	public int iCreditValue = 1;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameManager.s_Score += iCreditValue;
			if(GameData.current)
				GameData.current.credits += iCreditValue;

			PoolManager.Despawn(gameObject);
		}
	}
}
