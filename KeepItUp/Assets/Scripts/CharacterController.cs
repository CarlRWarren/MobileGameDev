using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
	[SerializeField] [Range(1.0f, 360.0f)] float m_rotateSpeed = 1.0f;
	[SerializeField] Animator m_animator = null;
    [SerializeField] GameObject ball = null;
    
	float yaw { get; set; } = 0.0f;
	Rigidbody m_rb = null;
	Vector3 m_velocity = Vector3.zero;

	private void Start()
	{
		m_rb = GetComponent<Rigidbody>();
		m_animator = (m_animator) ? m_animator : GetComponent<Animator>();
    }

    private void Update()
	{		
        Vector3 translate = Vector3.zero;
        if (transform.position.y >= 0.0f)
        {
            translate.z = Input.GetAxis("Vertical") * m_speed;
            yaw = yaw + Input.GetAxis("Horizontal") * m_rotateSpeed;

            transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
            m_velocity = transform.rotation * translate;

            float speed = m_velocity.magnitude / m_speed;
            m_animator.SetFloat("Speed", speed);
            m_rb.velocity = m_velocity;

            if (Input.GetButtonDown("Fire1"))
            {
                TryHitBall();
            }
        }
        else
        {
            m_animator.SetFloat("Speed", 0.0f);
            transform.rotation = Quaternion.identity;
            //set dead
            //store score
        }
    }

    private void TryHitBall()
    {
        float power = GetPower();
        if (power > 0.0f)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = GetReflected() * power;
        }
    }

    private Vector3 GetReflected()
    {
        Vector3 direction = Vector3.zero;
        Vector3 ballDirection = transform.position - ball.transform.position;
        Vector3 tangent = Vector3.Cross(ballDirection, Camera.main.transform.forward);
        Vector3 normal = Vector3.Cross(tangent, ballDirection);
        direction = Vector3.Reflect(Camera.main.transform.forward, normal);
        return direction.normalized;
    }

    private float GetPower()
    {
        float power = Random.Range(2.0f, 12.0f);
        return power;
    }

	void FixedUpdate()
	{
	}
}
