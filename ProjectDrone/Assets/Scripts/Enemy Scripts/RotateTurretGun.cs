using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurretGun : MonoBehaviour
{
    [SerializeField]
    GameObject m_turretGunPivot;

    private GameObject m_player;
    private bool m_playerPassedTurrert = false;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 direction = m_player.transform.position - m_turretGunPivot.transform.position;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        if(m_player.transform.position.x > m_turretGunPivot.transform.position.x && m_playerPassedTurrert == false)
        {
            m_playerPassedTurrert = true;
            HorizontalFlipTurret();
        }
        if (m_player.transform.position.x < m_turretGunPivot.transform.position.x && m_playerPassedTurrert == true)
        {
            m_playerPassedTurrert = false;
            HorizontalFlipTurret();
        }
        m_turretGunPivot.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    void HorizontalFlipTurret()
    {
        Vector3 originalScale = m_turretGunPivot.transform.localScale;
        m_turretGunPivot.transform.localScale = new Vector3(originalScale.x, -1f * originalScale.y, originalScale.z);
    }
}
