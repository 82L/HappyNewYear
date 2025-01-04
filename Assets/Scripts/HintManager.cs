using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_clickSprite;
    
    [SerializeField]
    private SpriteRenderer m_addonSprite;
    
    private int m_mouseClickCount = 0;
    
    private DateTime m_lastClickTime = DateTime.Now;
    
    private void Start()
    {
        m_addonSprite.DOFade(0, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_mouseClickCount++;
            m_clickSprite.DOFade(0f, 0.5f);
            m_addonSprite.DOFade(0f, 0.5f);
            m_lastClickTime = DateTime.Now;
        }

        if (m_lastClickTime < DateTime.Now.AddSeconds(-3) && m_mouseClickCount < 3 && m_mouseClickCount != 0  && m_addonSprite.color.a == 0)
        {
            m_clickSprite.DOFade(1f, 0.5f);
            m_addonSprite.DOFade(1f, 0.5f);
        }
    }
}
