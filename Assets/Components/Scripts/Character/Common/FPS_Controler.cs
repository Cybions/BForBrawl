using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controler : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10;
    [SerializeField]
    private float JumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeCursorState();
        }
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        }
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(Movement * MoveSpeed * Time.deltaTime);

    }

    void ChangeCursorState()
    {
        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    bool CanJump()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (.5f + 0.1f));
    }

}
