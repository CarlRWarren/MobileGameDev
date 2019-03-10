using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TargetData m_data = null;
    [SerializeField] GameObject m_model = null;

    public TargetData data { get { return m_data; } set { m_data = value; } }

    Rigidbody m_rb = null;
    AudioSource m_audioSource = null;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        m_model.GetComponent<Renderer>().material = m_data.material;
        transform.localScale = Vector3.one * m_data.scale;
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            PoolManager.Instance.pools["Targets"].Return(gameObject);
        }
    }

    public void OnHit(Vector3 position)
    {
        m_rb.AddForce(Vector3.up * m_data.force, ForceMode.Impulse);
        m_audioSource.clip = m_data.audioClip;
        m_audioSource.Play();
    }
}
