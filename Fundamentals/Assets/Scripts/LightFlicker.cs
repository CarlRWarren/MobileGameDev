using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] float m_intensityMin = 0.0f;
    [SerializeField] [Range(0.0f, 10.0f)] float m_intensityMax = 0.0f;
    [SerializeField] [Range(0.0f, 10.0f)] float m_rate = 0.0f;

    Light m_light = null;

    void Start()
    {
        m_light = GetComponent<Light>();
    }
    void Update()
    {
        //m_light.intensity = Random.Range(m_intensityMin, m_intensityMax);
        m_light.intensity = Mathf.Lerp(m_intensityMin, m_intensityMax, Mathf.PerlinNoise(Time.time * m_rate, 0.0f));
        //DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.yellow * m_light.intensity);
    }
}
