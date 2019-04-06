using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomtextFreeze : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Freeze());
    }

    IEnumerator Freeze()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            transform.DOShakePosition(1.5f, 3);
        }
    }

}
