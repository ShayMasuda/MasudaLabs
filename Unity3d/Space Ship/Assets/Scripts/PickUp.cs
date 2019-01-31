using UnityEngine;
using System.Collections;

namespace PickUps
{
	public class PickUp : MonoBehaviour {

		private float fTime;
		// Use this for initialization
		void Start () 
		{
			Reset();
		}
		
		// Update is called once per frame
		void Update () 
		{
			transform.Rotate(new Vector3(0, 0, 5) );
			StartCoroutine("Blink");
		}

		IEnumerator Blink()
		{
			yield return new WaitForSeconds(5);
			Color newColor = GetComponent<Renderer>().material.color;
			float freq = Mathf.Pow((Time.time - fTime), 2.4f);
			newColor.a = (Mathf.Cos( freq + fTime) + 1f)/2;
			GetComponent<Renderer>().material.color = newColor;
			StartCoroutine("DestroyPickUp");
		}

		IEnumerator DestroyPickUp()
		{
			yield return new WaitForSeconds(5);
			PoolManager.Despawn(gameObject);
		}

		public void Reset()
		{
			fTime = Time.time;
			Color newColor = GetComponent<Renderer>().material.color;
			newColor.a = 1;
			GetComponent<Renderer>().material.color = newColor;
		}

	}
}
