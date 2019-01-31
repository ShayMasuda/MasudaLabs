using System;
using UnityEngine;

namespace Weapons
{
	[System.Serializable]
	public class Weapon
	{
		public Transform	m_tSlot;
		public float		m_fRate = 5;
		protected float 	m_fFireTime = 0f;
		public String		m_strWeaponType;
		public String		m_strButton;

		public Weapon ()
		{
			m_fFireTime = 1/m_fRate;
		}
			
		virtual public void Fire()
		{
			m_fFireTime += Time.deltaTime;
			if(Input.GetAxis(m_strButton) != 0)
			{
				if(m_fFireTime >= 1/m_fRate)
				{
					m_fFireTime = 0;
					GameObject projectile = PoolManager.Spawn(m_strWeaponType);
					projectile.transform.position = m_tSlot.position;
					projectile.transform.rotation = m_tSlot.rotation;
					projectile.SetActive(true);
				}
			}
		}
	}
}

