using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] [Range(0.0f, 50.0f)] float m_force;
	[SerializeField] [Range(0.0f, 10.0f)] float m_lifetime = 1.0f;
	
    void Start()
    {
		GetComponent<Rigidbody>().AddForce(transform.rotation * new Vector3(0.0f, 0.0f, m_force), ForceMode.Impulse);
    }

    void Update()
    {
		m_lifetime = m_lifetime - Time.deltaTime;
		if (m_lifetime <= 0.0f)
		{
			Destroy(this.gameObject);
		}
    }
}
