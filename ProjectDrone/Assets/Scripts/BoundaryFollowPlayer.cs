using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryFollowPlayer : MonoBehaviour
{
    public Transform m_target;
    public Vector3 m_vecOffset = new Vector3(0f, 2f, -10f);

    void LateUpdate()
    {
        if (m_target.position.x - transform.position.x > 10) {
            Vector3 vecTargetPosition = m_target.position + m_vecOffset;
            Vector3 vecSmoothedPosition = new Vector3(vecTargetPosition.x, transform.position.y, transform.position.z);
            transform.position = vecSmoothedPosition;
        }
    }
}
