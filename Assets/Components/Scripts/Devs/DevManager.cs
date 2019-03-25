using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockUnlockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockUnlockCursor();
        }   
    }

    void LockUnlockCursor()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
