using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class CapturePoint : MonoBehaviour
{
    public float CapturePercent = 0;
    public bool isActive = false;

    public UnityEvent OnPointCompleted;
    [SerializeField]
    private Image PointIMG;
    [SerializeField]
    private Material ActiveMaterial;
    [SerializeField]
    private Material DesableMaterial;
 
    private List<GameObject> PlayersOnPoint;

    [SerializeField]
    private GameManager gm;

    private void Start()
    {
        PlayersOnPoint = new List<GameObject>();
    }

    public void ActivatePoint()
    {
        isActive = true;
        StartCoroutine(CaptureCouldown());
        VisualEffects(true);
        PointIMG.fillAmount = 0;
    }

    public void CompletePoint()
    {
        isActive = false;

        VisualEffects(false);
        PointIMG.gameObject.SetActive(false);
        OnPointCompleted.Invoke();
    }

    void VisualEffects(bool IsPointActivating)
    {
        if (IsPointActivating)
        {
            GetComponent<MeshRenderer>().material = ActiveMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = DesableMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayersOnPoint.Contains(other.gameObject))
        {
            PlayersOnPoint.Add(other.gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (PlayersOnPoint.Contains(other.gameObject))
        {
            PlayersOnPoint.Remove(other.gameObject);
        }
    }

    IEnumerator CaptureCouldown()
    {
        while(CapturePercent < 1)
        {
            if(PlayersOnPoint.Count <= 0)
            {
                yield return null;
            }
            else
            {
                if (gm.CanPlayerCapturePoint(PlayersOnPoint))
                {
                    CapturePercent += 0.1f;
                    PointIMG.DOFillAmount(CapturePercent, 1).SetEase(Ease.Linear);
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    yield return null;
                }
            }
        }
        CompletePoint();
    }
}
