using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 50.0f)] float m_distance = 1.0f;
    [SerializeField] [Range(1.0f, 50.0f)] float m_sensitivity = 1.0f;
    [SerializeField] [Range(1.0f, 89.0f)] float m_pitchClamp = 1.0f;
    [SerializeField] [Range(1.0f, 50.0f)] float m_smoothing = 1.0f;
    [SerializeField] Transform m_target = null;

    float yaw { get; set; } = 0.0f;
    float pitch { get; set; } = 40.0f;

    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yaw = yaw + Input.GetAxis("CameraYaw") * m_sensitivity;
        pitch += -Input.GetAxis("CameraPitch") * m_sensitivity;
        pitch = Mathf.Clamp(pitch, -m_pitchClamp, m_pitchClamp);

        if (Input.GetButtonDown("ResetCameraYaw")) yaw = 0.0f;
    }

    private void LateUpdate()
    {
        Quaternion rotation = m_target.rotation * Quaternion.AngleAxis(yaw, Vector3.up) * Quaternion.AngleAxis(pitch, Vector3.right);
        Vector3 newPosition = m_target.position + (rotation * new Vector3(0.0f, 0.0f, -m_distance));

        if(Physics.Raycast(m_target.position,newPosition-m_target.position, out RaycastHit hit, m_distance))
        {
            newPosition = hit.point;
        }

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, m_smoothing * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(m_target.position - transform.position, Vector3.up);
    }
}
