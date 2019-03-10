using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
    [SerializeField] [Range(1.0f, 360.0f)] float m_rotateSpeed = 1.0f;
    [SerializeField] [Range(1.0f, 50.0f)] float m_sensitivity = 1.0f;
    [SerializeField] [Range(1.0f, 89.0f)] float m_pitchClamp = 1.0f;
    [SerializeField] Camera m_camera = null;
    [SerializeField] bool m_enableMouse = false;


    float yaw { get; set; } = 0.0f;
    float pitch { get; set; } = 0.0f;


    private void Start()
    {
        if (!m_camera)
        {
            m_camera = Camera.main;
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 translate = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) translate.z += m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) translate.z -= m_speed * Time.deltaTime;

        if (m_enableMouse)
        {
            yaw = yaw + Input.GetAxis("Mouse X") * m_sensitivity;
            if (Input.GetKey(KeyCode.A)) translate.x -= m_speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)) translate.x += m_speed * Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.A)) yaw -= m_rotateSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)) yaw += m_rotateSpeed * Time.deltaTime;
        }
        pitch += -Input.GetAxis("Mouse Y") * m_sensitivity;
        pitch = Mathf.Clamp(pitch, -m_pitchClamp, m_pitchClamp);

        transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
        transform.Translate(translate, Space.Self);

        m_camera.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * 15.0f;
        m_camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
