using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{
	[SerializeField] Camera m_camera = null;
	[SerializeField] NavAgentAnim m_navAgent;
	
	List<NavAgentAnim> m_navAgents = new List<NavAgentAnim>();

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				if (Input.GetKey(KeyCode.LeftControl))
				{
					NavAgentAnim navAgent= Instantiate(m_navAgent, hit.point, Quaternion.identity, transform);
					m_navAgents.Add(navAgent);
				}
				else
				{
					foreach (NavAgentAnim navAgent in m_navAgents)
					{
						navAgent.SetTarget(hit.point);
					}
				}
			}
		}
	}
}
