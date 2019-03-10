
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCharacterMovement : MonoBehaviour
{

	[SerializeField] PlatformCharacterController m_controller = null;
	[SerializeField] Animator m_animator = null;

	public float runSpeed = 40.0f;

	float m_moveX = 0.0f;
	bool m_jump = false;

	void Update()
	{

		m_moveX = Input.GetAxisRaw("Horizontal") * runSpeed;

		m_animator.SetFloat("Speed", Mathf.Abs(m_moveX));

		if (Input.GetButtonDown("Jump"))
		{
			m_jump = true;
			m_animator.SetBool("IsJumping", true);
		}
	}

	public void OnLanding()
	{
		m_animator.SetBool("IsJumping", false);
	}

	void FixedUpdate()
	{
		m_controller.Move(m_moveX * Time.fixedDeltaTime, m_jump);
		m_jump = false;
	}
}