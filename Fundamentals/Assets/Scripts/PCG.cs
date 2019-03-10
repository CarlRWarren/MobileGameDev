using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCG : MonoBehaviour
{
	[SerializeField] GameObject m_object = null;
	[SerializeField] BoxCollider m_box = null;
	[SerializeField] [Range(0, 30)] int m_number = 5;

    void Start()
    {
        for (int i = 0; i < m_number; i++)
		{
			Vector3 position = Vector3.zero;
			position.x = Random.Range(m_box.bounds.min.x, m_box.bounds.max.x);
			position.y = Random.Range(m_box.bounds.min.y, m_box.bounds.max.y);
			position.z = Random.Range(m_box.bounds.min.z, m_box.bounds.max.z);
			Instantiate(m_object, position, Quaternion.identity, transform);
		}
    }
}
