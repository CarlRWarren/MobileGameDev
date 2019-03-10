using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
	[SerializeField] [Range(1.0f, 360.0f)] float m_rotateSpeed = 1.0f;
    [SerializeField] Skybox[] m_worldbox = null;
	[SerializeField] AudioSource[] m_backgroundMusic = null;
	[SerializeField] Animator m_animator = null;


	float yaw { get; set; } = 0.0f;
	Rigidbody m_rb = null;
	Vector3 m_velocity = Vector3.zero;
    int happiness { get; set; } = 0;
    int timesPet { get; set; } = 0;
    bool collision = false;

	private void Start()
	{
		m_rb = GetComponent<Rigidbody>();
		m_animator = (m_animator) ? m_animator : GetComponent<Animator>();
        m_backgroundMusic[0].Play();
    }

    private void Update()
	{		
        Vector3 translate = Vector3.zero;

        translate.z = Input.GetAxis("Vertical") * m_speed;
        yaw = yaw + Input.GetAxis("Horizontal") * m_rotateSpeed;

        transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
        m_velocity = transform.rotation * translate;

        float speed = m_velocity.magnitude / m_speed;
        m_animator.SetFloat("Speed", speed);
        m_rb.velocity = m_velocity;
        if (Input.GetButtonDown("Pet") && collision)
        {
            m_animator.SetTrigger("Pet");
            timesPet++;
        }
        //if (Input.GetButtonDown("Water") && collision)
        //{
        //    m_animator.SetTrigger("Water");
        //    happiness++;
        //}
        if (timesPet==5)
        {
            timesPet = 0;
            happiness++;
        }
        m_animator.SetInteger("Happiness", happiness);
        if (happiness == 6)
        {
            m_backgroundMusic[0].Stop();
            m_backgroundMusic[1].Play();
            RenderSettings.skybox = m_worldbox[1].material;
            DynamicGI.UpdateEnvironment();
        }
        else if(happiness == 11)
        {
            m_backgroundMusic[1].Stop();
            m_backgroundMusic[2].Play();
            RenderSettings.skybox = m_worldbox[2].material;
            DynamicGI.UpdateEnvironment();
        }
        else if (happiness == 16)
        {
            m_backgroundMusic[2].Stop();
            m_backgroundMusic[3].Play();
            RenderSettings.skybox = m_worldbox[3].material;
            DynamicGI.UpdateEnvironment();
        }
        else if (happiness == 21)
        {
            m_backgroundMusic[3].Stop();
            m_backgroundMusic[4].Play();
            RenderSettings.skybox = m_worldbox[4].material;
            DynamicGI.UpdateEnvironment();
        }
    }

	void FixedUpdate()
	{
		Debug.Log(m_velocity);
	}
    private void OnTriggerEnter(Collider other)
    {
        collision = true;
    }
    private void OnTriggerExit(Collider other)
    {
        collision = false;
    }

}
