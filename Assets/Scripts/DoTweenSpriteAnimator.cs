using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweenSpriteAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Sequence l_sequence = DOTween.Sequence();
        l_sequence.Append(transform.DOScale(new Vector3(1.05f, 1.05f, 1f), 1.5f));
        l_sequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 1.5f));
        l_sequence.SetLoops(-1);
        l_sequence.Play();
    }
}
