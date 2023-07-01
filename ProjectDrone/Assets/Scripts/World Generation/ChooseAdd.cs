using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAdd : MonoBehaviour
{
    [SerializeField]
    GameObject m_firstAdd;
    [SerializeField]
    GameObject m_secondAdd;
    [SerializeField]
    GameObject m_thirdAdd;

    void Start()
    {
        m_firstAdd.SetActive(false);
        m_secondAdd.SetActive(false);
        m_thirdAdd.SetActive(false);

        if (Random.Range(0f, 1f) > 0.33f)
        {
            m_firstAdd.SetActive(true);
        }
        else if (Random.Range(0f, 1f) > 0.5f)
        {
            m_secondAdd.SetActive(true);
        }
        else
        {
            m_thirdAdd.SetActive(true);
        }
    }
}
