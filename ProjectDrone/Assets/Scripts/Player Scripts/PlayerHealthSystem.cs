using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField]
    int m_iMaxHealth = 5;
    [SerializeField]
    GameObject m_brokenDrone;
    [SerializeField]
    HealthBarScript m_healthBar;

    private int m_iCurrentHealth = 5;
    
    public bool m_bDestroyed = false;


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
            m_iCurrentHealth--;
            CurrentHealthChanged();
        }
    }

    void CurrentHealthChanged()
    {
        m_healthBar.SetHealth(m_iCurrentHealth);

        if(m_iCurrentHealth == 0)
        {
            //Destroy(gameObject);
            m_bDestroyed = true;
            Vector3 vecPosition = gameObject.transform.position;
            Instantiate(m_brokenDrone, vecPosition, Quaternion.identity);
        }
    }
}
