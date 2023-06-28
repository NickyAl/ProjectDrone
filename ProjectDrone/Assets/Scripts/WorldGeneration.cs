using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject m_level;
    [SerializeField]
    Transform m_levelTransform;
    [SerializeField]
    float m_fNextLevelOffset = 17.8f;

    private GameObject m_player;
    private float m_fDestroyDistance = 30f;
    private bool m_bInstantiatedNext = false;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (m_bInstantiatedNext || other.gameObject.CompareTag("Player") == false)
        {
            return;
        }

        Vector3 position = new Vector3(m_levelTransform.position.x + m_fNextLevelOffset, m_levelTransform.position.y, m_levelTransform.position.z);
        Instantiate(m_level, position, Quaternion.identity);
        m_bInstantiatedNext = true;
    }

    void Update()
    {
        float fDistance = Vector2.Distance(transform.position, m_player.transform.position);

        if (fDistance > m_fDestroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
