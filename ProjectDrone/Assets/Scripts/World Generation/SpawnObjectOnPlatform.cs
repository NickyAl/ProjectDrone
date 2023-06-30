using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject m_enemy;
    [SerializeField]
    GameObject m_health;
    [SerializeField]
    float m_fVerticalOffset = 0.5f;
    [SerializeField]
    Transform m_objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) > 0.8)
        {
            return;
        }

        Vector3 vecPosition = new Vector3(m_objectSpawner.position.x, m_objectSpawner.position.y + m_fVerticalOffset, m_objectSpawner.position.z);

        if (Random.Range(0f, 1f) > 0.8)
        {
            Instantiate(m_health, vecPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(m_enemy, vecPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
