﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI swapCharacter;

    public bool CanSwapCharacter = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Camera>().depth = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawn")
        {
            swapCharacter.enabled = true;
            CanSwapCharacter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spawn")
        {
            swapCharacter.enabled = false;
            CanSwapCharacter = false;
        }
    }
}