using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPackage : MonoBehaviour
{
    [SerializeField]
    GameObject m_buffPackage;
    [SerializeField]
    PlayerHealthSystem m_healthSystem;

    private GameObject m_carriedPackage;

    private bool m_bHasPackage = false;

    public bool GetPlayerHasPackage()
    {
        return m_bHasPackage;
    }

    public void SetPlayerHasPackage(bool bHasPackage)
    {
        m_bHasPackage = bHasPackage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Buff") && m_bHasPackage == false)
        {
            Vector3 vecPosition = gameObject.transform.position;
            Instantiate(m_buffPackage, vecPosition, Quaternion.identity);
            m_carriedPackage = GameObject.FindGameObjectWithTag("CarriedPackage");
            m_bHasPackage = true;
        }

        if (other.gameObject.CompareTag("HealingPlatform") && m_bHasPackage == true)
        {
            m_healthSystem.Heal();
            m_bHasPackage = false;
            Destroy(m_carriedPackage);
        }
    }
}
