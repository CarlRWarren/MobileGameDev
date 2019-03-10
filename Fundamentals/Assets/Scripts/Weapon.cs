using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] Projectile m_projectile; 
	[SerializeField] AudioSource m_fireSound;
	[SerializeField] AudioSource m_emptySound;
	[SerializeField] Transform m_muzzle;
	[SerializeField] [Range(0.0f, 1.0f)] float m_fireRate;
	[SerializeField] [Range(0.0f, 100.0f)] int m_ammo;
    [SerializeField] string m_fireButton = "";

	float m_fireTimer = 0.0f;

    void Update()
    {
		m_fireTimer = m_fireTimer - Time.deltaTime;
		if (Input.GetButton(m_fireButton))
		{
			if (m_fireTimer <= 0.0f)
			{
				m_fireTimer = m_fireRate;
				if (m_ammo > 0)
				{
					m_ammo--;
					m_fireSound.Play();
					Instantiate(m_projectile, m_muzzle.position, m_muzzle.rotation);
				}
                else
                {
                    m_emptySound.Play();
                }
			}
		}
	}
}
