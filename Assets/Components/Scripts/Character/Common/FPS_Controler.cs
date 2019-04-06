using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controler : MonoBehaviour
{
    public float MoveSpeed = 10;
    [SerializeField]
    private float JumpForce = 1;
    float distToGround;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        distToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
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
        bool result = Physics.Raycast(transform.position, -Vector3.up, (distToGround + 0.1f));
        print(result);
        return result;
    }

}
