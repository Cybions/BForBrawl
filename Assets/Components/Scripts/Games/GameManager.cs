using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private List<CapturePoint> CapturePointsList;

    [SerializeField]
    private List<GameObject> AttackTeam;

    [SerializeField]
    private List<GameObject> DefenseTeam;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        foreach(CapturePoint cp in CapturePointsList)
        {
            cp.OnPointCompleted.AddListener(RemoveCurrentPoint);
        }
        ActivateNextCapturePoint();
    }

    void RemoveCurrentPoint()
    {
        CapturePointsList.RemoveAt(0);
        if(CapturePointsList.Count > 0)
        {
            ActivateNextCapturePoint();
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        throw new NotImplementedException();
    }

    void ActivateNextCapturePoint()
    {
        CapturePointsList[0].ActivatePoint();
    }



    public bool CanPlayerCapturePoint(List<GameObject> Listpl)
    {

        foreach(GameObject pl in Listpl)
        {
            if (!AttackTeam.Contains(pl))
            {
                return false;
            }
        }
        return true;
    }
}
