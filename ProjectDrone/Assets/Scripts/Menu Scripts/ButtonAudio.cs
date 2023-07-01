using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource m_buttonClickAudio;
    [SerializeField]
    AudioSource m_buttonHoverAudio;
    [SerializeField]
    
    public void PlayClickAudio()
    {
        m_buttonClickAudio.Play();
    }

    public void PlayHoverAudio()
    {
        m_buttonHoverAudio.Play();
    }
}
