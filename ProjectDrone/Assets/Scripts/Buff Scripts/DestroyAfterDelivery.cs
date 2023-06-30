using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelivery : MonoBehaviour
{
    [SerializeField]
    PlayerHealthSystem m_playerHealthSystem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HealingPlatform"))
        {
            print("test");
            m_playerHealthSystem.Heal();
            Destroy(gameObject);
        }
    }
}
