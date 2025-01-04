using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireworkSoundSystem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_particleSystem;

    [SerializeField]
    private AudioSource m_audioSource;
    
    [SerializeField]
    private AudioClip[] m_bornSounds;
    
    [SerializeField]
    private AudioClip[] m_deadSounds;
    
    [SerializeField]
    private CameraShake m_cameraShake;
    
    private int m_currentNumberOfParticles;
    // Start is called before the first frame update
    private void Start()
    {
        Random.InitState((int)DateTime.Now.Ticks);
    }
    // Update is called once per frame
    private void Update()
    {
        int l_amount = Mathf.Abs(m_currentNumberOfParticles - m_particleSystem.particleCount);

        if (m_particleSystem.particleCount < m_currentNumberOfParticles)
        {
            PlaySounds(m_deadSounds, l_amount);
            m_cameraShake.AddShake(l_amount);
        }

        if (m_particleSystem.particleCount > m_currentNumberOfParticles)
        {
            PlaySounds(m_bornSounds, l_amount);
        }
        
        m_currentNumberOfParticles = m_particleSystem.particleCount;
    }

    private void PlaySounds(AudioClip[] p_clips, int p_amount)
    {
        for (int i = 0; i < p_amount; i++)
        {
            AudioClip l_clip = p_clips[Random.Range(0, p_clips.Length)];
            m_audioSource.PlayOneShot(l_clip);
        }
    }
   
}
