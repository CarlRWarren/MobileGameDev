using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject m_3 = null;
    [SerializeField] GameObject m_2 = null;
    [SerializeField] GameObject m_1 = null;

    [SerializeField] Slider m_healthSlider;
    float m_health = 100.0f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());   
        StartCoroutine(HealthCoroutine(50.0f));   
    }

   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_health = Random.Range(0.0f, 100.0f);
        }
    }

    IEnumerator HealthCoroutine(float rate)
    {
        while (true)
        {
            float health = m_healthSlider.value;
            float dh = m_health - health;
            if (dh != 0.0f)
            {
                float ah = rate * Time.deltaTime * Mathf.Sign(dh);
                health += ah;
                if (Mathf.Sign(m_health - health) != Mathf.Sign(dh))
                {
                    health = m_health;
                }
                m_healthSlider.value = health;
            }


            yield return null;
        }
    }

    IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(2.0f);

        m_3.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        m_3.SetActive(false);
        yield return new WaitForSeconds(0.25f);

        m_2.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        m_2.SetActive(false);
        yield return new WaitForSeconds(0.25f);

        m_1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        m_1.SetActive(false);


        yield return null;
    }
}
