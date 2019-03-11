using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterSystem : NetworkBehaviour
{
    [SerializeField]
    private CharacterSelection SelectionInterface;
    private CharacterSelection CurrentSelectionInterface;

    [SerializeField]
    private Character CurrentCharacter = null;

    bool CanLeaveSelection = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSelectionInterface = Instantiate(SelectionInterface, transform);
        CurrentSelectionInterface.Reply_CS = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && CurrentCharacter.CanSwapCharacter)
        {
            ToggleCharacterSelection();
        }
    }

    public void NewCharacterSelected(Character NewCharacter)
    {
        if(CurrentCharacter != null)
        {
            NetworkServer.Destroy(CurrentCharacter.gameObject);
        }
        CurrentCharacter = NetworkIdentity.Instantiate(NewCharacter, transform);
        Destroy(CurrentSelectionInterface.gameObject);
        CanLeaveSelection = true;
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
