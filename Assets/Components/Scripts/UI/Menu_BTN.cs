using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class Menu_BTN : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Transform TextInside;

    [SerializeField]
    private Transform Hover_Position;

    [SerializeField]
    private float Start_Position;

    [SerializeField]
    private Image Background;

    private void Start()
    {
        Start_Position = this.transform.localPosition.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TextInside.DOLocalMoveX(Hover_Position.position.x, .35f);
        Background.DOFade(1,.35f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextInside.DOLocalMoveX(Start_Position, .35f);
        Background.DOFade(0, .35f);
    }
}
