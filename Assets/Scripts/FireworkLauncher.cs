using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireworkLauncher : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_fireworks;
    
    [SerializeField]
    private TMP_Text m_text;
    private float m_count = 0;
    private void Start()
    {
        m_fireworks.Pause();
        Random.InitState(this.GetInstanceID());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int rand = Random.Range(0, 100);
            m_fireworks.Emit(rand < 10 ? 20 : 1);
            m_count+=0.05f;
            // m_fireworks.Play(true);
        }
        
        m_text.color = Color.Lerp(new Color(0f, 0f, 0f, 0.6f), new Color(1f, 1f, 1f, 1f), m_count);
        
     
    }
}
