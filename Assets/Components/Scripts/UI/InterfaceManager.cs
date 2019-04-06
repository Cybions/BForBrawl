using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ServerAdress;

    // Start is called before the first frame update
    void Start()
    {
        ServerAdress.text = IPManager.GetIP(ADDRESSFAM.IPv4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
