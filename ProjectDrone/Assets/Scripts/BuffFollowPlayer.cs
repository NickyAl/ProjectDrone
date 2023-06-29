using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFollowPlayer : MonoBehaviour
{
    [SerializeField]
    float m_smoothIndex = 0.125f;
    [SerializeField]
    Vector3 m_vecOffset = new Vector3(0.5f, -0.5f, 0f);

    private GameObject m_player;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        Vector3 targetPosition = m_player.transform.position + m_vecOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, m_smoothIndex);
        transform.position = smoothedPosition;
    }
}