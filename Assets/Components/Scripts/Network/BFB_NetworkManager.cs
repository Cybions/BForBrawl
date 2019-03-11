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

    NetworkClient NetClient;


    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch(networkAddress, 8, true, "", "", "", 0, 0, OnServerJustCreated);
        NetworkServer.Listen(4444);
        //NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnect);

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

    public void ConnectToServer(string IPAdress)
    {
        //matchMaker.JoinMatch(matchInfo.networkId, "", "", "", 0, 0, HandleJoinedMatch);
        NetClient = new NetworkClient();
        NetClient.RegisterHandler(MsgType.Connect, OnConnected);
        NetClient.Connect(IPAdress, 4444);
        print(IPAdress);
        StartClient();
    }

    private void HandleJoinedMatch(bool success, string extendedInfo, MatchInfo responseData)
    {
        //
    }

    private void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}
