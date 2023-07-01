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
    private float m_fTimer = 0.0f;
    private bool m_bReducedHealth = false;

    public bool m_bDestroyed = false;

    void Start()
    {
        m_iCurrentHealth = m_iMaxHealth;
        m_healthBar.SetMaxHealth(m_iMaxHealth);
    }

    void Update()
    {
        m_fTimer += Time.deltaTime;

        if (m_fTimer > 1)
        {
            m_fTimer = 0;
            m_iCurrentHealth -= m_bIsInDeadZone ? m_iMaxHealth / 10 : 1;
            CurrentHealthChanged();
        }

        if(m_bReducedHealth == false && transform.position.x > 750f)
        {
            ReduceMaxHealt();
        }
    }

    public void Heal()
    {
        m_iCurrentHealth = m_iMaxHealth;
        CurrentHealthChanged();
    }

    void ReduceMaxHealt()
    {
        m_iMaxHealth = 30;
        float fTempHealth = (float)m_iCurrentHealth;
        fTempHealth = (fTempHealth / 5f) * 3f;
        m_iCurrentHealth = (int)fTempHealth;
        m_healthBar.SetMaxHealth(m_iMaxHealth);
        CurrentHealthChanged();
        m_bReducedHealth = true;
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

            Instantiate(m_brokenDrone, vecPosition, transform.rotation);
        }
    }
}
