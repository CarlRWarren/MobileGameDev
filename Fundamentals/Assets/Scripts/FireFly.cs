using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 20.0f)] float m_rate = 1.0f;
    [SerializeField] [Range(0.0f, 20.0f)] float m_amplitude = 1.0f;

    float m_time = 0;
    void Start()
    {
        m_time = Random.value * 1000.0f;
    }

    void Update()
    {
        m_time += m_rate * Time.deltaTime;
        Vector3 position = new Vector3();
        position.x = (Mathf.PerlinNoise(m_time, 0.0f) * 2.0f) - 1.0f;
        position.y = (Mathf.PerlinNoise(0.0f, m_time) * 2.0f) -1.0f;
        position.z = (Mathf.PerlinNoise(m_time, m_time) * 2.0f) -1.0f;

        transform.localPosition = position * m_amplitude;
    }
}
