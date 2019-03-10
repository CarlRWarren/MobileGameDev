using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetGame : MonoBehaviour
{
    [SerializeField] TargetData[] m_data = null;
    [SerializeField] float m_minRate = 0.5f;
    [SerializeField] float m_miaxRate = 2.0f;
    [SerializeField] TextMeshProUGUI m_scoreText = null;

    int score = 0;
    AudioSource m_audioSource = null;
    float m_timer = 0.0f;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();        
    }

    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_timer = Random.Range(m_minRate, m_miaxRate);
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 10.0f, 10.0f);

            GameObject go = PoolManager.Instance.pools["Targets"].Get(position, Quaternion.identity);
            Target target = go.GetComponent<Target>();
            target.data = m_data[Random.Range(0, m_data.Length)];
            go.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            m_audioSource.Play();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Target target = hit.collider.gameObject.GetComponent<Target>();
                if (target != null)
                {
                    target.OnHit(hit.point);
                    score += target.data.score;
                }
            }
        }
        m_scoreText.text = score.ToString("D8");
    }
}
