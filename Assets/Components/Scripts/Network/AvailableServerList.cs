using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public static class AvailableServerList
{

    public static event Action<List<MatchInfoSnapshot>> OnAvailableServersChanged = delegate { };
    private static List<MatchInfoSnapshot> servers = new List<MatchInfoSnapshot>();


    public static void HandleNewServerList(List<MatchInfoSnapshot> serverlist)
    {
        servers = serverlist;
        OnAvailableServersChanged(servers);
    }
}
