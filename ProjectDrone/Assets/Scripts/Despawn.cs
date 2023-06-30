using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField]
    float m_fDestroyDistance = 30f;

    private GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float fDistance = Vector2.Distance(transform.position, m_player.transform.position);

        if(transform.position.x > m_player.transform.position.x)
        {
            return;
        }

        if (fDistance > m_fDestroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
