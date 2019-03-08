using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class Menu_CreateGame : MonoBehaviour
{
    [SerializeField]
    private BFB_NetworkManager networkManager;

    [SerializeField]
    private TextMeshProUGUI IPAdress;
    [SerializeField]
    private Button BTN_StartGame;

    private void Start()
    {
        networkManager.OnServerCreated.AddListener(GetIPAdress);
    }

    public void ActivateWithDelay_StartGameBTN(float delay=0)
    {
        Invoke("Enable_StartGameBTN", delay);
    }
    public void Enable_StartGameBTN()
    {
        Activate_StartGameBTN(true);
    }
    public void Activate_StartGameBTN(bool newStatement)
    {
        BTN_StartGame.interactable = newStatement;
    }

    void GetIPAdress()
    {
        IPAdress.text = networkManager.matchInfo.address;
    }

}
