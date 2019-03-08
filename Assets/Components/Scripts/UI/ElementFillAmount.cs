using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ElementFillAmount : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = 0;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOFillAmount(1, .35f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOFillAmount(0, .35f);
    }

}
