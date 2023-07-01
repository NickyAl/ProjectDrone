using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPickedUp : MonoBehaviour
{
    [SerializeField]
    AudioSource m_hookPackageAudio;

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
            transform.position = new Vector3(transform.position.x, transform.position.y + 30f, transform.position.z);
            m_hookPackageAudio.Play();
        }
    }
}
