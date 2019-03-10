using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
	[SerializeField] [Range(1.0f, 360.0f)] float m_rotateSpeed = 1.0f;

	// in-air
	[SerializeField] [Range(0.0f, 5.0f)] float m_groundDistance = 0.2f;
	//[SerializeField] [Range(0.0f, 5.0f)] float m_fallDistance = 0.2f;
	[SerializeField] LayerMask m_layerMask;
	[SerializeField] [Range(0.0f, 50.0f)] float m_jumpForce = 1.0f;

	[SerializeField] AudioSource m_footstepSFX = null;
	[SerializeField] Animator m_animator = null;

	float yaw { get; set; } = 0.0f;

	Rigidbody m_rb = null;
	Vector3 m_velocity = Vector3.zero;

	bool m_onGround = true;
	Vector3 m_groundNormal;
	float m_jumpTimer = 0.0f;

	private void Start()
	{
		m_rb = GetComponent<Rigidbody>();
		m_animator = (m_animator) ? m_animator : GetComponent<Animator>();
	}

	private void Update()
	{
		RaycastHit hit;
		m_onGround = OnGround(m_groundDistance, out hit);

		m_jumpTimer = m_jumpTimer - Time.deltaTime;
		if (m_onGround && m_jumpTimer <= 0.0f)
		{
			if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
			{
				m_animator.SetBool("Fall", false);
				m_animator.SetTrigger("Land");
			}

			Vector3 translate = Vector3.zero;

			translate.z = Input.GetAxis("Vertical") * m_speed;
			yaw = yaw + Input.GetAxis("Horizontal") * m_rotateSpeed;

			transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
			m_velocity = transform.rotation * translate;

			float speed = m_velocity.magnitude / m_speed;
			m_animator.SetFloat("Speed", speed);
			m_rb.velocity = m_velocity;
			
			if (Input.GetButtonDown("Attack")) m_animator.SetTrigger("Attack");
			//if (Input.GetButtonDown("Fire2")) m_animator.SetTrigger("Punch");
			if (Input.GetButtonDown("Die")) m_animator.SetTrigger("Die");
			if (Input.GetButtonDown("Fire1") && m_onGround)
			{
				m_animator.SetTrigger("Jump");
				m_velocity = m_velocity + Vector3.up * m_jumpForce;
				m_rb.velocity = m_velocity;
				m_jumpTimer = 0.2f;
			}
		}
		else
		{
			if (m_rb.velocity.y < 0.0f)
			{
				m_animator.SetBool("Fall", true);
			}
		}
	}

	bool OnGround(float distance, out RaycastHit hit)
	{
		Debug.DrawRay(transform.position + (Vector3.up * 0.1f), Vector3.down * distance, Color.red);

		return (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, distance, m_layerMask));
	}

	void FixedUpdate()
	{
		Debug.Log(m_velocity);
		
	}

	void PlayFootstepSFX()
	{
		m_footstepSFX.Play();
	}
}
