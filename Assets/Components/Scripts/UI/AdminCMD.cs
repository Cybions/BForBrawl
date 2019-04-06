using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdminCMD : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField ChatField;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCommand(ChatField.text);
            ChatField.text = "";
        }
    }

    void CheckCommand(string cmd)
    {
        switch (cmd)
        {
            case "/Start":
                GameManager.Instance.StartGame();
                break;
        }
    }
}
