using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class NavAgentAnim : MonoBehaviour
{
	NavMeshAgent m_navMeshAgent = null;
	Animator m_animator = null;

	void Start()
    {
		m_navMeshAgent = GetComponent<NavMeshAgent>();
		m_navMeshAgent.updatePosition = false;

		m_animator = GetComponent<Animator>();
	}

    void Update()
    {
		Vector3 velocity = m_navMeshAgent.desiredVelocity / m_navMeshAgent.speed;
		m_animator.SetFloat("Velocity", velocity.magnitude);
	}

	private void OnAnimatorMove()
	{
		transform.position = m_navMeshAgent.nextPosition;
	}

	public void SetTarget(Vector3 target)
	{
		m_navMeshAgent.destination = target;
	}
}
