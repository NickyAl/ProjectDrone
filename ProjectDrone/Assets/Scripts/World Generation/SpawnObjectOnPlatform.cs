using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject m_enemy;
    [SerializeField]
    GameObject m_pickUpablePackage;
    [SerializeField]
    Transform m_objectSpawner;
    [SerializeField]
    GameObject m_healingPlatform;

    void Start()
    {
        float fVerticalOffset = 0f;
        Vector3 vecPosition = new Vector3();

        if (Random.Range(0f, 1f) > 0.857)
        {
            fVerticalOffset = -0.3f;
            vecPosition = new Vector3(m_objectSpawner.position.x, m_objectSpawner.position.y + fVerticalOffset, m_objectSpawner.position.z);
            Instantiate(m_healingPlatform, vecPosition, Quaternion.identity);
            return;
        }

        fVerticalOffset = 0.4f;
        vecPosition = new Vector3(m_objectSpawner.position.x, m_objectSpawner.position.y + fVerticalOffset, m_objectSpawner.position.z);

        if (Random.Range(0f, 1f) > 0.833)
        {
            Instantiate(m_pickUpablePackage, vecPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(m_enemy, vecPosition, Quaternion.identity);
        }
    }
}
