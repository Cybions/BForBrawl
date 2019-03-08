using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ElementMover : MonoBehaviour
{
    [SerializeField]
    private Vector3 Destination;

    [SerializeField]
    private Vector3 Origin;

    [SerializeField]
    private Ease ease;

    [SerializeField]
    private float duration;

    [SerializeField]
    private bool PlayAtStart = false;

    [SerializeField]
    private bool isAtOrigin = true;

    private Tweener CurrentTweener = null;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayAtStart)
        {
            CurrentTweener = transform.DOLocalMove(Destination, duration).SetEase(ease).OnComplete(delegate
            {
                isAtOrigin = false;
            });
        }
    }

    public void MoveElement()
    {
        if (CurrentTweener != null && !CurrentTweener.IsPlaying())
        {
            if (isAtOrigin)
            {
                CurrentTweener = transform.DOLocalMove(Destination, duration).SetEase(ease).OnComplete(delegate
                {
                    isAtOrigin = false;
                });
            }
            else
            {
                CurrentTweener = transform.DOLocalMove(Origin, duration).SetEase(ease).OnComplete(delegate
                {
                    isAtOrigin = true;
                });
            }
        }
        else
        {
            CurrentTweener = transform.DOLocalMove(Destination, duration).SetEase(ease).OnComplete(delegate
            {
                isAtOrigin = false;
            });
        }

    }

}
