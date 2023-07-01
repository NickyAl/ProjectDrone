using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectiles : MonoBehaviour
{
    [SerializeField]
    GameObject m_projectile;
    [SerializeField]
    Transform m_projTransform;
    [SerializeField]
    float m_fRange = 7.5f;

    private float m_fTimer = 0.0f;
    private GameObject m_player;


    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float fDistance = Vector2.Distance(transform.position, m_player.transform.position);
        
        if(fDistance < m_fRange)
        {
            m_fTimer += Time.deltaTime;

            float shootingPauseTime = m_player.transform.position.x > 1500f ? 0.7f : 1f;

            if (m_fTimer > shootingPauseTime)
            {
                m_fTimer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(m_projectile, m_projTransform.position, Quaternion.identity);
    }
}
