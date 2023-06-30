using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndMenu : MonoBehaviour
{

    [SerializeField]
    PlayerHealthSystem m_playerHealt;
    [SerializeField]
    RectTransform m_currentTransform;
    [SerializeField]
    Vector3 vecShowPosition = new Vector3(0f, 0f, 0f);

    private void Update()
    {
        if(m_playerHealt.m_bDestroyed && m_currentTransform.position != vecShowPosition)
        {
            m_currentTransform.anchorMax = new Vector2(0.5f, 0.5f);
            m_currentTransform.anchorMin = new Vector2(0.5f, 0.5f);
            m_currentTransform.pivot = new Vector2(0.5f, 0.5f);
            m_currentTransform.position = vecShowPosition;
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
