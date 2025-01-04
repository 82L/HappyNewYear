using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    Camera m_camera; // set this via inspector
    float m_shake = 0;
    float m_shakeAmount =0f;
    float m_decreaseFactor = 2f;
    private const int DECAY = 16;
    private Vector3 m_originalPosition;
    private void Start()
    {
        m_originalPosition = m_camera.transform.localPosition;
    }
    private void Update() {
        if (m_shake > 0)
        {
            Vector3 l_cameraPos = m_originalPosition;
            Vector3 l_calculatedPos = Random.insideUnitSphere * m_shakeAmount;
            l_cameraPos.x += l_calculatedPos.x;
            l_cameraPos.y += l_calculatedPos.y;
            m_camera.transform.localPosition = l_cameraPos;
            m_shake = ExpDecay(0, m_shake);

        } else {
            m_shakeAmount = 0;
            m_camera.transform.localPosition = m_originalPosition;
        }
    }

    public void AddShake(int p_amount)
    {
        m_shake+=1f;
        m_shakeAmount += (0.05f * p_amount);
    }
    
    private float ExpDecay(float p_a, float p_b)
    {
        return p_b + (p_a - p_b) * Mathf.Exp(-DECAY * Time.deltaTime);
    }

    
}
