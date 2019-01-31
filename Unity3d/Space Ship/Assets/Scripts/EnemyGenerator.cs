using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public float fEnemyRate = 0.3f; // Enemies a second

	private float fEnemyTime = 0f;
	// Use this for initialization
	void Start () 
	{
		fEnemyTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fEnemyTime += Time.deltaTime;
		if(fEnemyTime >= 1/fEnemyRate)
		{
			fEnemyTime = 0;
			GameObject enemy = PoolManager.Spawn("prefab_Enemy");
			Enemy enemyScript = (Enemy)enemy.GetComponent("Enemy");
			enemyScript.Reset();
			enemy.SetActive(true);
		}
	}
}
