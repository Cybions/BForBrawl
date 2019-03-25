using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

    #region
    // Passif : Quand l'agent 13 possède plus que 80% de points de vie, sa vitesse de déplacement augmente de30%;


    #endregion

    [SerializeField]
    private CharacterStats CurrentStats;

    [SerializeField]
    private FPS_Controler fPS_Controler;

    private float oldMoveSpeed;

    public float CurrentLife = 1.0f; //No zero at start or it will be dying at spawn
    public int CurrentAmmo = 0;

    private bool isReloading = false;

    [SerializeField]
    private bool isPassiveActive = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLife = CurrentStats.MaxLife; //Spawn with full health   
        CurrentAmmo = CurrentStats.MaxAmmo;
        oldMoveSpeed = fPS_Controler.MoveSpeed;
    }



    // Update is called once per frame
    void Update()
    {
        if(CurrentLife <= 0)
        {
            print("YOU ARE DEAD");
        }
        CheckInputs();
        CheckPassive();
    }

    void CheckInputs()
    {
        if (Input.GetMouseButtonDown(0)) //TODO : Need to use Charactercontroller's btn
        {
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reloading();
        }
    }

    void CheckPassive()
    {
        float GetAmountofLife = CurrentLife / CurrentStats.MaxLife;
        if(GetAmountofLife >= 0.8f)
        {
            fPS_Controler.MoveSpeed = oldMoveSpeed * 1.3f;
            isPassiveActive = true;
        }
        else
        {
            fPS_Controler.MoveSpeed = oldMoveSpeed;
            isPassiveActive = false;
        }
    }

    void shoot()
    {
        if (isReloading)
        {
            return;
        }
        if (CurrentAmmo <= 0)
        {
            //print("Cant Shoot");
            StartCoroutine(Reload());
        }
        else
        {
            //print("Shooting");
            CurrentAmmo--;
        }

    }

    void Reloading()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(CurrentStats.ReloadingSpeed); // Wait reloading animation
        CurrentAmmo = CurrentStats.MaxAmmo;
        isReloading = false;
    }
}
