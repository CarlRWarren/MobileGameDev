using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour
{
	[SerializeField] Transform m_target = null;

    void LateUpdate()
    {
		if (m_target)
		{
			transform.rotation = Quaternion.LookRotation(m_target.position - transform.position, Vector3.up);
		}
    }
}
