using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireworkLauncher : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_fireworks;
    
    [SerializeField]
    private Image m_image;
    
    [SerializeField]
    private Gradient m_gradient;
    
    private float m_count = 0;
    
    private float m_currentProgress = 0f;
    private const int DECAY = 1;
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
            int l_rand = Random.Range(0, 100);
            m_fireworks.Emit( 5 );
            m_count+=0.1f;
        }

        float l_progress = Mathf.Lerp(0f, 1f, m_count);
        
        m_currentProgress = ExpDecay(m_currentProgress, l_progress);
        m_image.color = m_gradient.Evaluate(m_currentProgress);
        
     
    }

    private float ExpDecay(float p_a, float p_b)
    {
        return p_b + (p_a - p_b) * Mathf.Exp(-DECAY * Time.deltaTime);
    }
}
