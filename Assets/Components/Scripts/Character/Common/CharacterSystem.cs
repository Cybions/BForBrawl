using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterSystem : NetworkBehaviour
{
    public Camera MyCamera;

    [SerializeField]
    private CharacterSelection SelectionInterface;
    private CharacterSelection CurrentSelectionInterface;

    [SerializeField]
    private Character CurrentCharacter = null;

    bool CanLeaveSelection = false;

    // Start is called before the first frame update
    void Start()
    {
        MyCamera = GetComponentInChildren<Camera>();
        CurrentSelectionInterface = Instantiate(SelectionInterface, transform);
        CurrentSelectionInterface.Reply_CS = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && CurrentCharacter.CanSwapCharacter)
        {
            ToggleCharacterSelection();
        }
    }

    public void NewCharacterSelected(Character NewCharacter)
    {
        if (CurrentCharacter != null)
        {
            if (GetComponent<NetworkIdentity>().isServer)
            {
                NetworkServer.Destroy(CurrentCharacter.gameObject);
            }
            else
            {
                CmdDestroyPlayer();
            }
        }
        CurrentCharacter = NetworkIdentity.Instantiate(NewCharacter, transform);
        Destroy(CurrentSelectionInterface.gameObject);
        CanLeaveSelection = true;
        if (GetComponent<NetworkIdentity>().isServer)
        {
            NetworkServer.Spawn(CurrentCharacter.gameObject);
        }
        else
        {
            CmdSpawnPlayer();
        }

        if (isLocalPlayer)
        {
            CurrentCharacter.AttachCameraToCharacter(GetComponentInChildren<Camera>());
        }
    }

    [Command]
    void CmdDestroyPlayer()
    {
        NetworkServer.Destroy(CurrentCharacter.gameObject);
    }

    [Command]
    void CmdSpawnPlayer()
    {
        NetworkServer.Spawn(CurrentCharacter.gameObject);
    }

    public void ToggleCharacterSelection()
    {
        if (!CanLeaveSelection)
        {
            return;
        }
        if (CurrentSelectionInterface != null)
        {
            Destroy(CurrentSelectionInterface.gameObject);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            if (CurrentCharacter != null)
            {
                Destroy(CurrentCharacter.gameObject);
            }
            CurrentSelectionInterface = Instantiate(SelectionInterface, transform);
            CurrentSelectionInterface.Reply_CS = this;
            CanLeaveSelection = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
