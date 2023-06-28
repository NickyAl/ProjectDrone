using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform m_target;
    public Vector3 m_vecOffset = new Vector3(0f, 2f, -10f);

    //LateUpdate is called after all Update functions have been called. https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html
    void LateUpdate()
    {
        Vector3 vecTargetPosition = m_target.position + m_vecOffset;
        Vector3 vecSmoothedPosition = new Vector3(vecTargetPosition.x, transform.position.y, transform.position.z);
        transform.position = vecSmoothedPosition;
    }
}
