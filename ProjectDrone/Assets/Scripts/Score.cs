using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    TMP_Text m_txtScoreText;
    [SerializeField]
    GameObject m_player;

    int m_iScore = 0;
    float m_fMaxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_txtScoreText.text = "Score: " + m_iScore.ToString();
    }

    void FixedUpdate()
    {
        if(m_player.transform.position.x > m_fMaxScore)
        {
            m_fMaxScore = m_player.transform.position.x;
            m_iScore = (int)(m_fMaxScore / 5);
            m_txtScoreText.text = "Score: " + m_iScore.ToString();
        }
    }
}
