using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.Networking.Match;
using System;

public class BFB_NetworkManager : NetworkManager
{
    public UnityEvent OnServerCreated;

    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch(networkAddress, 8, true, "", "", "", 0, 0, OnServerJustCreated);

    }

    private void OnServerJustCreated(bool success, string extendedInfo, MatchInfo responseData)
    {
        base.StartHost(responseData);
        OnServerCreated.Invoke();
    }

    private void OnEnable()
    {
        RefreshServers();
    }

    private void RefreshServers()
    {
        if(matchMaker == null)
        {
            StartMatchMaker();
        }
        matchMaker.ListMatches(0, 10,"", true, 0, 0, HandleListMatchesComplete);
    }

    private void HandleListMatchesComplete(bool success, string extendedinfo, List<MatchInfoSnapshot> responsedata)
    {
        AvailableServerList.HandleNewServerList(responsedata);
    }
}
