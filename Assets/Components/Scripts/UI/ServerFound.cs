using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.Match;

public class ServerFound : MonoBehaviour
{
    private TextMeshProUGUI content;


    // Start is called before the first frame update
    void Awake()
    {
        content = GetComponentInChildren<TextMeshProUGUI>(); 
    }

    public void Initialize(MatchInfoSnapshot server, Transform panel)
    {
        content.text = server.name;
        transform.SetParent(panel);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

}
