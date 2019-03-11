using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
public class Menu_JoinGame : MonoBehaviour
{
    [SerializeField]
    private Menu_LoadingAnimation loadingAnimation;

    [SerializeField]
    private TMP_InputField ipAdresseField;

    [SerializeField]
    private Button ConnectionBTN;

    [SerializeField]
    private TextMeshProUGUI ConnectionInfos;

    private Tweener tweener;
    [SerializeField]
    BFB_NetworkManager NetManager;

    private void Start()
    {
        ResetWindow();
    }

    public void ResetWindow()
    {
        ipAdresseField.gameObject.SetActive(true);
        ConnectionBTN.gameObject.SetActive(true);
        ConnectionInfos.text = "";
    }

    public void TryConnection()
    {
        if (ipAdresseField.text.Length <= 0)
        {
            if(tweener == null || !tweener.IsPlaying())
            {
                tweener = ConnectionBTN.transform.DOShakePosition(.35f, 10);
            }
            return;
        }
        ipAdresseField.gameObject.SetActive(false);
        ConnectionBTN.gameObject.SetActive(false);
        ConnectionInfos.text = "Connection en cours..";
        loadingAnimation.Animate();
        NetManager.ConnectToServer(ipAdresseField.text);
        
    }
}
