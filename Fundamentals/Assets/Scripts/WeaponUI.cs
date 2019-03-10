using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] WeaponStats m_stats = null;
    [SerializeField] Image m_image = null;
    [SerializeField] TextMeshProUGUI m_name= null;
    [SerializeField] TextMeshProUGUI m_strength = null;
    [SerializeField] TextMeshProUGUI m_description = null;
    void Start()
    {
        m_image.sprite = m_stats.sprite;
        m_name.text = m_stats.name;
        m_strength.text = m_stats.strength.ToString("00.0");
        m_description.text = m_stats.description;
    }

    public void OnPointerEnter()
    {
        m_description.gameObject.SetActive(true);
    }
    public void OnPointerExit()
    {
        m_description.gameObject.SetActive(false);
    }

}
