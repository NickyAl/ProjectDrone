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
    [SerializeField]
    GameObject m_platformSquare;
    [SerializeField]
    GameObject m_platformSlim;
    [SerializeField]
    GameObject m_pillar;

    private bool m_bInstantiatedNext = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (m_bInstantiatedNext || other.gameObject.CompareTag("Player") == false)
        {
            return;
        }

        Vector3 vecPosition = new Vector3(m_levelTransform.position.x + m_fNextLevelOffset, m_levelTransform.position.y, m_levelTransform.position.z);
        Instantiate(m_level, vecPosition, Quaternion.identity);
        m_bInstantiatedNext = true;

        if (Random.Range(0f, 1f) > 0.5f)
        {
            InstantiateThree(vecPosition);
        }
        else
        {
            InstantiateTwo(vecPosition);
        }

    }

    void InstantiateTwo(Vector3 vecLevelPosition)
    {
        Vector3 vecPosition = new Vector3(vecLevelPosition.x + Random.Range(-6.5f, -2f), vecLevelPosition.y + Random.Range(-5f, 3f), vecLevelPosition.z);
        InstantiatePlatform(vecPosition);
        vecPosition = new Vector3(vecLevelPosition.x + Random.Range(1f, 6.5f), vecLevelPosition.y + Random.Range(-5f, 3f), vecLevelPosition.z);
        InstantiatePlatform(vecPosition);
    }

    void InstantiateThree(Vector3 vecLevelPosition)
    {
        Vector3 vecPosition = new Vector3(vecLevelPosition.x + Random.Range(-6.5f, -4f), vecLevelPosition.y + Random.Range(-5f, 3f), vecLevelPosition.z);
        InstantiatePlatform(vecPosition);
        vecPosition = new Vector3(vecLevelPosition.x + Random.Range(-1f, 2f), vecLevelPosition.y + Random.Range(-5f, 3f), vecLevelPosition.z);
        InstantiatePlatform(vecPosition);
        vecPosition = new Vector3(vecLevelPosition.x + Random.Range(4f, 6.5f), vecLevelPosition.y + Random.Range(-5f, 3f), vecLevelPosition.z);
        InstantiatePlatform(vecPosition);
    }

    void InstantiatePlatform(Vector3 vecPosition)
    {
        if (Random.Range(0f, 1f) > 0.3f)
        {
            Vector3 vecBottomPillarPosition = new Vector3(vecPosition.x, vecPosition.y - 6.3f, vecPosition.z);
            Instantiate(m_pillar, vecBottomPillarPosition, Quaternion.identity);

            Vector3 vecTopPillarPosition = new Vector3(vecPosition.x, vecPosition.y + Random.Range(3f, 5f) + 6.3f, vecPosition.z);
            Instantiate(m_pillar, vecTopPillarPosition, Quaternion.identity);

            return;
        }

        if (Random.Range(0f, 1f) > 0.5f)
        {
            Instantiate(m_platformSquare, vecPosition, Quaternion.identity);
            return;

        }

        Instantiate(m_platformSlim, vecPosition, Quaternion.identity);

    }
}