using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour
{
    //public Camera MyCamera;

    [SerializeField]
    private GameObject Camera;

    [SerializeField]
    private CharacterStats CurrentStats;

    private float CurrentLife = 1;


    [SerializeField]
    Transform CameraSpot;

    [SerializeField]
    private TextMeshProUGUI swapCharacter;

    public bool CanSwapCharacter = true;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentLife = CurrentStats.MaxLife;
        if (isLocalPlayer)
        {
            Camera.gameObject.SetActive(true);
            GetComponent<FPS_Controler>().enabled = true;
            GetComponent<CameraControler>().enabled = true;
            Invoke("placePlayer", 0);
        }

        
    }

    void placePlayer()
    {
        transform.parent = null;
        transform.position = SpawnManager.Instance.transform.position;
    }


    public float GetCurrentLife()
    {
        return CurrentLife;
    }










    public void AttachCameraToCharacter(Camera MyCamera)
    {
        MyCamera.transform.parent = this.transform;
        MyCamera.transform.position = CameraSpot.position;
        MyCamera.transform.rotation = CameraSpot.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawn")
        {
            swapCharacter.enabled = true;
            CanSwapCharacter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spawn")
        {
            swapCharacter.enabled = false;
            CanSwapCharacter = false;
        }
    }
}
