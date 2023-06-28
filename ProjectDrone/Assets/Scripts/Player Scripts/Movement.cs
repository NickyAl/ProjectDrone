using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float m_fHorizontalInput = 0f;
    private float m_fVerticalInput = 0f;
    private Rigidbody2D m_rigidbody;
    private bool m_bHasBoost = false;

    [SerializeField]
    float m_fInputThrust = 0f;
    [SerializeField]
    float m_fIdleThrust = 0f;
    [SerializeField]
    float m_fGliding = 0f;
    [SerializeField]
    float m_fGravityPull = 0f;
    [SerializeField]
    float m_fBoostMultiplier = 0f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_fHorizontalInput = Input.GetAxis("Horizontal");
        m_fVerticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("space"))
        {
            m_bHasBoost = true;
        }
        if (Input.GetKeyUp("space"))
        {
            m_bHasBoost = false;
        }
    }

    // is called once per physics update
    void FixedUpdate()
    {
        float fMovementX = (GetThrust() + m_fGliding) * Time.fixedDeltaTime * Mathf.Sin(-1f * m_rigidbody.rotation * (Mathf.PI / 180f));
        float fMovementY = GetThrust() * Time.fixedDeltaTime * Mathf.Cos(m_rigidbody.rotation * (Mathf.PI / 180f)) - m_fGravityPull;
        transform.position += new Vector3(fMovementX, fMovementY, 0f);


        if (m_fHorizontalInput > 0)
        {
            m_rigidbody.rotation -= m_bHasBoost ? 0.45f : 0.9f;
        }
        if (m_fHorizontalInput < 0)
        {
            m_rigidbody.rotation += m_bHasBoost ? 0.45f : 0.9f;
        }
    }

    float GetThrust()
    {
        float fFinalThrust = 0f;
        float fPrecision = 0.0001f;
        if (m_fVerticalInput < fPrecision && m_fVerticalInput > -1f * fPrecision)
        {
            fFinalThrust = m_fIdleThrust;
        }
        else if(m_fVerticalInput > fPrecision)
        {
            fFinalThrust = m_fIdleThrust + m_fInputThrust;
        }
        else if(m_fVerticalInput < -1f * fPrecision)
        {
            fFinalThrust = 0;
        }

        if (m_bHasBoost)
        {
            fFinalThrust *= m_fBoostMultiplier;
        }

        return fFinalThrust;
    }
}