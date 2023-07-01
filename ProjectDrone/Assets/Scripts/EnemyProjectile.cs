using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    GameObject m_player;
    [SerializeField]
    float m_fForce = 0.0f;
    [SerializeField]
    GameObject m_level;

    private Rigidbody2D m_rigidbody;
    private float m_fTimer = 0.0f;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_player = GameObject.FindGameObjectWithTag("Player");

        if (m_player.transform.position.x > 1000f)
        {
            m_fForce *= 1.5f;
        }
        if (m_player.transform.position.x > 2000f)
        {
            m_fForce *= 2f;
        }

        Vector3 direction = m_player.transform.position - transform.position;
        m_rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * m_fForce;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    void Update()
    {
        m_fTimer += Time.deltaTime;

        if(m_fTimer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Level") || other.gameObject.CompareTag("PlayableZone"))
        {
            return;
        }

        Destroy(gameObject);
    }
}
