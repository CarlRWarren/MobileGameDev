using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float m_speed = 1.0f;

    Animator m_animator = null;
    Rigidbody2D m_rb = null;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        float magnitude = direction.magnitude;
        direction = (magnitude > 0) ? direction.normalized : Vector3.zero;
        if(magnitude != 0.0f)
        {
            m_animator.SetFloat("MoveX", direction.x);
            m_animator.SetFloat("MoveY", direction.y);
        }
        m_animator.SetFloat("Move", magnitude);

        m_rb.velocity = direction * m_speed;
    }
}
