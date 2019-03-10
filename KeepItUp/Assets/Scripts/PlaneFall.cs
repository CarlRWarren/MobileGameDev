using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFall : MonoBehaviour
{
    [SerializeField] MeshCollider m_meshCollider = null;
    [SerializeField] MeshRenderer m_meshRenderer = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            m_meshCollider.gameObject.SetActive(false);
            m_meshRenderer.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
