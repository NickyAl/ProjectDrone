using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseVisuals : MonoBehaviour
{
    [SerializeField]
    GameObject m_otherVisual;

    private static int m_iCountDefaultVisual = 0;
    private static int m_iCountOtherVisual = 0;

    void Start()
    {
        if (m_iCountOtherVisual % 2 == 1)
        {
            m_iCountOtherVisual++;
            return;
        }

        if (m_iCountDefaultVisual % 2 == 1)
        {
            m_iCountDefaultVisual++;
            m_otherVisual.SetActive(false);
            return;
        }

        if (Random.Range(0f, 1f) > 0.5f)
        {
            m_iCountDefaultVisual++;
            m_otherVisual.SetActive(false);
        }
        else
        {
            m_iCountOtherVisual++;
        }
    }
}
