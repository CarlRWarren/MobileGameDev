using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
	[SerializeField] Camera m_camera = null;
	[SerializeField][Tooltip("Tag of object to trigger camera")] string m_tag = "";
	
	// camera to disable (enter) / enable (exit)
	Camera m_cameraSave = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(m_tag))
		{
			m_cameraSave = Camera.main;
			m_cameraSave.enabled = false;
			m_camera.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(m_tag))
		{
			m_cameraSave.enabled = true;
			m_camera.enabled = false;
		}
	}
}
