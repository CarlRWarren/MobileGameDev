using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformCharacterController : MonoBehaviour
{
	[SerializeField] private float m_jumpForce = 400.0f;
	[SerializeField] float m_groundedRadius = 0.2f;
	[Range(0, .3f)] [SerializeField] private float m_smoothing = 0.05f;
	[SerializeField] private bool m_airControl = false;
	[SerializeField] private LayerMask m_groundMask;
	[SerializeField] private Transform m_groundCheck;
	
	private bool m_onGround;
	private Rigidbody2D m_rb;
	private bool m_facingRight = true;
	private Vector3 m_velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
		{
			OnLandEvent = new UnityEvent();
		}
	}

	private void FixedUpdate()
	{
		bool prevOnGround = m_onGround;
		m_onGround = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundCheck.position, m_groundedRadius, m_groundMask);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_onGround = true;
				if (!prevOnGround)
				{
					OnLandEvent.Invoke();
				}
			}
		}
	}

	public void Move(float move, bool jump)
	{
		if (m_onGround || m_airControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_rb.velocity.y);
			m_rb.velocity = Vector3.SmoothDamp(m_rb.velocity, targetVelocity, ref m_velocity, m_smoothing);

			if (move > 0 && !m_facingRight)
			{
				Flip();
			}
			else if (move < 0 && m_facingRight)
			{
				Flip();
			}
		}

		if (m_onGround && jump)
		{
			m_onGround = false;
			m_rb.AddForce(new Vector2(0f, m_jumpForce));
		}
	}
	
	private void Flip()
	{
		m_facingRight = !m_facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
