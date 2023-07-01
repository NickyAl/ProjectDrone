using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    GameObject m_camera;
    [SerializeField]
    float m_fParallaxEffect;

    private float m_fLength;
    private float m_fStartPosition;

    void Start()
    {
        m_fStartPosition = transform.position.x;
        m_fLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float fTemp = (m_camera.transform.position.x * (1 - m_fParallaxEffect));
        float distance = (m_camera.transform.position.x * m_fParallaxEffect);

        transform.position = new Vector3(m_fStartPosition + distance, transform.position.y, transform.position.z);

        if(fTemp > m_fStartPosition)
        {
            m_fStartPosition += m_fLength;
        }
        else if (fTemp < m_fStartPosition - m_fLength) {
            m_fStartPosition -= m_fLength;
        }
    }
}
