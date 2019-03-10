using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_highScoreText = null;
    [SerializeField] TextMeshProUGUI m_scoreText = null;
    [SerializeField] AudioMixer m_audioMixer = null;
    [SerializeField] Slider m_musicSlider = null;

    int m_score = 0;
    int m_highscore = 999999;
    float m_musicVolume = 0.0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            m_highscore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", m_highscore);
        }

        m_highScoreText.text = m_highscore.ToString("D6");

        m_musicVolume = (PlayerPrefs.HasKey("MusicVolume")) ? PlayerPrefs.GetFloat("MusicVolume") : 1.0f;
        SetMusicVolume(m_musicVolume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_score = Random.Range(0, 99999);
            if (m_score > m_highscore)
            {
                m_highscore = m_score;
                PlayerPrefs.SetInt("HighScore", m_highscore);
                m_highScoreText.text = m_highscore.ToString("D6");
            }
        }
        m_scoreText.text = m_score.ToString("D6");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void SetMusicVolume(float level)
    {
        m_musicVolume = level;
        m_audioMixer.SetFloat("MusicVolume", ConvertDecibel(m_musicVolume));
        PlayerPrefs.SetFloat("MusicVolume", m_musicVolume);
        m_musicSlider.value = m_musicVolume;
    }

    static public float ConvertDecibel(float value)
    {
        return Mathf.Log10(value) * 20.0f;
    }
}
