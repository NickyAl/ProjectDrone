using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField]
    int m_iMaxHealth = 50;
    [SerializeField]
    GameObject m_brokenDrone;
    [SerializeField]
    HealthBarScript m_healthBar;

    private int m_iCurrentHealth = 50;
    private bool m_bIsInDeadZone = false;
    
    public bool m_bDestroyed = false;
    private float m_fTimer = 0.0f;

    void Update()
    {
        m_fTimer += Time.deltaTime;

        if (m_fTimer > 1)
        {
            m_fTimer = 0;
            m_iCurrentHealth -= m_bIsInDeadZone ? m_iMaxHealth / 10 : 1;
            CurrentHealthChanged();
        }
    }

    public void Heal()
    {
        m_iCurrentHealth = m_iMaxHealth;
        CurrentHealthChanged();
    }

    void Start()
    {
        m_iCurrentHealth = m_iMaxHealth;
        m_healthBar.SetMaxHealth(m_iMaxHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(m_bDestroyed == true)
        {
            return;
        }

        if (other.gameObject.CompareTag("Attack Projectile"))
        {
            m_iCurrentHealth -= m_iMaxHealth / 6;
            CurrentHealthChanged();
        }

        if (other.gameObject.CompareTag("DeadZone"))
        {
            m_bIsInDeadZone = true;
        }
        if (other.gameObject.CompareTag("PlayableZone"))
        {
            m_bIsInDeadZone = false;
        }
    }

    void CurrentHealthChanged()
    {
        m_healthBar.SetHealth(m_iCurrentHealth);

        if(m_iCurrentHealth <= 0)
        {
            m_bDestroyed = true;
            Vector3 vecPosition = gameObject.transform.position;
            Instantiate(m_brokenDrone, vecPosition, Quaternion.identity);
        }
    }
}
