using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
    [SerializeField] [Range(1.0f, 50.0f)] float m_sensitivity = 1.0f;
    [SerializeField] [Range(1.0f, 89.0f)] float m_pitchClamp = 1.0f;


    float yaw { get; set; } = 0.0f;
    float pitch { get; set; } = 0.0f;

    Camera m_camera = null;

    private void Start()
    {
        m_camera = Camera.main;
    }

    void Update()
    {
        Vector3 translate = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) translate.z += m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) translate.z -= m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) translate.x -= m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) translate.x += m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) translate.y -= m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) translate.y += m_speed * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            yaw = yaw + Input.GetAxis("Mouse X") * m_sensitivity;
            pitch += -Input.GetAxis("Mouse Y") * m_sensitivity;
            pitch = Mathf.Clamp(pitch, -m_pitchClamp, m_pitchClamp);
        }


        transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up) * Quaternion.AngleAxis(pitch, Vector3.right);
        transform.Translate(translate, Space.Self);

        m_camera.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * 15.0f;
    }
}
