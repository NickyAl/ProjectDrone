using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    Slider m_slider;
    [SerializeField]
    Gradient m_gradient;
    [SerializeField]
    Image m_fill;

    public void SetMaxHealth(int iHealth)
    {
        m_slider.maxValue = iHealth;
        m_slider.value = iHealth;

        m_fill.color = m_gradient.Evaluate(1f);
    }

    public void SetHealth(int iHealth)
    {
        m_slider.value = iHealth;

        m_fill.color = m_gradient.Evaluate(m_slider.normalizedValue);
    }
}
