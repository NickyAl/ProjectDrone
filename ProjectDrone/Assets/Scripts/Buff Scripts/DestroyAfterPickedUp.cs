using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPickedUp : MonoBehaviour
{
    private BuffPackage m_playerBuffPackage;
    private GameObject m_player;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_playerBuffPackage = m_player.GetComponent<BuffPackage>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && m_playerBuffPackage.GetPlayerHasPackage() == false)
        {
            Destroy(gameObject);
        }
    }
}
