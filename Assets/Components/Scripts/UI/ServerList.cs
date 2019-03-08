using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class ServerList : MonoBehaviour
{
    [SerializeField]
    private ServerFound btnPrefab;

    private void Awake()
    {
        AvailableServerList.OnAvailableServersChanged += AvailableServerList_OnAvailableServersChanged;
    }

    private void AvailableServerList_OnAvailableServersChanged(List<MatchInfoSnapshot> servers)
    {
        ClearExistingBTN();
        CreateNewBTNs(servers);
    }

    private void CreateNewBTNs(List<MatchInfoSnapshot> servers)
    {
        foreach(var server in servers)
        {
            var button = Instantiate(btnPrefab);
            button.Initialize(server, transform);
        }
    }

    private void ClearExistingBTN()
    {
        var buttons = GetComponentsInChildren<ServerFound>();
        foreach(var btn in buttons)
        {
            Destroy(btn.gameObject);
        }
    }
}
