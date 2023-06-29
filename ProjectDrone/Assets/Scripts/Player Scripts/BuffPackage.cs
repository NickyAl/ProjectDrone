using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPackage : MonoBehaviour
{
    [SerializeField]
    GameObject m_buffPackage;
    [SerializeField]
    PlayerHealthSystem m_healthSystem;

    private bool m_bHasPackage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Buff") && m_bHasPackage == false)
        {
            Vector3 vecPosition = gameObject.transform.position;
            Instantiate(m_buffPackage, vecPosition, Quaternion.identity);
            m_bHasPackage = true;
        }

        if (other.gameObject.CompareTag("HealingPlatform"))
        {
            m_healthSystem.Heal();
            m_bHasPackage = false;
        }
    }
}
