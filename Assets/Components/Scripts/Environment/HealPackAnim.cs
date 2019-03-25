using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealPackAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomRotation();
    }

    void RandomRotation()
    {
        Vector3 RandomPosition = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        transform.DORotate(RandomPosition, Random.Range(1, 3)).SetEase(Ease.InOutBack).OnComplete(delegate { RandomRotation(); });
    }

}
