using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Menu_LoadingAnimation : MonoBehaviour
{
    [SerializeField]
    private Image loadingIMG;

    [SerializeField]
    private bool PlayAtStart;

    bool Clockwise = true;
    float valueDestination = 1;
    float delay = .35f;
    Tweener currentMovement;
    private void Start()
    {
        loadingIMG.fillAmount = 0;
        if (PlayAtStart)
        {
            ClockwiseMovement();
        }
    }

    public void Animate(bool StartAnimation = true)
    {
        if (StartAnimation)
        {
            ClockwiseMovement();
        }
        else
        {
            currentMovement.Kill();
        }
    }

    private void ClockwiseMovement()
    {
        if(valueDestination == 0)
        {
            valueDestination = 1;
            delay = 0;
        }
        else
        {
            valueDestination = 0;
            delay = .35f;
        }
        loadingIMG.fillClockwise = Clockwise;
        currentMovement = loadingIMG.DOFillAmount(valueDestination, .8f).OnComplete(delegate { Clockwise = !Clockwise; Invoke("ClockwiseMovement", delay); });
    }

}
