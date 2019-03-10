using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator m_animator = null;
    [SerializeField] string m_tag = "";
    [SerializeField] string m_paramater = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_tag))
        {
            m_animator.SetBool(m_paramater, true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(m_tag))
        {
            m_animator.SetBool(m_paramater, false);
        }
    }
}
